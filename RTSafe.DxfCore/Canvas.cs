using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTSafe.DxfCore.Entities;

namespace RTSafe.DxfCore
{
    public class Canvas
    {
        public object Children { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public static void SetLeft(Ellipse item, double d)
        {
            throw new NotImplementedException();
        }

        public static void SetTop(Ellipse item, double d)
        {
            throw new NotImplementedException();
        }
    }
}
