/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
	Copyright (C) 2022-2025 Francois Oligny-Lemieux <frank.quebec+git@gmail.com>

*/

using System;
using System.Windows.Forms;
using System.Diagnostics;
using OpenHardwareMonitor.Hardware;

namespace OpenHardwareMonitor.GUI {

  public partial class AlertAddEditForm : Form {
    private MainForm m_parent;
    private ISensor m_sensor;
    private AlertConfig m_alertConfig;

    public AlertAddEditForm(MainForm m, ISensor sensor) {
      m_sensor = sensor;
      m_parent = m;

      InitializeComponent();
    }

    // Used for both add and edit
    public AlertAddEditForm(MainForm m, ISensor sensor, AlertConfig alertConfig) {
      m_sensor = sensor;
      m_parent = m;
      m_alertConfig = alertConfig; // this trigger Edit mode if non-null

      InitializeComponent();
    }

    private void portOKButton_Click(object sender, EventArgs e) {
      if (minUpDn.Value >= maxUpDn.Value) {
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        string caption = "Please correct the min/max values";
        MessageBox.Show("Minimum value must be below Maximum", caption, buttons);
        return;
      }
      m_parent.AlertWatcher.Add(m_sensor, minUpDn, maxUpDn,
        turnOnRadio.Checked ? programFilename.Text : null,
        turnOnRadio.Checked ? programArguments.Text : null,
        turnOffRadio.Checked ? processArguments.Text : null,
        playSoundCheckbox.Checked ? textBoxSoundFile.Text : null
      );
      this.Close();
    }

    private void portCancelButton_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void PortForm_Load(object sender, EventArgs e) {
      minUpDn.Text = ""; // empty string == no minimum
      maxUpDn.Value = (int)m_sensor.Value + 20;

      if (m_alertConfig != null) {
        if (m_alertConfig.Min != null)
          minUpDn.Value = m_alertConfig.Min.Value;
        if (m_alertConfig.Max != null)
          maxUpDn.Value = m_alertConfig.Max.Value;

        if (m_alertConfig.SoundFile != null && m_alertConfig.SoundFile != "") {
          textBoxSoundFile.Text = m_alertConfig.SoundFile;
          textBoxSoundFile.Enabled = true;
          playSoundCheckbox.Checked = true;
        }

        if (m_alertConfig.Action == AlertParameters.ACTION.START_PROGRAM) {
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

    private void playSound_Click(object sender, System.EventArgs e) {
      if (playSoundCheckbox.Checked) {
        textBoxSoundFile.Enabled = true;
        buttonSelectSoundFile.Enabled = true;
      }
      else {
        textBoxSoundFile.Enabled = false;
        buttonSelectSoundFile.Enabled = false;
      }
    }

    // Sound file
    private void buttonSelectSoundFile_Click(object sender, EventArgs e) {
      openFileDialog1.Filter = "Audio Files|*.wav;*.mp3|All Files (*.*)|*.*";
      openFileDialog1.ShowDialog();
      string filename = openFileDialog1.FileName;
      textBoxSoundFile.Text = filename;
    }


    private void buttonRemoveAlert_Click(object sender, EventArgs e) {
      m_parent.AlertWatcher.Remove(m_sensor);
    }
  }
}
