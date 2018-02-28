using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSafe.DxfCore.ElementModel
{
    public class LightWeightPolylineElement:Element
    {
        public EPoint EPoint { get; set; }

        public List<EPoint> EPoints { get; set; }

       
    }

    public class Polygon
    {
        public List<EPoint> EPoints { get; set; }
    }
}
