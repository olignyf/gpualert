/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;

namespace OpenHardwareMonitor.GUI {
  public class AlertWatcher : IDisposable {
    private IComputer computer;
    private PersistentSettings settings;
    private UnitManager unitManager;
    private List<ISensor> list = new List<ISensor>();
    private bool mainIconEnabled = false;
    private NotifyIconAdv mainIcon;

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
      if (settings.GetValue(new Identifier(sensor.Identifier, 
        "tray").ToString(), false)) 
        Add(sensor, false);   
    }

    private void SensorRemoved(ISensor sensor) {
      if (Contains(sensor)) 
        Remove(sensor, false);
    }

    public void Dispose() {
      foreach (SensorNotifyIcon icon in list)
        icon.Dispose();
      mainIcon.Dispose();
    }

    private void AnalyzeSensor(ISensor sensor) {

      string format = "";
      switch (sensor.SensorType) {
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
      string formattedValue = string.Format(format, sensor.Name, sensor.Value);
      Console.WriteLine(formattedValue);
    }

    public void Redraw() {
      foreach (ISensor icon in list) {
        AnalyzeSensor(icon);
      }
    }

    public bool Contains(ISensor sensor) {
      foreach (ISensor loopItem in list)
        if (loopItem == sensor)
          return true;
      return false;
    }

    public void Add(ISensor sensor, bool balloonTip) {
      if (Contains(sensor)) {
        return;
      } else {        
        list.Add(sensor);
        UpdateMainIconVisibilty();
        settings.SetValue(new Identifier(sensor.Identifier, "tray").ToString(), true);
      }
    }

    public void Remove(ISensor sensor) {
      Remove(sensor, true);
    }

    private void Remove(ISensor sensor, bool deleteConfig) {
      if (deleteConfig) {
        settings.Remove(
          new Identifier(sensor.Identifier, "tray").ToString());
        settings.Remove(
          new Identifier(sensor.Identifier, "traycolor").ToString());
      }
      list.Remove(sensor);
  
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
