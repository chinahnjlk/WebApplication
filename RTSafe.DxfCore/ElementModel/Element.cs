using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTSafe.DxfCore.ElementModel
{
    public class Element
    {
        public string Tag { get; set; }
        public EPoint Start { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public Brush Color { get; set; }
    }

    public class TextElement : Element
    {
        public double Size { get; set; }

        public string Value { get; set; }

        public string Fontfamily { get; set; }

        //public new string  Color { get; set; }
        //public double Height { get; set; }
    }

    public class ElementList
    {
        public List<TextElement> TextElements { get; set; }

        public List<LineElement> LineElements { get; set; }

        public List<PathElement> PathElements { get; set; }

        public List<CircleElement> CircleElements { get; set; }

        public List<LightWeightPolylineElement> LightWeightPolylineElements { get; set; }
    }
}
