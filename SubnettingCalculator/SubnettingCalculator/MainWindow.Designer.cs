namespace SubnettingCalculator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.cmbNetMask = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIPAddress.Location = new System.Drawing.Point(103, 15);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(183, 20);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIPAddress_KeyPress);
            // 
            // cmbNetMask
            // 
            this.cmbNetMask.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbNetMask.FormattingEnabled = true;
            this.cmbNetMask.Items.AddRange(new object[] {
            "255.255.255.254/31",
            "255.255.255.252/30",
            "255.255.255.248/29",
            "255.255.255.240/28",
            "255.255.255.224/27",
            "255.255.255.192/26",
            "255.255.255.128/25",
            "255.255.255.0/24",
            "255.255.254.0/23",
            "255.255.252.0/22",
            "255.255.248.0/21",
            "255.255.240.0/20",
            "255.255.224.0/19",
            "255.255.192.0/18",
            "255.255.128.0/17",
            "255.255.0.0/16",
            "255.254.0.0/15",
            "255.252.0.0/14",
            "255.248.0.0/13",
            "255.240.0.0/12",
            "255.224.0.0/11",
            "255.192.0.0/10",
            "255.128.0.0/9",
            "255.0.0.0/8",
            "254.0.0.0/7",
            "252.0.0.0/6",
            "248.0.0.0/5",
            "240.0.0.0/4",
            "224.0.0.0/3",
            "192.0.0.0/2",
            "128.0.0.0/1"});
            this.cmbNetMask.Location = new System.Drawing.Point(103, 41);
            this.cmbNetMask.Name = "cmbNetMask";
            this.cmbNetMask.Size = new System.Drawing.Size(183, 21);
            this.cmbNetMask.TabIndex = 1;
            this.cmbNetMask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbNetMask_KeyPress);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCalculate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCalculate.Location = new System.Drawing.Point(103, 82);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(183, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subnet Mask";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(308, 124);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.cmbNetMask);
            this.Controls.Add(this.txtIPAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subnetting Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.ComboBox cmbNetMask;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

