/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
	Copyright (C) 2022 Francois Oligny-Lemieux <frank.quebec+git@gmail.com>

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using OpenHardwareMonitor.Hardware;

namespace OpenHardwareMonitor.GUI {
  public partial class AlertAddForm : Form {
    private MainForm parent;
    private ISensor m_sensor;
    private string localIP;
    public AlertAddForm(MainForm m, ISensor sensor) {
      m_sensor = sensor;
      parent = m;
      localIP = getLocalIP();

      InitializeComponent();
    }

    private void portTextBox_TextChanged(object sender, EventArgs e) {

    }

    private string getLocalIP() {
      IPHostEntry host;
      string localIP = "?";
      host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (IPAddress ip in host.AddressList) {
        if (ip.AddressFamily == AddressFamily.InterNetwork) {
          localIP = ip.ToString();
        }
      }
      return localIP;
    }

    private void portNumericUpDn_ValueChanged(object sender, EventArgs e) {
      // unused
    }

    private void portOKButton_Click(object sender, EventArgs e) {
      parent.AlertWatcher.Add(m_sensor, null, (int)portNumericUpDn.Value);
      this.Close();
    }

    private void portCancelButton_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void PortForm_Load(object sender, EventArgs e) {
      // portNumericUpDn.Value = m_sensor.Value;
      portNumericUpDn_ValueChanged(null, null);
    }


  }
}
