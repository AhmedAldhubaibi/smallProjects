using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Text;

namespace SubnettingCalculator
{
    public static class IpService
    {
        public static IPAddress GetBroadcastIpAddress(IPAddress ipAddress, IPAddress subnetMask)
        {
            var ipAdressBytes = ipAddress.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException(Constants.LengthErrorText);

            var broadcastAddress = new byte[ipAdressBytes.Length];
            for (var i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ Constants.FullBits));
            }
            return new IPAddress(broadcastAddress);
        }

        public static IPAddress GetNetworkIpAddress(IPAddress ipAddress, IPAddress subnetMask)
        {
            var ipAdressBytes = ipAddress.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException(Constants.LengthErrorText);

            var networkIpAddress = new byte[ipAdressBytes.Length];
            for (var i = 0; i < networkIpAddress.Length; i++)
            {
                networkIpAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            return new IPAddress(networkIpAddress);
        }

        public static string GetRangStartIpAddresses(IPAddress ipAddress, IPAddress subnetMask)
        {
            var ipAdressBytes = ipAddress.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException(Constants.LengthErrorText);

            var rangeStartIpAddress = new byte[ipAdressBytes.Length];
            for (var i = 0; i < rangeStartIpAddress.Length; i++)
            {
                rangeStartIpAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            var tmpStartIPstring = rangeStartIpAddress[Constants.LastPartIpIndex].ToString();
            var tmpStartIPint = int.Parse(tmpStartIPstring) + Constants.OneDecimal;
            rangeStartIpAddress[Constants.LastPartIpIndex] = (byte)tmpStartIPint;
            return new IPAddress(rangeStartIpAddress).ToString();
        }

        public static string GetRangEndIpAddresses(IPAddress ipAddress, IPAddress subnetMask)
        {
            var ipAdressBytes = ipAddress.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException(Constants.LengthErrorText);

            var rangeEndIpAddress = new byte[ipAdressBytes.Length];
            for (var i = 0; i < rangeEndIpAddress.Length; i++)
            {
                rangeEndIpAddress[i] = (byte)(ipAdressBytes[i] | ~subnetMaskBytes[i]);
            }
            var tmpEndIPstring = rangeEndIpAddress[Constants.LastPartIpIndex].ToString();
            var tmpEndIPint = int.Parse(tmpEndIPstring) - Constants.OneDecimal;
            rangeEndIpAddress[Constants.LastPartIpIndex] = (byte)tmpEndIPint;
            return new IPAddress(rangeEndIpAddress).ToString();
        }

        public static string GetNumberOfHosts(int netmaskNumeric)
        {
            double result = Constants.OneDecimal;
            const int value = Constants.TwoDecimal;
            var host = Constants.ThirtyTwoDecimal - netmaskNumeric;
            if (host == Constants.Zero) return result.ToString(CultureInfo.InvariantCulture);
            for (var power = Constants.OneDecimal; power <= host; power++)
                result = Math.Pow(value, power);
            return result.ToString(CultureInfo.InvariantCulture);
        }

        public static string ConvertDecimalToBinary(string ipAddress)
        {
            var ipParts = ipAddress.Split(Constants.DotSpliter);
            var builder = new StringBuilder();

            foreach (var part in ipParts)
            {
                var dec = int.Parse(part);
                var bin = Convert.ToString(dec, Constants.TwoDecimal)
                    .PadLeft(Constants.EightDecimal, Constants.ZeroChar);

                builder.Append($"{bin}{Constants.DotSpliter}");
            }

            return builder.ToString().TrimEnd(Constants.DotSpliter);
        }

        public static string GetnumberOfSubnets(int cidrNotation)
        {
            var result = Constants.Zero;
            const int value = Constants.TwoDecimal;
            if (cidrNotation >= Constants.EightDecimal)
            {
                cidrNotation = cidrNotation - Constants.EightDecimal;
                if (cidrNotation >= Constants.EightDecimal)
                {
                    return GetnumberOfSubnets(cidrNotation);
                }
            }
            for (var power = 0; power <= cidrNotation; power++)
                result = (int)Math.Pow(value, power);
            if (result == Constants.OneDecimal)
            {
                result = Constants.OneDecimal;
            }
            return result.ToString();
        }

        public static DataTable GetAllPossibleHostsInEverySubnet(int cidr, int numberOfSubnets, int numberOfHosts, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress)
        {
            var datatable = new DataTable();
            datatable.Columns.Add(Constants.NetworkAddressColumn, typeof(string));
            datatable.Columns.Add(Constants.UsableHostRangeColumn, typeof(string));
            datatable.Columns.Add(Constants.BroadcastAddressColumn, typeof(string));

            if (cidr >= Constants.Cidr24)
            {
                GetRangeFirstCategory(numberOfSubnets, numberOfHosts, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, datatable);
            }

            if (cidr <= Constants.Cidr23 & cidr >= Constants.Cidr16)
            {
                GetRangeSecondCategory(cidr, numberOfSubnets, numberOfHosts / Constants.TwoToThe8, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, datatable);
            }

            if (cidr <= Constants.Cidr15 & cidr >= Constants.Cidr8)
            {
                GetRangeThirdCategory(cidr, numberOfSubnets, numberOfHosts / Constants.TwoToThe16, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, datatable);
            }

            if (cidr <= Constants.Cidr7)
            {
                GetRangeFourthCategory(cidr, numberOfSubnets, numberOfHosts / Constants.TwoToThe24, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, datatable);
            }

            return datatable;
        }

        private static void GetRangeFirstCategory(int numberOfSubnets, int numberOfHosts, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, DataTable datatable)
        {
            var ipNetworkPart = Constants.Zero;
            var iPBroadcastPart = numberOfHosts;
            var lastPartFirstIp = numberOfHosts;
            var lastPartLastIp = numberOfHosts;


            for (var i = 0; i < numberOfSubnets; i++)
            {
                var row = datatable.NewRow();
                if (i == 0)
                {
                    row[Constants.NetworkAddressColumn] = networkIpAddress;
                    row[Constants.UsableHostRangeColumn] = $"{startIpAddress} {Constants.HyphenSpliter} {endIpAddress}";
                    row[Constants.BroadcastAddressColumn] = broadcastAddress;
                    datatable.Rows.Add(row);
                    ipNetworkPart = numberOfHosts;
                    lastPartFirstIp = lastPartFirstIp + Constants.OneDecimal;
                    lastPartLastIp = lastPartLastIp - Constants.TwoDecimal;
                    iPBroadcastPart = iPBroadcastPart + numberOfHosts - Constants.OneDecimal;
                    continue;
                }

                lastPartLastIp = lastPartLastIp + numberOfHosts;

                var networkIpAddressString = networkIpAddress.Split(Constants.DotSpliter);
                networkIpAddressString[Constants.LastPartIpIndex] = ipNetworkPart.ToString();

                var broadcastAddressString = broadcastAddress.Split(Constants.DotSpliter);
                broadcastAddressString[Constants.LastPartIpIndex] = iPBroadcastPart.ToString();

                var firstIp = startIpAddress.Split(Constants.DotSpliter);
                firstIp[Constants.LastPartIpIndex] = lastPartFirstIp.ToString();

                var lastIp = endIpAddress.Split(Constants.DotSpliter);
                lastIp[Constants.LastPartIpIndex] = lastPartLastIp.ToString();

                row[Constants.NetworkAddressColumn] = string.Join(Constants.DotSpliterString, networkIpAddressString);
                row[Constants.UsableHostRangeColumn] = $"{string.Join(Constants.DotSpliterString, firstIp)} {Constants.DotSpliter} {string.Join(Constants.DotSpliterString, lastIp)}";
                row[Constants.BroadcastAddressColumn] = string.Join(Constants.DotSpliterString, broadcastAddressString);
                datatable.Rows.Add(row);
                ipNetworkPart = ipNetworkPart + numberOfHosts;
                iPBroadcastPart = iPBroadcastPart + numberOfHosts;
                lastPartFirstIp = lastPartFirstIp + numberOfHosts;
            }
        }

        private static void GetRangeSecondCategory(int cidr, int numberOfSubnets, int numberOfHosts, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, DataTable datatable)
        {
            var ipNetworkPart = Constants.Zero;
            var iPBroadcastPart = numberOfHosts;
            var secondPartFirstIp = numberOfHosts;
            var secondPartLastIp = numberOfHosts;
            string[] newNetworkIpAddress, newBroadcastAddress, newstartIpAddress, newendIpAddress;
            GetThirdPartOfIp(cidr, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, out newNetworkIpAddress, out newBroadcastAddress, out newstartIpAddress, out newendIpAddress);


            for (var i = 0; i < numberOfSubnets; i++)
            {
                var row = datatable.NewRow();
                if (i == 0)
                {
                    row[Constants.NetworkAddressColumn] = networkIpAddress;
                    row[Constants.UsableHostRangeColumn] = $"{startIpAddress} {Constants.HyphenSpliter} {endIpAddress}";
                    row[Constants.BroadcastAddressColumn] = broadcastAddress;
                    datatable.Rows.Add(row);
                    ipNetworkPart = numberOfHosts;
                    secondPartLastIp = secondPartLastIp - Constants.OneDecimal;
                    iPBroadcastPart = iPBroadcastPart + numberOfHosts - Constants.OneDecimal;
                    continue;
                }

                secondPartLastIp = secondPartLastIp + numberOfHosts;

                var networkIpAddressString = networkIpAddress.Split(Constants.DotSpliter);
                networkIpAddressString[Constants.ThirdPartIpIndex] = ipNetworkPart.ToString();

                var broadcastAddressString = broadcastAddress.Split(Constants.DotSpliter);
                broadcastAddressString[Constants.ThirdPartIpIndex] = iPBroadcastPart.ToString();

                var firstIp = startIpAddress.Split(Constants.DotSpliter);
                firstIp[Constants.ThirdPartIpIndex] = secondPartFirstIp.ToString();

                var lastIp = endIpAddress.Split(Constants.DotSpliter);
                lastIp[Constants.ThirdPartIpIndex] = secondPartLastIp.ToString();

                row[Constants.NetworkAddressColumn] = string.Join(Constants.DotSpliterString, networkIpAddressString);
                row[Constants.UsableHostRangeColumn] = $"{string.Join(Constants.DotSpliterString, firstIp)} {Constants.HyphenSpliter} {string.Join(Constants.DotSpliterString, lastIp)}";
                row[Constants.BroadcastAddressColumn] = string.Join(Constants.DotSpliterString, broadcastAddressString);
                datatable.Rows.Add(row);
                ipNetworkPart = ipNetworkPart + numberOfHosts;
                iPBroadcastPart = iPBroadcastPart + numberOfHosts;
                secondPartFirstIp = secondPartFirstIp + numberOfHosts;
            }
        }

        private static void GetRangeFourthCategory(int cidr, int numberOfSubnets, int numberOfHosts, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, DataTable datatable)
        {
            var ipNetworkPart = Constants.Zero;
            var iPBroadcastPart = numberOfHosts;
            var fourthPartFirstIp = numberOfHosts;
            var fourthPartLastIp = numberOfHosts;
            string[] newNetworkIpAddress, newBroadcastAddress, newstartIpAddress, newendIpAddress;
            GetFirstPartOfIp(cidr, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, out newNetworkIpAddress, out newBroadcastAddress, out newstartIpAddress, out newendIpAddress);

            for (var i = 0; i < numberOfSubnets; i++)
            {
                var row = datatable.NewRow();
                if (i == 0)
                {
                    row[Constants.NetworkAddressColumn] = string.Join(Constants.DotSpliterString, newNetworkIpAddress);
                    row[Constants.UsableHostRangeColumn] = $"{string.Join(Constants.DotSpliterString, newstartIpAddress)} {Constants.HyphenSpliter} {string.Join(Constants.DotSpliterString, newendIpAddress)}";
                    row[Constants.BroadcastAddressColumn] = string.Join(Constants.DotSpliterString, newBroadcastAddress);
                    datatable.Rows.Add(row);
                    ipNetworkPart = numberOfHosts;
                    fourthPartLastIp = fourthPartLastIp - Constants.OneDecimal;
                    iPBroadcastPart = iPBroadcastPart + numberOfHosts - Constants.OneDecimal;
                    continue;
                }

                fourthPartLastIp = fourthPartLastIp + numberOfHosts;

                newNetworkIpAddress[Constants.FirstPartIpIndex] = ipNetworkPart.ToString();
                newBroadcastAddress[Constants.FirstPartIpIndex] = iPBroadcastPart.ToString();

                var firstIp = startIpAddress.Split(Constants.DotSpliter);
                firstIp[0] = fourthPartFirstIp.ToString();

                var lastIp = endIpAddress.Split(Constants.DotSpliter);
                lastIp[0] = fourthPartLastIp.ToString();

                row[Constants.NetworkAddressColumn] = string.Join(Constants.DotSpliterString, newNetworkIpAddress);
                row[Constants.UsableHostRangeColumn] = $"{string.Join(Constants.DotSpliterString, firstIp)} {Constants.HyphenSpliter} {string.Join(Constants.DotSpliterString, lastIp)}";
                row[Constants.BroadcastAddressColumn] = string.Join(Constants.DotSpliterString, newBroadcastAddress);
                datatable.Rows.Add(row);
                ipNetworkPart = ipNetworkPart + numberOfHosts;
                iPBroadcastPart = iPBroadcastPart + numberOfHosts;
                fourthPartFirstIp = fourthPartFirstIp + numberOfHosts;
            }
        }

        private static void GetRangeThirdCategory(int cidr, int numberOfSubnets, int numberOfHosts, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, DataTable datatable)
        {
            var ipNetworkPart = Constants.Zero;
            var iPBroadcastPart = numberOfHosts;
            var thirdPartFirstIp = numberOfHosts;
            var thirdPartLastIp = numberOfHosts;
            string[] newNetworkIpAddress, newBroadcastAddress, newstartIpAddress, newendIpAddress;
            GetSecondPartOfIp(cidr, networkIpAddress, broadcastAddress, startIpAddress, endIpAddress, out newNetworkIpAddress, out newBroadcastAddress, out newstartIpAddress, out newendIpAddress);

            for (var i = 0; i < numberOfSubnets; i++)
            {
                var row = datatable.NewRow();
                if (i == 0)
                {
                    row[Constants.NetworkAddressColumn] = string.Join(Constants.DotSpliterString, newNetworkIpAddress);
                    row[Constants.UsableHostRangeColumn] = $"{string.Join(Constants.DotSpliterString, newstartIpAddress)} {Constants.HyphenSpliter} {string.Join(Constants.DotSpliterString, newendIpAddress)}";
                    row[Constants.BroadcastAddressColumn] = string.Join(Constants.DotSpliterString, newBroadcastAddress);
                    datatable.Rows.Add(row);
                    ipNetworkPart = numberOfHosts;
                    thirdPartLastIp = thirdPartLastIp - Constants.OneDecimal;
                    iPBroadcastPart = iPBroadcastPart + numberOfHosts - Constants.OneDecimal;
                    continue;
                }

                thirdPartLastIp = thirdPartLastIp + numberOfHosts;

                newNetworkIpAddress[Constants.SecondPartIpIndex] = ipNetworkPart.ToString();
                newBroadcastAddress[Constants.SecondPartIpIndex] = iPBroadcastPart.ToString();

                var firstIp = startIpAddress.Split(Constants.DotSpliter);
                firstIp[Constants.SecondPartIpIndex] = thirdPartFirstIp.ToString();

                var lastIp = endIpAddress.Split(Constants.DotSpliter);
                lastIp[Constants.SecondPartIpIndex] = thirdPartLastIp.ToString();

                row[Constants.NetworkAddressColumn] = string.Join(Constants.DotSpliterString, newNetworkIpAddress);
                row[Constants.UsableHostRangeColumn] = $"{string.Join(Constants.DotSpliterString, firstIp)} {Constants.HyphenSpliter} {string.Join(Constants.DotSpliterString, lastIp)}";
                row[Constants.BroadcastAddressColumn] = string.Join(Constants.DotSpliterString, newBroadcastAddress);
                datatable.Rows.Add(row);
                ipNetworkPart = ipNetworkPart + numberOfHosts;
                iPBroadcastPart = iPBroadcastPart + numberOfHosts;
                thirdPartFirstIp = thirdPartFirstIp + numberOfHosts;
            }
        }

        private static void GetSecondPartOfIp(int cidr, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, out string[] newNetworkIpAddress, out string[] newBroadcastAddress, out string[] newstartIpAddress, out string[] newendIpAddress)
        {
            newNetworkIpAddress = networkIpAddress.Split(Constants.DotSpliter);
            newNetworkIpAddress[Constants.SecondPartIpIndex] = Constants.ZeroString;
            newBroadcastAddress = broadcastAddress.Split(Constants.DotSpliter);
            newstartIpAddress = startIpAddress.Split(Constants.DotSpliter);
            newstartIpAddress[Constants.SecondPartIpIndex] = Constants.ZeroString;
            newendIpAddress = endIpAddress.Split(Constants.DotSpliter);
            switch (cidr)
            {
                case Constants.Cidr15:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.OwnString;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.OwnString;
                    break;
                case Constants.Cidr14:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.ThreeString;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.ThreeString;
                    break;
                case Constants.Cidr13:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.SevenString;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.SevenString;
                    break;
                case Constants.Cidr12:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.FifteenString;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.FifteenString;
                    break;
                case Constants.Cidr11:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.ThirtyOneString;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.ThirtyOneString;
                    break;
                case Constants.Cidr10:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.SixtyThree;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.SixtyThree;
                    break;
                case Constants.Cidr9:
                    newBroadcastAddress[Constants.SecondPartIpIndex] = Constants.HundredTwentySevenString;
                    newendIpAddress[Constants.SecondPartIpIndex] = Constants.HundredTwentySevenString;
                    break;
            }
        }

        private static void GetThirdPartOfIp(int cidr, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, out string[] newNetworkIpAddress, out string[] newBroadcastAddress, out string[] newstartIpAddress, out string[] newendIpAddress)
        {
            newNetworkIpAddress = networkIpAddress.Split(Constants.DotSpliter);
            newNetworkIpAddress[Constants.ThirdPartIpIndex] = Constants.ZeroString;
            newBroadcastAddress = broadcastAddress.Split(Constants.DotSpliter);
            newstartIpAddress = startIpAddress.Split(Constants.DotSpliter);
            newstartIpAddress[Constants.ThirdPartIpIndex] = Constants.ZeroString;
            newendIpAddress = endIpAddress.Split(Constants.DotSpliter);
            switch (cidr)
            {
                case Constants.Cidr23:
                    newBroadcastAddress[Constants.ThirdPartIpIndex] = Constants.OwnString;
                    newendIpAddress[Constants.ThirdPartIpIndex] = Constants.OwnString;
                    break;
                case Constants.Cidr22:
                    newBroadcastAddress[Constants.ThirdPartIpIndex] = Constants.ThreeString;
                    newendIpAddress[Constants.ThirdPartIpIndex] = Constants.ThreeString;
                    break;
                case Constants.Cidr19:
                    newBroadcastAddress[Constants.ThirdPartIpIndex] = Constants.SevenString;
                    newendIpAddress[Constants.ThirdPartIpIndex] = Constants.SevenString;
                    break;
                case Constants.Cidr17:
                    newBroadcastAddress[Constants.ThirdPartIpIndex] = Constants.FifteenString;
                    newendIpAddress[Constants.ThirdPartIpIndex] = Constants.FifteenString;
                    break;
                case Constants.Cidr16:
                    newBroadcastAddress[Constants.ThirdPartIpIndex] = Constants.ThirtyOneString;
                    newendIpAddress[Constants.ThirdPartIpIndex] = Constants.ThirtyOneString;
                    break;
            }
        }

        private static void GetFirstPartOfIp(int cidr, string networkIpAddress, string broadcastAddress, string startIpAddress, string endIpAddress, out string[] newNetworkIpAddress, out string[] newBroadcastAddress, out string[] newstartIpAddress, out string[] newendIpAddress)
        {
            newNetworkIpAddress = networkIpAddress.Split(Constants.DotSpliter);
            newNetworkIpAddress[Constants.FirstPartIpIndex] = Constants.ZeroString;
            newBroadcastAddress = broadcastAddress.Split(Constants.DotSpliter);
            newstartIpAddress = startIpAddress.Split(Constants.DotSpliter);
            newstartIpAddress[Constants.FirstPartIpIndex] = Constants.ZeroString;
            newendIpAddress = endIpAddress.Split(Constants.DotSpliter);
            switch (cidr)
            {
                case Constants.Cidr7:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.OwnString;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.OwnString;
                    break;
                case Constants.Cidr6:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.ThreeString;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.ThreeString;
                    break;
                case Constants.Cidr5:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.SevenString;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.SevenString;
                    break;
                case Constants.Cidr4:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.FifteenString;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.FifteenString;
                    break;
                case Constants.Cidr3:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.ThirtyOneString;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.ThirtyOneString;
                    break;
                case Constants.Cidr2:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.SixtyThree;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.SixtyThree;
                    break;
                case Constants.Cidr1:
                    newBroadcastAddress[Constants.FirstPartIpIndex] = Constants.HundredTwentySevenString;
                    newendIpAddress[Constants.FirstPartIpIndex] = Constants.HundredTwentySevenString;
                    break;
            }
        }

        public static string GetIpAddressClass(string ipAddress)
        {
            var ipClass = string.Empty;
            var ipParts = ipAddress.Split(Constants.DotSpliter);
            var firstPart = int.Parse(ipParts[Constants.FirstPartIpIndex]);
            if (firstPart > Constants.OneDecimal & firstPart <= Constants.HundertTwentySix)
            {
                ipClass = Constants.ClassA;
            }
            else if (firstPart > Constants.HundertTwentySix & firstPart <= Constants.HundertNinetyOne)
            {
                ipClass = Constants.ClassB;
            }
            else if (firstPart > Constants.HundertNinetyOne & firstPart <= Constants.TwoHundredTwentyThree)
            {
                ipClass = Constants.ClassC;
            }
            else if (firstPart > Constants.TwoHundredTwentyThree & firstPart <= Constants.TwoHundredThirtyNine)
            {
                ipClass = Constants.ClassD;
            }
            else if (firstPart > Constants.TwoHundredThirtyNine & firstPart <= Constants.TwoHundredFiftyFour)
            {
                ipClass = Constants.ClassE;
            }
            return ipClass;
        }
    }
}
