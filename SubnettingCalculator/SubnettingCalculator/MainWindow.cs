using System;
using System.Net;
using System.Windows.Forms;

namespace SubnettingCalculator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var checkIpAddress = txtIPAddress.Text.Split('.');
                if (string.IsNullOrEmpty(txtIPAddress.Text) || string.IsNullOrEmpty(cmbNetMask.Text) || checkIpAddress.Length < 4)
                {
                    MessageBox.Show(Constants.NullErrorText, Constants.Error, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                var tmpMaskAddress = cmbNetMask.Text.Split(Constants.SlashSpliter);
                var ipAddress = txtIPAddress.Text;
                var subnetMask = tmpMaskAddress[Constants.FirstPartIpIndex];
                var cidrNotation = $"{Constants.SlashSpliter}{tmpMaskAddress[Constants.SecondPartIpIndex]}";
                var networkIpAddress = IpService.GetNetworkIpAddress(IPAddress.Parse(ipAddress), IPAddress.Parse(tmpMaskAddress[0])).ToString();
                var broadcastAddress = IpService.GetBroadcastIpAddress(IPAddress.Parse(txtIPAddress.Text), IPAddress.Parse(tmpMaskAddress[0])).ToString();
                var shortIpAdderss = $"{txtIPAddress.Text} {Constants.SlashSpliter}{tmpMaskAddress[1]}";
                var ipClass = IpService.GetIpAddressClass(txtIPAddress.Text);
                var binaryIpAddress = IpService.ConvertDecimalToBinary(txtIPAddress.Text);
                var binarySubnetMask = IpService.ConvertDecimalToBinary(tmpMaskAddress[Constants.FirstPartIpIndex]);
                var startIpAddress = IpService.GetRangStartIpAddresses(IPAddress.Parse(ipAddress), IPAddress.Parse(subnetMask));
                var endIpAddress = IpService.GetRangEndIpAddresses(IPAddress.Parse(ipAddress), IPAddress.Parse(subnetMask));
                var usableHostIpRange = $"{startIpAddress} {Constants.HyphenSpliter} {endIpAddress}";
                var numberOfHosts = IpService.GetNumberOfHosts(int.Parse(tmpMaskAddress[Constants.SecondPartIpIndex]));
                var numberOfUsableHosts = double.Parse(numberOfHosts) <= 2 ? 0 : double.Parse(numberOfHosts) - 2;
                var numberOfSubnets = IpService.GetnumberOfSubnets(int.Parse(tmpMaskAddress[Constants.SecondPartIpIndex]));
                var totalUsableHosts = Math.Abs(double.Parse(numberOfSubnets)) > 0 && Math.Abs(numberOfUsableHosts) > 0 ? double.Parse(numberOfSubnets) * numberOfUsableHosts : 0;
                var allHostsInEverySubnet = int.Parse(numberOfSubnets) != 0 ? IpService.GetAllPossibleHostsInEverySubnet(int.Parse(tmpMaskAddress[1]), int.Parse(numberOfSubnets), int.Parse(numberOfHosts), networkIpAddress, broadcastAddress, startIpAddress, endIpAddress) : null;
                var subnettingResult = new SubnettingResult(ipAddress, subnetMask, cidrNotation, networkIpAddress, broadcastAddress,
                    shortIpAdderss, ipClass, binaryIpAddress, binarySubnetMask, usableHostIpRange,
                    numberOfHosts, numberOfUsableHosts.ToString(), numberOfSubnets, totalUsableHosts.ToString(), allHostsInEverySubnet);
                subnettingResult.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Constants.Error, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                throw;
            }
            
        }

        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            if (!char.IsDigit(c) && !char.IsControl(c) && c != Constants.DotSpliter)
            {
                e.Handled = true;
            }
        }

        private void cmbNetMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }
    }
}
