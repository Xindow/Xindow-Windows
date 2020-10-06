using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xindow.Common
{
    static class Identity
    {
        public static string GetComputerName()
        {
            int size = Interop.Kernel32.MAX_COMPUTERNAME_LENGTH + 1;
            StringBuilder tempName = new StringBuilder(size);
            bool ret = Interop.Kernel32.GetComputerNameEx(Interop.Kernel32.COMPUTER_NAME_FORMAT.ComputerNameNetBIOS, tempName, ref size);
            return tempName.ToString();
        }
    }
}
