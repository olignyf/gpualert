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
			this.portNumericUpDn = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.portNumericUpDn)).BeginInit();
			this.SuspendLayout();
			// 
			// portOKButton
			// 
			this.portOKButton.Location = new System.Drawing.Point(244, 137);
			this.portOKButton.Name = "portOKButton";
			this.portOKButton.Size = new System.Drawing.Size(75, 23);
			this.portOKButton.TabIndex = 0;
			this.portOKButton.Text = "OK";
			this.portOKButton.UseVisualStyleBackColor = true;
			this.portOKButton.Click += new System.EventHandler(this.portOKButton_Click);
			// 
			// portCancelButton
			// 
			this.portCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.portCancelButton.Location = new System.Drawing.Point(162, 137);
			this.portCancelButton.Name = "portCancelButton";
			this.portCancelButton.Size = new System.Drawing.Size(75, 23);
			this.portCancelButton.TabIndex = 1;
			this.portCancelButton.Text = "Cancel";
			this.portCancelButton.UseVisualStyleBackColor = true;
			this.portCancelButton.Click += new System.EventHandler(this.portCancelButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Max Value";
			// 
			// portNumericUpDn
			// 
			this.portNumericUpDn.Location = new System.Drawing.Point(244, 34);
			this.portNumericUpDn.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
			this.portNumericUpDn.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.portNumericUpDn.Name = "portNumericUpDn";
			this.portNumericUpDn.Size = new System.Drawing.Size(75, 20);
			this.portNumericUpDn.TabIndex = 8;
			int initialValue = (int)this.m_sensor.Value;
			this.portNumericUpDn.Value = new decimal(new int[] {
				initialValue,
            0,
            0,
            0});
			this.portNumericUpDn.ValueChanged += new System.EventHandler(this.portNumericUpDn_ValueChanged);
			// 
			// AlertAddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.portCancelButton;
			this.ClientSize = new System.Drawing.Size(466, 170);
			this.Controls.Add(this.portNumericUpDn);
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
			((System.ComponentModel.ISupportInitialize)(this.portNumericUpDn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button portOKButton;
    private System.Windows.Forms.Button portCancelButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown portNumericUpDn;
  }
}
