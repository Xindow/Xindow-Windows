using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xindow.Common
{
    class XinOperation
    {
        public static List<Xintructure.Window> GetWindows(bool removeDot = false)
        {
            List<Xintructure.Window> windows = new List<Xintructure.Window>();

            IntPtr hwnd = Interop.User32.GetDesktopWindow();
            hwnd = Interop.User32.GetWindow(hwnd, Interop.WinUser.GW_CHILD);
            
            while (hwnd != IntPtr.Zero)
            {
                Interop.WinDef.RECT rect;
                Interop.User32.GetWindowRect(hwnd, out rect);
                int nameSize = 255;
                StringBuilder title = new StringBuilder(nameSize);
                Interop.User32.GetWindowText(hwnd, title, ref nameSize);
                windows.Add(new Xintructure.Window() { title = title.ToString(), box = Xintructure.PositionDependentBox.FromWindefRect(rect) } );
                hwnd = Interop.User32.GetWindow(hwnd, Interop.WinUser.GW_HWNDNEXT);
            }
            if (removeDot)
                windows.RemoveAll(window => { return window.box.IsDot(); });
            return windows;
        }
    }
}
