using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Xindow.Common
{
    static class Identity
    {
        public static string GetComputerName()
        {
            int size = Interop.WinBase.MAX_COMPUTERNAME_LENGTH + 1;
            StringBuilder tempName = new StringBuilder(size);
            bool ret = Interop.Kernel32.GetComputerNameEx(Interop.WinBase.COMPUTER_NAME_FORMAT.ComputerNameNetBIOS, tempName, ref size);
            return tempName.ToString();
        }

        public static string GetInternetIp()
        {
            return new StreamReader(WebRequest.CreateHttp("http://ifconfig.me/ip").GetResponse().GetResponseStream()).ReadToEnd();
        }
    }
}
