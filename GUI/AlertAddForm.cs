/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
	Copyright (C) 2022 Francois Oligny-Lemieux <frank.quebec+git@gmail.com>

*/

using System;
using System.Windows.Forms;
using System.Diagnostics;
using OpenHardwareMonitor.Hardware;

namespace OpenHardwareMonitor.GUI {
  public partial class AlertAddForm : Form {
    private MainForm parent;
    private ISensor m_sensor;
    private AlertConfig m_alertConfig;
    public AlertAddForm(MainForm m, ISensor sensor) {
      m_sensor = sensor;
      parent = m;

      InitializeComponent();
    }

    // Used for both add and edit
    public AlertAddForm(MainForm m, ISensor sensor, AlertConfig alertConfig) {
      m_sensor = sensor;
      parent = m;
      m_alertConfig = alertConfig;

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
      maxUpDn.Value = (int)m_sensor.Value + 20;

      if (m_alertConfig != null) {
        if (m_alertConfig.Action == AlertParameters.ACTION.PLAY_SOUND) {

        } else if (m_alertConfig.Action == AlertParameters.ACTION.START_PROGRAM) {
          turnOnRadio.Checked = true;
          programArguments.Text = m_alertConfig.Arguments;
          programFilename.Text = m_alertConfig.Filename;
        } else if (m_alertConfig.Action == AlertParameters.ACTION.STOP_PROCESS) {
          turnOffRadio.Checked = true;
          processArguments.Text = m_alertConfig.Process;
        }
      }
    }

    private void turnOnRadio_CheckedChanged(object sender, EventArgs e) {
      button1.Enabled = true;
      programFilename.Enabled = true;
      programArguments.Enabled = true;
      processArguments.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e) {
      openFileDialog1.Filter = "Executables|*.exe|All Files (*.*)|*.*";
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

    private void test_Click(object sender, EventArgs e) {
      if (turnOnRadio.Checked) {
        // test turn on
        ProcessStartInfo startInfo = new ProcessStartInfo(programFilename.Text);
        startInfo.Arguments = programArguments.Text;
        Process.Start(startInfo);
      } else {
        AlertWatcher.TurnOffProcess(processArguments.Text);
      }
    }

    private void button3_Click(object sender, EventArgs e) {
      
    }

    private void buttonRemoveAlert_Click(object sender, EventArgs e) {
      parent.AlertWatcher.Remove(m_sensor);
    }
  }
}
