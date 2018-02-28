using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Element
    {
        public EPoint EPoint { get; set; }
    }

    public class EPoint
    {
        public double X { get; set; }

        public double Y { get; set; }
    }


    public class TextElement : Element
    {
        public int Size { get; set; }

        public string Color { get; set; }
    }
}