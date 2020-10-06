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
            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern bool GetComputerNameEx(WinBase.COMPUTER_NAME_FORMAT format, StringBuilder lpBuffer, ref int nSize);

            [DllImport("Kernel32.dll")]
            public static extern uint GetLastError();
        }

        public class User32
        {
            [DllImport("User32.dll")]
            public static extern IntPtr GetDesktopWindow();

            [DllImport("User32.dll")]
            public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

            [DllImport("User32.dll")]
            public static extern bool GetWindowRect(IntPtr hWnd, out WinDef.RECT lpRect);

            [DllImport("User32.dll")]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, ref int nSize);
        }

        public class WinBase
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
        }

        public class WinDef
        {
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
        }

        public class WinUser
        {
            public static uint GW_CHILD = 5;
            public static uint GW_ENABLEDPOPUP = 6;
            public static uint GW_HWNDFIRST = 0;
            public static uint GW_HWNDLAST = 1;
            public static uint GW_HWNDNEXT = 2;
            public static uint GW_HWNDPREV = 3;
            public static uint GW_OWNER = 4;
        }
    }
}
