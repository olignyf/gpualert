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
			((System.ComponentModel.ISupportInitialize)(this.minUpDn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxUpDn)).BeginInit();
			this.SuspendLayout();
			// 
			// portOKButton
			// 
			this.portOKButton.Location = new System.Drawing.Point(239, 230);
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
			this.portCancelButton.Location = new System.Drawing.Point(157, 230);
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
			this.label2.Location = new System.Drawing.Point(60, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Min Value";
			// 
			// minUpDn
			// 
			this.minUpDn.Location = new System.Drawing.Point(131, 34);
      this.minUpDn.Minimum = -1;
      this.minUpDn.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
			this.minUpDn.Name = "minUpDn";
			this.minUpDn.Size = new System.Drawing.Size(75, 20);
			this.minUpDn.TabIndex = 8;
			this.minUpDn.ValueChanged += new System.EventHandler(this.portNumericUpDn_ValueChanged);
			// 
			// maxUpDn
			// 
			this.maxUpDn.Location = new System.Drawing.Point(131, 75);
      this.maxUpDn.Minimum = 0;
      this.maxUpDn.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
			this.maxUpDn.Name = "maxUpDn";
			this.maxUpDn.Size = new System.Drawing.Size(75, 20);
			this.maxUpDn.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Max Value";
			// 
			// AlertAddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.portCancelButton;
			this.ClientSize = new System.Drawing.Size(473, 278);
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
  }
}
