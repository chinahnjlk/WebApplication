using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSafe.DxfCore.ElementModel
{
    public class Text:Element
    {
        public string Value { get; set; }

        public string Style { get; set; }

        public string Height { get; set; }

        public double Rotation { get; set; }
    }
}
