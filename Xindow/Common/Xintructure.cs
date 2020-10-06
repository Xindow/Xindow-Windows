using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xindow.Common
{
    class Xintructure
    {
        public struct PositionIndependentBox
        {
            public int width;
            public int height;

            public PositionDependentBox ConvertToPositionDependent()
            {
                return new PositionDependentBox() { x = 0, y = 0, width = width, height = height };
            }

            public bool IsDot()
            {
                return width <= 1 && height <= 1;
            }

            public override string ToString()
            {
                return $"PositionIndependentBox({width}, {height})";
            }
        }

        public struct PositionDependentBox
        {
            public int x;
            public int y;
            public int width;
            public int height;

            public static PositionDependentBox FromWindefRect(Interop.WinDef.RECT rect)
            {
                return new PositionDependentBox() { x = rect.left, y = rect.top, width = rect.right - rect.top, height = rect.bottom - rect.top };
            }

            public PositionIndependentBox ConvertToPositionIndependent()
            {
                return new PositionIndependentBox() { width = width, height = height };
            }

            public bool IsDot()
            {
                return width <= 1 && height <= 1;
            }

            public override string ToString()
            {
                return $"PositiondependentBox({x}, {y}, {width}, {height})";
            }
        }

        public struct Window
        {
            public string title;
            public PositionDependentBox box;
            
            public override string ToString()
            {
                return $"Window({title.Replace(",", "\\,")}, {box})";
            }
        }
    }
}
