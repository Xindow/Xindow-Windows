using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Xindow
{
    class Interop
    {
        public class Kernel32
        {
            public static int MAX_COMPUTERNAME_LENGTH = 15;

            public enum COMPUTER_NAME_FORMAT
            {
                ComputerNameNetBIOS,
                ComputerNameDnsHostname,
                ComputerNameDnsDomain,
                ComputerNameDnsFullyQualified,
                ComputerNamePhysicalNetBIOS,
                ComputerNamePhysicalDnsHostname,
                ComputerNamePhysicalDnsDomain,
                ComputerNamePhysicalDnsFullyQualified
            }

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern bool GetComputerNameEx(COMPUTER_NAME_FORMAT format, StringBuilder lpBuffer, ref int nSize);

            [DllImport("Kernel32.dll")]
            public static extern UInt32 GetLastError();
        }
    }
}
