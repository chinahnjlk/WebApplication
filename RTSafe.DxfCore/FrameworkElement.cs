using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using RTSafe.DxfCore.DxfCore.Model;

namespace RTSafe.DxfCore
{
    public class FrameworkElement
    {
        public string Tag { get; set; }
        public double Height { get; set; }
        public int Width { get; set; }
        public Brush Stroke { get; set; }
        public PointCollection Points { get; set; }
    }
}
