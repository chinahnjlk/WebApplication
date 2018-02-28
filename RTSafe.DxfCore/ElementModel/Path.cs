using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSafe.DxfCore.ElementModel
{
    public class PathElement:Element
    {
        public string Tag { get; set; }

        public EPoint StartPoint { get; set; }

        public bool IsLargeArc { get; set; }

        public double RotationAngle { get; set; }

        public double Radius { get; set; }

        //public EPoint Point { get; set; }

        public double StartAngle { get; set; }

        public double EndAngle { get; set; }

    }

    public class Size
    {
        public double R1;
        public double R2;

        public Size(double r1,double r2)
        {
            this.R1 = r1;
            this.R2 = r2;
        }
    }
}
