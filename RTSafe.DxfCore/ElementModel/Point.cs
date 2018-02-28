using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSafe.DxfCore.ElementModel
{
    public class EPoint
    {
        public double X { get; set; }

        public double Y { get; set; }


        public EPoint()
        {
            
        }

        public EPoint(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
