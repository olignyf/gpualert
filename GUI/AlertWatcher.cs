/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
	Copyright (C) 2022-2025 Francois Oligny-Lemieux <frank.quebec+git@gmail.com>

  Description: Add alert on min/max values

  Dev pointers:
    Alerts are saved (serialized) to the registry next to the other Hardwaremonitor PersistentSettings parameters.
    List of Alerts is accessible at runtime via AlertWatcher's `private List<AlertConfig> list`.

*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;

namespace OpenHardwareMonitor.GUI {

  public class AlertParameters {
    public enum ACTION {
      START_PROGRAM = 1,
      STOP_PROCESS,
    }
    public int? Min { get; set; }
    public int? Max { get; set; }
    public ACTION Action { get; set; }
    public string Filename { get; set; }
    public string Arguments { get; set; }
    public string Process { get; set; }
    public string SoundFile { get; set; }

    public AlertParameters() {
    }

    public AlertParameters(AlertParameters parameters) {
      Min = parameters.Min;
      Max = parameters.Max;
      Action = parameters.Action;
      Filename = parameters.Filename;
      Arguments = parameters.Arguments;
      Process = parameters.Process;
      SoundFile = parameters.SoundFile;
    }
  }

  public class AlertConfig : AlertParameters {
    public ISensor Sensor { get; set; }
    public DateTime LastTriggered { get; set; }
    public int Triggered { get; set; } = 0;
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
            AddToList(sensor,
              existingConfig.Min,
              existingConfig.Max,
              existingConfig.Action, 
              existingConfig.Filename,
              existingConfig.Arguments,
              existingConfig.Process,
              existingConfig.SoundFile);
          }
        } catch (Exception e) {
          Console.WriteLine(e.ToString());
          // Clear settings
          settings.Remove(new Identifier(sensor.Identifier, PERSISTANT_KEY).ToString());
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

      if (!triggered) {
        return;
      }

      // Alert triggered !
      config.Sensor.Triggered = ++config.Triggered;

      if (config.SoundFile != null && config.SoundFile != "") {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@config.SoundFile);
        player.Play();
      }

      if (config.Action == AlertParameters.ACTION.STOP_PROCESS) {
        // turn off process
        TurnOffProcess(config.Process);
      } else if (config.Action == AlertParameters.ACTION.START_PROGRAM) {
        // launch program
        ProcessStartInfo startInfo = new ProcessStartInfo(config.Filename);
        startInfo.Arguments = config.Arguments;
        Process.Start(startInfo);
      }

      if (triggered) {
        config.LastTriggered = DateTime.Now;
      }
    }

    public static bool TurnOffProcess(string processName) {
      System.Diagnostics.Process[] procs = null;
      procs = Process.GetProcessesByName(processName);
      if (procs != null) {
        for (int i = 0; i < procs.Length; i++) {
          Process proc = procs[i];
          if (!proc.HasExited) {
            proc.Kill();
          }
        }
        return true;
      }
      return false;
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

    public void Add(ISensor sensor, NumericUpDown min, NumericUpDown max, string programStart, string arguments, string processStop, string audioFile) {
      int? minDecimal = null, maxDecimal = null;
      if (min.Text != "") {
        minDecimal = (int?)min.Value;
      }
      if (max.Text != "") {
        maxDecimal = (int?)max.Value;
      }
      this.AddAndSerialize(sensor, minDecimal, maxDecimal,
        programStart != null ?  AlertParameters.ACTION.START_PROGRAM :  AlertParameters.ACTION.STOP_PROCESS,
        programStart, arguments, processStop, audioFile);
    }

    public void AddAndSerialize(ISensor sensor, int? min, int? max, AlertParameters.ACTION Action, string programStart, string arguments, string processStop, string audioFile) {
      AlertConfig alertConfig = this.AddToList(sensor, min, max, Action, programStart, arguments, processStop, audioFile);
    
      string value = "";
      AlertParameters toSerialize = new AlertParameters(alertConfig);
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(AlertParameters));
      using (StringWriter textWriter = new StringWriter()) {
        xmlSerializer.Serialize(textWriter, toSerialize);
        value = textWriter.ToString();
      }
      settings.SetValue(new Identifier(sensor.Identifier, PERSISTANT_KEY).ToString(), value);
    }

    public AlertConfig AddToList(ISensor sensor, int? min, int? max, AlertParameters.ACTION Action, string programStart, string arguments, string processStop, string audioFile) {
      AlertConfig alertConfig = null;
      bool editMode = false;
      if (Contains(sensor, out alertConfig)) {
        // Edit Alert
        if (alertConfig != null) {
          editMode = true;
          Remove(sensor);
        }
      }

      if (!editMode) {
        alertConfig = new AlertConfig();
      }

      alertConfig.Sensor = sensor;
      alertConfig.Min = min;
      alertConfig.Max = max;
      alertConfig.SoundFile = audioFile;
      if (programStart != null) {
        alertConfig.Action = AlertParameters.ACTION.START_PROGRAM;
        alertConfig.Filename = programStart;
        alertConfig.Arguments = arguments;
      } else {
        alertConfig.Action = AlertParameters.ACTION.STOP_PROCESS;
        alertConfig.Process = processStop;
      }
      list.Add(alertConfig);
      // Add info to Sensor thats it's on an alert
      string alertText = null;
      if (alertConfig.Min != null && alertConfig.Max != null) {
        alertText = " <" + alertConfig.Min + " or >" + alertConfig.Max;
      } else if (alertConfig.Min != null) {
        alertText = "< " + alertConfig.Min;
      } else if (alertConfig.Max != null) {
        alertText = "> " + alertConfig.Max;
      }
      if (alertConfig.Triggered > 0) {
        alertText += " (" + alertConfig.Triggered + ")";
      }
      sensor.Alert = alertText;
      UpdateMainIconVisibilty();

      return alertConfig;
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

      sensor.Alert = null;
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
