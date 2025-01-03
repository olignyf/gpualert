/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2010 Paul Werelds <paul@werelds.net>
	
*/

using System.Management.Instrumentation;
using OpenHardwareMonitor.Hardware;

namespace OpenHardwareMonitor.WMI {
  [InstrumentationClass(InstrumentationType.Instance)]
  public class Sensor : IWmiObject {
    private ISensor sensor;

    #region WMI Exposed

    public string SensorType { get; private set; }
    public string Identifier { get; private set; }
    public string Parent { get; private set; }
    public string Name { get; private set; }
    public float Value { get; private set; }
    public float Min { get; private set; }
    public float Max { get; private set; }
    public string Alert { get; private set; }
    public int AlertTriggered { get; private set; }
    public int Index { get; private set; }

    #endregion

    public Sensor(ISensor sensor) {
      Name = sensor.Name;
      Index = sensor.Index;

      SensorType = sensor.SensorType.ToString();
      Identifier = sensor.Identifier.ToString();
      Parent = sensor.Hardware.Identifier.ToString();

      this.sensor = sensor;
    }

    //TODO: Document what is the purpuse of this
    public void Update() {
      Value = (sensor.Value != null) ? (float)sensor.Value : 0;
      
      if (sensor.Min != null)
        Min = (float)sensor.Min;

      if (sensor.Max != null)
        Max = (float)sensor.Max;

      Max = 1;
      if (sensor.Alert != Alert || sensor.Triggered != AlertTriggered) {
        Alert = sensor.Alert;
        AlertTriggered = sensor.Triggered;
        if (sensor.Triggered > 0) {
          Alert = Alert + " (" + sensor.Triggered + ")";
        }
      }

    }
  }
}
