namespace OpenHardwareMonitor.GUI {
  partial class AlertAddForm {
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
			this.portOKButton = new System.Windows.Forms.Button();
			this.portCancelButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.minUpDn = new System.Windows.Forms.NumericUpDown();
			this.maxUpDn = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.turnOnRadio = new System.Windows.Forms.RadioButton();
			this.turnOffRadio = new System.Windows.Forms.RadioButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.programFilename = new System.Windows.Forms.TextBox();
			this.programArguments = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.processArguments = new System.Windows.Forms.TextBox();
			this.test = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.playSound = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.minUpDn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxUpDn)).BeginInit();
			this.SuspendLayout();
			// 
			// portOKButton
			// 
			this.portOKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.portOKButton.Location = new System.Drawing.Point(286, 380);
			this.portOKButton.Name = "portOKButton";
			this.portOKButton.Size = new System.Drawing.Size(75, 33);
			this.portOKButton.TabIndex = 0;
			this.portOKButton.Text = "OK";
			this.portOKButton.UseVisualStyleBackColor = true;
			this.portOKButton.Click += new System.EventHandler(this.portOKButton_Click);
			// 
			// portCancelButton
			// 
			this.portCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.portCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.portCancelButton.Location = new System.Drawing.Point(381, 380);
			this.portCancelButton.Name = "portCancelButton";
			this.portCancelButton.Size = new System.Drawing.Size(75, 33);
			this.portCancelButton.TabIndex = 1;
			this.portCancelButton.Text = "Cancel";
			this.portCancelButton.UseVisualStyleBackColor = true;
			this.portCancelButton.Click += new System.EventHandler(this.portCancelButton_Click);
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
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(570, 180);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 22);
			this.button1.TabIndex = 14;
			this.button1.Text = "Select Program";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			// test
			// 
			this.test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.test.Location = new System.Drawing.Point(154, 381);
			this.test.Name = "test";
			this.test.Size = new System.Drawing.Size(115, 32);
			this.test.TabIndex = 19;
			this.test.Text = "Test Action";
			this.test.UseVisualStyleBackColor = true;
			this.test.Click += new System.EventHandler(this.test_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(382, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(276, 16);
			this.label5.TabIndex = 20;
			this.label5.Text = "a simple name like \"Photoshop\" or \"Chrome\" ";
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(243, 280);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(325, 22);
			this.textBox1.TabIndex = 24;
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(571, 280);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(134, 23);
			this.button3.TabIndex = 23;
			this.button3.Text = "Select File";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click); // FIXME not implemented
			// 
			// button4
			// 
			this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(477, 380);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(115, 33);
			this.button4.TabIndex = 25;
			this.button4.Text = "Remove Alert";
			this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.buttonRemoveAlert_Click);
      // 
      // playSound
      // 
      this.playSound.AutoSize = true;
			this.playSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playSound.Location = new System.Drawing.Point(121, 283);
			this.playSound.Name = "playSound";
			this.playSound.Size = new System.Drawing.Size(94, 20);
			this.playSound.TabIndex = 26;
			this.playSound.Text = "Play sound";
			this.playSound.UseVisualStyleBackColor = true;
			// 
			// AlertAddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.portCancelButton;
			this.ClientSize = new System.Drawing.Size(754, 438);
			this.Controls.Add(this.playSound);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.test);
			this.Controls.Add(this.processArguments);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.programArguments);
			this.Controls.Add(this.programFilename);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.turnOffRadio);
			this.Controls.Add(this.turnOnRadio);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.maxUpDn);
			this.Controls.Add(this.minUpDn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.portCancelButton);
			this.Controls.Add(this.portOKButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AlertAddForm";
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

    private System.Windows.Forms.Button portOKButton;
    private System.Windows.Forms.Button portCancelButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown minUpDn;
    private System.Windows.Forms.NumericUpDown maxUpDn;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.RadioButton turnOnRadio;
    private System.Windows.Forms.RadioButton turnOffRadio;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox programFilename;
    private System.Windows.Forms.TextBox programArguments;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox processArguments;
    private System.Windows.Forms.Button test;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.CheckBox playSound;
  }
}
