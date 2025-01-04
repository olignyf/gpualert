namespace OpenHardwareMonitor.GUI {
  partial class AlertAddEditForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.applyButton = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.minUpDn = new System.Windows.Forms.NumericUpDown();
      this.maxUpDn = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.turnOnRadio = new System.Windows.Forms.RadioButton();
      this.turnOffRadio = new System.Windows.Forms.RadioButton();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.buttonSelectProgram = new System.Windows.Forms.Button();
      this.programFilename = new System.Windows.Forms.TextBox();
      this.programArguments = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.processArguments = new System.Windows.Forms.TextBox();
      this.buttonTestAction = new System.Windows.Forms.Button();
      this.labelProcessOff = new System.Windows.Forms.Label();
      this.textBoxSoundFile = new System.Windows.Forms.TextBox();
      this.buttonSelectSoundFile = new System.Windows.Forms.Button();
      this.removeAlertButton = new System.Windows.Forms.Button();
      this.playSoundCheckbox = new System.Windows.Forms.CheckBox();
      this.labelMin = new System.Windows.Forms.Label();
      this.labelMax = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.minUpDn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxUpDn)).BeginInit();
      this.SuspendLayout();
      // 
      // applyButton
      // 
      this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.applyButton.Location = new System.Drawing.Point(329, 393);
      this.applyButton.Name = "applyButton";
      this.applyButton.Size = new System.Drawing.Size(136, 33);
      this.applyButton.TabIndex = 0;
      this.applyButton.Text = "Save";
      this.applyButton.UseVisualStyleBackColor = true;
      this.applyButton.Click += new System.EventHandler(this.portOKButton_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCancel.Location = new System.Drawing.Point(630, 393);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(112, 33);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.portCancelButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(34, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "Min Value";
      // 
      // minUpDn
      // 
      this.minUpDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.minUpDn.Location = new System.Drawing.Point(118, 34);
      this.minUpDn.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
      this.minUpDn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
      this.minUpDn.Name = "minUpDn";
      this.minUpDn.Size = new System.Drawing.Size(75, 22);
      this.minUpDn.TabIndex = 8;
      // 
      // maxUpDn
      // 
      this.maxUpDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.maxUpDn.Location = new System.Drawing.Point(118, 75);
      this.maxUpDn.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
      this.maxUpDn.Name = "maxUpDn";
      this.maxUpDn.Size = new System.Drawing.Size(75, 22);
      this.maxUpDn.TabIndex = 9;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(31, 77);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(71, 16);
      this.label1.TabIndex = 10;
      this.label1.Text = "Max Value";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(42, 118);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 16);
      this.label3.TabIndex = 11;
      this.label3.Text = "Action(s)";
      // 
      // turnOnRadio
      // 
      this.turnOnRadio.AutoSize = true;
      this.turnOnRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.turnOnRadio.Location = new System.Drawing.Point(118, 180);
      this.turnOnRadio.Name = "turnOnRadio";
      this.turnOnRadio.Size = new System.Drawing.Size(125, 20);
      this.turnOnRadio.TabIndex = 12;
      this.turnOnRadio.Text = "Turn on program";
      this.turnOnRadio.UseVisualStyleBackColor = true;
      this.turnOnRadio.CheckedChanged += new System.EventHandler(this.turnOnRadio_CheckedChanged);
      // 
      // turnOffRadio
      // 
      this.turnOffRadio.AutoSize = true;
      this.turnOffRadio.Checked = true;
      this.turnOffRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.turnOffRadio.Location = new System.Drawing.Point(118, 117);
      this.turnOffRadio.Name = "turnOffRadio";
      this.turnOffRadio.Size = new System.Drawing.Size(122, 20);
      this.turnOffRadio.TabIndex = 13;
      this.turnOffRadio.TabStop = true;
      this.turnOffRadio.Text = "Turn off process";
      this.turnOffRadio.UseVisualStyleBackColor = true;
      this.turnOffRadio.CheckedChanged += new System.EventHandler(this.turnOffRadio_CheckedChanged);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // buttonSelectProgram
      // 
      this.buttonSelectProgram.Enabled = false;
      this.buttonSelectProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSelectProgram.Location = new System.Drawing.Point(570, 178);
      this.buttonSelectProgram.Name = "buttonSelectProgram";
      this.buttonSelectProgram.Size = new System.Drawing.Size(134, 26);
      this.buttonSelectProgram.TabIndex = 14;
      this.buttonSelectProgram.Text = "Select Program";
      this.buttonSelectProgram.UseVisualStyleBackColor = true;
      this.buttonSelectProgram.Click += new System.EventHandler(this.button1_Click);
      // 
      // programFilename
      // 
      this.programFilename.Enabled = false;
      this.programFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.programFilename.Location = new System.Drawing.Point(243, 180);
      this.programFilename.Name = "programFilename";
      this.programFilename.Size = new System.Drawing.Size(325, 22);
      this.programFilename.TabIndex = 15;
      // 
      // programArguments
      // 
      this.programArguments.Enabled = false;
      this.programArguments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.programArguments.Location = new System.Drawing.Point(243, 210);
      this.programArguments.Name = "programArguments";
      this.programArguments.Size = new System.Drawing.Size(325, 22);
      this.programArguments.TabIndex = 16;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(164, 212);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(72, 16);
      this.label4.TabIndex = 17;
      this.label4.Text = "Arguments";
      // 
      // processArguments
      // 
      this.processArguments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.processArguments.Location = new System.Drawing.Point(241, 117);
      this.processArguments.Name = "processArguments";
      this.processArguments.Size = new System.Drawing.Size(135, 22);
      this.processArguments.TabIndex = 18;
      // 
      // buttonTestAction
      // 
      this.buttonTestAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonTestAction.Location = new System.Drawing.Point(121, 329);
      this.buttonTestAction.Name = "buttonTestAction";
      this.buttonTestAction.Size = new System.Drawing.Size(115, 32);
      this.buttonTestAction.TabIndex = 19;
      this.buttonTestAction.Text = "Test Action";
      this.buttonTestAction.UseVisualStyleBackColor = true;
      this.buttonTestAction.Click += new System.EventHandler(this.test_Click);
      // 
      // labelProcessOff
      // 
      this.labelProcessOff.AutoSize = true;
      this.labelProcessOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelProcessOff.Location = new System.Drawing.Point(382, 120);
      this.labelProcessOff.Name = "labelProcessOff";
      this.labelProcessOff.Size = new System.Drawing.Size(276, 16);
      this.labelProcessOff.TabIndex = 20;
      this.labelProcessOff.Text = "a simple name like \"Photoshop\" or \"Chrome\" ";
      // 
      // textBoxSoundFile
      // 
      this.textBoxSoundFile.Enabled = false;
      this.textBoxSoundFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxSoundFile.Location = new System.Drawing.Point(243, 280);
      this.textBoxSoundFile.Name = "textBoxSoundFile";
      this.textBoxSoundFile.Size = new System.Drawing.Size(325, 22);
      this.textBoxSoundFile.TabIndex = 24;
      // 
      // buttonSelectSoundFile
      // 
      this.buttonSelectSoundFile.Enabled = false;
      this.buttonSelectSoundFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSelectSoundFile.Location = new System.Drawing.Point(571, 278);
      this.buttonSelectSoundFile.Name = "buttonSelectSoundFile";
      this.buttonSelectSoundFile.Size = new System.Drawing.Size(134, 26);
      this.buttonSelectSoundFile.TabIndex = 23;
      this.buttonSelectSoundFile.Text = "Select Audio File";
      this.buttonSelectSoundFile.UseVisualStyleBackColor = true;
      this.buttonSelectSoundFile.Click += new System.EventHandler(this.buttonSelectSoundFile_Click);
      // 
      // removeAlertButton
      // 
      this.removeAlertButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.removeAlertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.removeAlertButton.Location = new System.Drawing.Point(22, 393);
      this.removeAlertButton.Name = "removeAlertButton";
      this.removeAlertButton.Size = new System.Drawing.Size(143, 33);
      this.removeAlertButton.TabIndex = 25;
      this.removeAlertButton.Text = "Remove Alert";
      this.removeAlertButton.UseVisualStyleBackColor = true;
      this.removeAlertButton.Click += new System.EventHandler(this.buttonRemoveAlert_Click);
      // 
      // playSoundCheckbox
      // 
      this.playSoundCheckbox.AutoSize = true;
      this.playSoundCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.playSoundCheckbox.Location = new System.Drawing.Point(121, 283);
      this.playSoundCheckbox.Name = "playSoundCheckbox";
      this.playSoundCheckbox.Size = new System.Drawing.Size(94, 20);
      this.playSoundCheckbox.TabIndex = 26;
      this.playSoundCheckbox.Text = "Play sound";
      this.playSoundCheckbox.UseVisualStyleBackColor = true;
      this.playSoundCheckbox.Click += new System.EventHandler(this.playSound_Click);
      // 
      // labelMin
      // 
      this.labelMin.AutoSize = true;
      this.labelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelMin.Location = new System.Drawing.Point(199, 38);
      this.labelMin.Name = "labelMin";
      this.labelMin.Size = new System.Drawing.Size(170, 13);
      this.labelMin.TabIndex = 27;
      this.labelMin.Text = "leave empty for no minimum check";
      // 
      // labelMax
      // 
      this.labelMax.AutoSize = true;
      this.labelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelMax.Location = new System.Drawing.Point(199, 80);
      this.labelMax.Name = "labelMax";
      this.labelMax.Size = new System.Drawing.Size(170, 13);
      this.labelMax.TabIndex = 28;
      this.labelMax.Text = "leave empty for no minimum check";
      // 
      // AlertAddEditForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(754, 438);
      this.Controls.Add(this.labelMax);
      this.Controls.Add(this.labelMin);
      this.Controls.Add(this.playSoundCheckbox);
      this.Controls.Add(this.removeAlertButton);
      this.Controls.Add(this.textBoxSoundFile);
      this.Controls.Add(this.buttonSelectSoundFile);
      this.Controls.Add(this.labelProcessOff);
      this.Controls.Add(this.buttonTestAction);
      this.Controls.Add(this.processArguments);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.programArguments);
      this.Controls.Add(this.programFilename);
      this.Controls.Add(this.buttonSelectProgram);
      this.Controls.Add(this.turnOffRadio);
      this.Controls.Add(this.turnOnRadio);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.maxUpDn);
      this.Controls.Add(this.minUpDn);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.applyButton);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AlertAddEditForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add Alert";
      this.Load += new System.EventHandler(this.PortForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.minUpDn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxUpDn)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

    private System.Windows.Forms.Button applyButton;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown minUpDn;
    private System.Windows.Forms.NumericUpDown maxUpDn;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RadioButton turnOnRadio;
    private System.Windows.Forms.RadioButton turnOffRadio;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button buttonSelectProgram;
    private System.Windows.Forms.TextBox programFilename;
    private System.Windows.Forms.TextBox programArguments;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox processArguments;
    private System.Windows.Forms.Button buttonTestAction;
    private System.Windows.Forms.Label labelProcessOff;
    private System.Windows.Forms.TextBox textBoxSoundFile;
    private System.Windows.Forms.Button buttonSelectSoundFile;
    private System.Windows.Forms.Button removeAlertButton;
    private System.Windows.Forms.CheckBox playSoundCheckbox;
    private System.Windows.Forms.Label labelMin;
    private System.Windows.Forms.Label labelMax;
  }
}
