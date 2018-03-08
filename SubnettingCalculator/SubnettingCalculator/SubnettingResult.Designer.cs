namespace SubnettingCalculator
{
    partial class SubnettingResult
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIpAddressBinary = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblShort = new System.Windows.Forms.Label();
            this.lblHostRange = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBroadcastAddress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNumberOfHosts = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNumberOfUsableHosts = new System.Windows.Forms.Label();
            this.lblNumberOfSubnets = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblNetworkAddress = new System.Windows.Forms.Label();
            this.lblSubnetMask = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSubnetMaskBinary = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblCidrNotation = new System.Windows.Forms.Label();
            this.lblIpClass = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalHosts = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.Location = new System.Drawing.Point(469, 84);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(481, 406);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(568, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "All Possible Hosts for the Subnets";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddress.Location = new System.Drawing.Point(196, 16);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(0, 15);
            this.lblIpAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Short:";
            // 
            // lblIpAddressBinary
            // 
            this.lblIpAddressBinary.AutoSize = true;
            this.lblIpAddressBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAddressBinary.Location = new System.Drawing.Point(196, 43);
            this.lblIpAddressBinary.Name = "lblIpAddressBinary";
            this.lblIpAddressBinary.Size = new System.Drawing.Size(0, 15);
            this.lblIpAddressBinary.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Usable Host IP Range:";
            // 
            // lblShort
            // 
            this.lblShort.AutoSize = true;
            this.lblShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShort.Location = new System.Drawing.Point(197, 184);
            this.lblShort.Name = "lblShort";
            this.lblShort.Size = new System.Drawing.Size(0, 15);
            this.lblShort.TabIndex = 1;
            // 
            // lblHostRange
            // 
            this.lblHostRange.AutoSize = true;
            this.lblHostRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostRange.Location = new System.Drawing.Point(197, 242);
            this.lblHostRange.Name = "lblHostRange";
            this.lblHostRange.Size = new System.Drawing.Size(0, 15);
            this.lblHostRange.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Broadcast Address:";
            // 
            // lblBroadcastAddress
            // 
            this.lblBroadcastAddress.AutoSize = true;
            this.lblBroadcastAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBroadcastAddress.Location = new System.Drawing.Point(197, 268);
            this.lblBroadcastAddress.Name = "lblBroadcastAddress";
            this.lblBroadcastAddress.Size = new System.Drawing.Size(0, 15);
            this.lblBroadcastAddress.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Number of Hosts per Subnet:";
            // 
            // lblNumberOfHosts
            // 
            this.lblNumberOfHosts.AutoSize = true;
            this.lblNumberOfHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfHosts.Location = new System.Drawing.Point(197, 295);
            this.lblNumberOfHosts.Name = "lblNumberOfHosts";
            this.lblNumberOfHosts.Size = new System.Drawing.Size(0, 15);
            this.lblNumberOfHosts.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Number of Usable Hosts:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Number of Subnets:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Network Address";
            // 
            // lblNumberOfUsableHosts
            // 
            this.lblNumberOfUsableHosts.AutoSize = true;
            this.lblNumberOfUsableHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfUsableHosts.Location = new System.Drawing.Point(197, 324);
            this.lblNumberOfUsableHosts.Name = "lblNumberOfUsableHosts";
            this.lblNumberOfUsableHosts.Size = new System.Drawing.Size(0, 15);
            this.lblNumberOfUsableHosts.TabIndex = 1;
            // 
            // lblNumberOfSubnets
            // 
            this.lblNumberOfSubnets.AutoSize = true;
            this.lblNumberOfSubnets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfSubnets.Location = new System.Drawing.Point(197, 349);
            this.lblNumberOfSubnets.Name = "lblNumberOfSubnets";
            this.lblNumberOfSubnets.Size = new System.Drawing.Size(0, 15);
            this.lblNumberOfSubnets.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Subnet Mask:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Subnet Mask Binary:";
            // 
            // lblNetworkAddress
            // 
            this.lblNetworkAddress.AutoSize = true;
            this.lblNetworkAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkAddress.Location = new System.Drawing.Point(195, 125);
            this.lblNetworkAddress.Name = "lblNetworkAddress";
            this.lblNetworkAddress.Size = new System.Drawing.Size(0, 15);
            this.lblNetworkAddress.TabIndex = 1;
            // 
            // lblSubnetMask
            // 
            this.lblSubnetMask.AutoSize = true;
            this.lblSubnetMask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubnetMask.Location = new System.Drawing.Point(196, 69);
            this.lblSubnetMask.Name = "lblSubnetMask";
            this.lblSubnetMask.Size = new System.Drawing.Size(0, 15);
            this.lblSubnetMask.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(11, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "IP Address Binary:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(11, 212);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "IP Class:";
            // 
            // lblSubnetMaskBinary
            // 
            this.lblSubnetMaskBinary.AutoSize = true;
            this.lblSubnetMaskBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubnetMaskBinary.Location = new System.Drawing.Point(197, 97);
            this.lblSubnetMaskBinary.Name = "lblSubnetMaskBinary";
            this.lblSubnetMaskBinary.Size = new System.Drawing.Size(0, 15);
            this.lblSubnetMaskBinary.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(11, 155);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "CIDR Notation:";
            // 
            // lblCidrNotation
            // 
            this.lblCidrNotation.AutoSize = true;
            this.lblCidrNotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCidrNotation.Location = new System.Drawing.Point(197, 155);
            this.lblCidrNotation.Name = "lblCidrNotation";
            this.lblCidrNotation.Size = new System.Drawing.Size(0, 15);
            this.lblCidrNotation.TabIndex = 1;
            // 
            // lblIpClass
            // 
            this.lblIpClass.AutoSize = true;
            this.lblIpClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpClass.Location = new System.Drawing.Point(197, 212);
            this.lblIpClass.Name = "lblIpClass";
            this.lblIpClass.Size = new System.Drawing.Size(0, 15);
            this.lblIpClass.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblIpClass);
            this.panel1.Controls.Add(this.lblCidrNotation);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.lblSubnetMaskBinary);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.lblSubnetMask);
            this.panel1.Controls.Add(this.lblNetworkAddress);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNumberOfSubnets);
            this.panel1.Controls.Add(this.lblNumberOfUsableHosts);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblNumberOfHosts);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblBroadcastAddress);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblHostRange);
            this.panel1.Controls.Add(this.lblShort);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblIpAddressBinary);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTotalHosts);
            this.panel1.Controls.Add(this.lblIpAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 406);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Total Usable Hosts:";
            // 
            // lblTotalHosts
            // 
            this.lblTotalHosts.AutoSize = true;
            this.lblTotalHosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHosts.Location = new System.Drawing.Point(197, 375);
            this.lblTotalHosts.Name = "lblTotalHosts";
            this.lblTotalHosts.Size = new System.Drawing.Size(0, 15);
            this.lblTotalHosts.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(771, 502);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Created by: Ahmed Al-Dhubaibi 2018";
            // 
            // SubnettingResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(975, 522);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "SubnettingResult";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Subnetting Result";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SubnettingResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIpAddressBinary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShort;
        private System.Windows.Forms.Label lblHostRange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBroadcastAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNumberOfHosts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNumberOfUsableHosts;
        private System.Windows.Forms.Label lblNumberOfSubnets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblNetworkAddress;
        private System.Windows.Forms.Label lblSubnetMask;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSubnetMaskBinary;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblCidrNotation;
        private System.Windows.Forms.Label lblIpClass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalHosts;
        private System.Windows.Forms.Label label10;
    }
}