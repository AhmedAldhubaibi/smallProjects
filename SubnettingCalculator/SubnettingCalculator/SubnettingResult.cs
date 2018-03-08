using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SubnettingCalculator
{
    public partial class SubnettingResult : MetroFramework.Forms.MetroForm
    {
        public SubnettingResult(string ipAddress, string subnetMask, string cidrNotation, 
                                string networkIpAddress, string broadcastAddress, string shortIpAdderss, 
                                string ipClass, string binaryIpAddress, string binarySubnetMask, 
                                string usableHostIpRange, string numberOfHosts, string numberOfUsableHosts, 
                                string numberOfSubnets, string totalHosts, DataTable allHostsInEverySubnet)
        {
            InitializeComponent();
            lblIpAddress.Text = ipAddress;
            lblSubnetMask.Text = subnetMask;
            lblNetworkAddress.Text = networkIpAddress;
            lblCidrNotation.Text = cidrNotation;
            lblBroadcastAddress.Text = broadcastAddress;
            lblShort.Text = shortIpAdderss;
            lblIpClass.Text = ipClass;
            lblIpAddressBinary.Text = binaryIpAddress;
            lblSubnetMaskBinary.Text = binarySubnetMask;
            lblHostRange.Text = usableHostIpRange;
            lblNumberOfHosts.Text = numberOfHosts;
            lblNumberOfUsableHosts.Text = numberOfUsableHosts;
            lblNumberOfSubnets.Text = numberOfSubnets;
            lblTotalHosts.Text = totalHosts;

            dataGridView.DataSource = allHostsInEverySubnet;
            dataGridView.Columns[0].Width = 111;
            dataGridView.Columns[1].Width = 175;
            dataGridView.Columns[2].Width = 111;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void SubnettingResult_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var textSize = TextRenderer.MeasureText(rowIdx, Font);
            if (dataGrid != null && dataGrid.RowHeadersWidth < textSize.Width + 40)
            {
                dataGrid.RowHeadersWidth = textSize.Width + 40;
            }
            if (dataGrid == null) return;
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGrid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
