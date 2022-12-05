/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
	Copyright (C) 2022 Francois Oligny-Lemieux <frank.quebec+git@gmail.com>

*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;

namespace OpenHardwareMonitor.GUI {

  public class AlertParameters {
    public enum ACTION {
      StartProgram = 1,
      StopProcess
    }
    public int? Min { get; set; }
    public int? Max { get; set; }
    public ACTION Action { get; set; }
    public string Filename { get; set; }
    public string Arguments { get; set; }
    public string Process { get; set; }

    public AlertParameters() {
    }

    public AlertParameters(AlertParameters parameters) {
      Min = parameters.Min;
      Max = parameters.Max;
      Action = parameters.Action;
      Filename = parameters.Filename;
      Arguments = parameters.Arguments;
      Process = parameters.Process;
    }
  }

  public class AlertConfig : AlertParameters {
    public ISensor Sensor { get; set; }
    public DateTime LastTriggered { get; set; }
  }

  public class AlertWatcher : IDisposable {
    private IComputer computer;
    private PersistentSettings settings;
    private UnitManager unitManager;
    private List<AlertConfig> list = new List<AlertConfig>();
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
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(AlertParameters));
        StringWriter textWriter = new StringWriter();

        try {
          using (StringReader textReader = new StringReader(value)) {
            AlertParameters existingConfig = (AlertParameters)xmlSerializer.Deserialize(textReader);
            Add(sensor,
              existingConfig.Min,
              existingConfig.Max,
              existingConfig.Action, 
              existingConfig.Filename,
              existingConfig.Arguments,
              existingConfig.Process);
          }
        } catch (Exception e) {
          Console.WriteLine(e.ToString());
        }
      }
    }

    private void SensorRemoved(ISensor sensor) {
      AlertConfig alertConfig;
      if (Contains(sensor, out alertConfig)) 
        Remove(sensor, false);
    }

    public void Dispose() {
      foreach (AlertConfig config in list) {
        // cleanup here if needed config.xyz.Dispose();
      }
      mainIcon.Dispose();
    }

    private void AnalyzeSensor(AlertConfig config) {

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

      bool triggered = false;
      if (config.Min != null && config.Min > config.Sensor.Value) {
        Console.WriteLine("ALERT: value "+ ((int)config.Sensor.Value).ToString() + " is lower than minimum " + config.Min);
        triggered = true;
      }
      if (config.Max != null && config.Max < config.Sensor.Value) {
        Console.WriteLine("ALERT: value " + ((int)config.Sensor.Value).ToString() + " is higher than maximum " + config.Max);
        triggered = true;
      }

      if (triggered) {
        DateTime now = DateTime.Now;
        System.TimeSpan diff = now.Subtract(config.LastTriggered);
        if (diff.Minutes < 5) {
          // Mute
          Console.WriteLine("Muting alert since < 5 minutes");
          return;
        }
      }

      if (triggered && config.Action == AlertParameters.ACTION.StopProcess) {
        System.Diagnostics.Process[] procs = null;
        procs = Process.GetProcessesByName(config.Process);
        if (procs != null) {
          for (int i = 0; i < procs.Length; i++) { 
            Process proc = procs[i];
            if (!proc.HasExited) {
              proc.Kill();
            }
          }
        }
      } else if (triggered && config.Action == AlertParameters.ACTION.StartProgram) {
        ProcessStartInfo startInfo = new ProcessStartInfo(config.Filename);
        startInfo.Arguments = config.Arguments;
        Process.Start(startInfo);
      }

      if (triggered) {
        config.LastTriggered = DateTime.Now;
      }
    }

    public void Redraw() {
      foreach (AlertConfig config in list) {
        AnalyzeSensor(config);
      }
    }

    public bool Contains(ISensor sensor, out AlertConfig alertConfig) {
      foreach (AlertConfig loopItem in list) {
        if (loopItem.Sensor == sensor) {
          alertConfig = loopItem;
          return true;
        }
      }
      alertConfig = null;
      return false;
    }

    public void Add(ISensor sensor, int? min, int? max, string programStart, string arguments, string processStop) {
      this.Add(sensor, min, max,
        programStart != null ?  AlertParameters.ACTION.StartProgram :  AlertParameters.ACTION.StopProcess,
        programStart, arguments, processStop);
    }

    public void Add(ISensor sensor, int? min, int? max, AlertParameters.ACTION Action, string programStart, string arguments, string processStop) {
      AlertConfig alertConfig;
      if (Contains(sensor, out alertConfig)) {
        return;
      } else {
        AlertConfig config = new AlertConfig();
        config.Sensor = sensor;
        config.Min = min;
        config.Max = max;
        if (programStart != null) {
          config.Action =  AlertParameters.ACTION.StartProgram;
          config.Filename = programStart;
          config.Arguments = arguments;
        } else {
          config.Action =  AlertParameters.ACTION.StopProcess;
          config.Process = processStop;
        }
        list.Add(config);
        UpdateMainIconVisibilty();
        string value = "";

        AlertParameters toSerialize = new AlertParameters(config);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(AlertParameters));
        using (StringWriter textWriter = new StringWriter()) {
          xmlSerializer.Serialize(textWriter, toSerialize);
          value = textWriter.ToString();
        }
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
      AlertConfig instance = null;
      foreach (AlertConfig config in list)
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
