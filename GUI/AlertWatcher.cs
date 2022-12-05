/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;

namespace OpenHardwareMonitor.GUI {
  public class SensorAlert {
    public ISensor Sensor { get; set; }
    public int? Min { get; set; }
    public int? Max { get; set; }
  }

  public class AlertWatcher : IDisposable {
    private IComputer computer;
    private PersistentSettings settings;
    private UnitManager unitManager;
    private List<SensorAlert> list = new List<SensorAlert>();
    private bool mainIconEnabled = false;
    private NotifyIconAdv mainIcon;

    private string PERSISTANT_KEY = "alertWatcher";

    public AlertWatcher(IComputer computer, PersistentSettings settings,
      UnitManager unitManager) 
    {
      this.computer = computer;
      this.settings = settings;
      this.unitManager = unitManager;
      computer.HardwareAdded += new HardwareEventHandler(HardwareAdded);
      computer.HardwareRemoved += new HardwareEventHandler(HardwareRemoved);

      this.mainIcon = new NotifyIconAdv();

      ContextMenu contextMenu = new ContextMenu();
      MenuItem hideShowItem = new MenuItem("Hide/Show");
      hideShowItem.Click += delegate(object obj, EventArgs args) {
        SendHideShowCommand();
      };
      contextMenu.MenuItems.Add(hideShowItem);
      contextMenu.MenuItems.Add(new MenuItem("-"));      
      MenuItem exitItem = new MenuItem("Exit");
      exitItem.Click += delegate(object obj, EventArgs args) {
        SendExitCommand();
      };
      contextMenu.MenuItems.Add(exitItem);
      this.mainIcon.ContextMenu = contextMenu;
      this.mainIcon.DoubleClick += delegate(object obj, EventArgs args) {
        SendHideShowCommand();
      };
      this.mainIcon.Icon = EmbeddedResources.GetIcon("smallicon.ico");
      this.mainIcon.Text = "Open Hardware Monitor";
    }

    private void HardwareRemoved(IHardware hardware) {
      hardware.SensorAdded -= new SensorEventHandler(SensorAdded);
      hardware.SensorRemoved -= new SensorEventHandler(SensorRemoved);
      foreach (ISensor sensor in hardware.Sensors) 
        SensorRemoved(sensor);
      foreach (IHardware subHardware in hardware.SubHardware)
        HardwareRemoved(subHardware);
    }

    private void HardwareAdded(IHardware hardware) {
      foreach (ISensor sensor in hardware.Sensors)
        SensorAdded(sensor);
      hardware.SensorAdded += new SensorEventHandler(SensorAdded);
      hardware.SensorRemoved += new SensorEventHandler(SensorRemoved);
      foreach (IHardware subHardware in hardware.SubHardware)
        HardwareAdded(subHardware);
    }

    private void SensorAdded(ISensor sensor) {
      string value = settings.GetValue(new Identifier(sensor.Identifier, PERSISTANT_KEY).ToString(), "");
      if (value != "") {
        int? min = null;
        int? max = null;
        int indexOfMin = value.IndexOf("min");
        if (indexOfMin >= 0) {
          int parsedMin = 0;
          if (Int32.TryParse(value.Substring(indexOfMin + 4), out parsedMin)) {
            min = parsedMin;
          }
        }
        int indexOfMax = value.IndexOf("max");
        if (indexOfMax >= 0) {
          int parsedMax = 0;
          if (Int32.TryParse(value.Substring(indexOfMax + 4), out parsedMax)) {
            max = parsedMax;
          }
        }

        Add(sensor, min, max);
      }
    }

    private void SensorRemoved(ISensor sensor) {
      SensorAlert alertConfig;
      if (Contains(sensor, out alertConfig)) 
        Remove(sensor, false);
    }

    public void Dispose() {
      foreach (SensorAlert config in list) {
        // cleanup here if needed config.xyz.Dispose();
      }
      mainIcon.Dispose();
    }

