using RTSafe.DxfCore.DxfCore.Tables;

namespace RTSafe.DxfCore.DxfCore.Model
{
    public class Point
    {
        private double p1;
        private double p2;

        public Point(double p1, double p2)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
        }

        public Point()
        {
            // TODO: Complete member initialization
        }


        public double X { get; set; }

        public double Y { get; set; }
        public Layer Layer { get; set; }
        public AciColor Color { get; set; }
        public Vector3f Location { get; set; }
    }
}
