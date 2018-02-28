using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSafe.DxfCore.ElementModel
{
    public class CircleElement:Element
    {
        public EPoint EPoint { get; set; }

        public double Radius { get; set; }
    }
}