    private void AnalyzeSensor(SensorAlert config) {

      string format = "";
      switch (config.Sensor.SensorType) {
        case SensorType.Voltage: format = "\n{0}: {1:F2} V"; break;
        case SensorType.Clock: format = "\n{0}: {1:F0} MHz"; break;
        case SensorType.Load: format = "\n{0}: {1:F1} %"; break;
        case SensorType.Temperature: format = "\n{0}: {1:F1} °C"; break;
        case SensorType.Fan: format = "\n{0}: {1:F0} RPM"; break;
        case SensorType.Flow: format = "\n{0}: {1:F0} L/h"; break;
        case SensorType.Control: format = "\n{0}: {1:F1} %"; break;
        case SensorType.Level: format = "\n{0}: {1:F1} %"; break;
        case SensorType.Power: format = "\n{0}: {1:F0} W"; break;
        case SensorType.Data: format = "\n{0}: {1:F0} GB"; break;
        case SensorType.Factor: format = "\n{0}: {1:F3} GB"; break;
      }
      string formattedValue = string.Format(format, config.Sensor.Name, config.Sensor.Value);
      Console.WriteLine(formattedValue + " Min: " + config.Min + ", Max:"+ config.Max);

      bool exit = false;
      if (config.Min != null && config.Min > config.Sensor.Value) {
        Console.WriteLine("ALERT: value is lower than minimum " + config.Min);
        exit = true;
      }
      if (config.Max != null && config.Max < config.Sensor.Value) {
        Console.WriteLine("ALERT: value is higher than maximum " + config.Max);
        exit = true;
      }

      if (exit) {
        System.Diagnostics.Process[] procs = null;
        procs = Process.GetProcessesByName("Kryptex");
        if (procs != null) {
          for (int i = 0; i < procs.Length; i++) { 
            Process mspaintProc = procs[i];
            if (!mspaintProc.HasExited) {
              mspaintProc.Kill();
            }
          }
        }
      }
    }

    public void Redraw() {
      foreach (SensorAlert config in list) {
        AnalyzeSensor(config);
      }
    }

    public bool Contains(ISensor sensor, out SensorAlert alertConfig) {
      foreach (SensorAlert loopItem in list) {
        if (loopItem.Sensor == sensor) {
          alertConfig = loopItem;
          return true;
        }
      }
      alertConfig = null;
      return false;
    }

    public void Add(ISensor sensor, int? min, int? max) {
      SensorAlert alertConfig;
      if (Contains(sensor, out alertConfig)) {
        return;
      } else {
        SensorAlert config = new SensorAlert();
        config.Sensor = sensor;
        config.Min = min;
        config.Max = max;
        list.Add(config);
        UpdateMainIconVisibilty();
        string value = "min:" + min.ToString() + ";max:" + max.ToString();
        settings.SetValue(new Identifier(sensor.Identifier, PERSISTANT_KEY).ToString(), value);
      }
    }

    public void Remove(ISensor sensor) {
      Remove(sensor, true);
    }

    private void Remove(ISensor sensor, bool deleteConfig) {
      if (deleteConfig) {
        settings.Remove(new Identifier(sensor.Identifier, PERSISTANT_KEY).ToString());
      }
      SensorAlert instance = null;
      foreach (SensorAlert config in list)
        if (config.Sensor == sensor)
          instance = config;
      list.Remove(instance);
  
    }

    public event EventHandler HideShowCommand;

    public void SendHideShowCommand() {
      if (HideShowCommand != null)
        HideShowCommand(this, null);
    }

    public event EventHandler ExitCommand;

    public void SendExitCommand() {
      if (ExitCommand != null)
        ExitCommand(this, null);
    }

    private void UpdateMainIconVisibilty() {
      if (mainIconEnabled) {
        mainIcon.Visible = list.Count == 0;
      } else {
        mainIcon.Visible = false;
      }
    }

    public bool IsMainIconEnabled {
      get { return mainIconEnabled; }
      set {
        if (mainIconEnabled != value) {
          mainIconEnabled = value;
          UpdateMainIconVisibilty();
        }
      }
    }
  }
}
