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
    public AlertAddForm(MainForm m, ISensor sensor) {
      m_sensor = sensor;
      parent = m;

      InitializeComponent();
    }

    private void portOKButton_Click(object sender, EventArgs e) {
      if (minUpDn.Value >= maxUpDn.Value) {
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        string caption = "Please correct the min/max values";
        MessageBox.Show("Minimum value must be below Maximum", caption, buttons);
        return;
      }
      parent.AlertWatcher.Add(m_sensor, (int)minUpDn.Value, (int)maxUpDn.Value,
        turnOnRadio.Checked ? programFilename.Text : null,
        turnOnRadio.Checked ? programArguments.Text : null,
        turnOffRadio.Checked ? processArguments.Text : null
      );
      this.Close();
    }

    private void portCancelButton_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void PortForm_Load(object sender, EventArgs e) {
      minUpDn.Value = -1;
      maxUpDn.Value = (int)m_sensor.Value+15;
    }

    private void turnOnRadio_CheckedChanged(object sender, EventArgs e) {
      button1.Enabled = true;
      programFilename.Enabled = true;
      programArguments.Enabled = true;
      processArguments.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e) {
      openFileDialog1.ShowDialog();
      string filename = openFileDialog1.FileName;
      programFilename.Text = filename;
    }
    
    private void turnOffRadio_CheckedChanged(object sender, EventArgs e) {
      button1.Enabled = false;
      programFilename.Enabled = false;
      programArguments.Enabled = false;
      processArguments.Enabled = true;
    }
  }
}
