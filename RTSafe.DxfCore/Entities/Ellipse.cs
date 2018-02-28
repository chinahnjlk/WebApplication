using System;
using System.Collections.Generic;
using System.Drawing;
using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Model;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Represents an ellipse <see cref="IEntityObject">entity</see>.
    /// </summary>
    public class Ellipse :
        DxfObject,
        IEntityObject
    {
        #region private fields

        private const EntityType TYPE = EntityType.Ellipse;
        private Vector3f center;
        private double majorAxis;
        private double minorAxis;
        private double rotation;
        private double startAngle;
        private double endAngle;
        private double thickness;
        private Layer layer;
        private AciColor color;
        private LineType lineType;
        private Vector3f normal;
        private int curvePoints;
        private Dictionary<ApplicationRegistry, XData> xData;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Ellipse</c> class.
        /// </summary>
        /// <param name="center">Ellipse <see cref="Vector3f">center</see> in object coordinates.</param>
        /// <param name="majorAxis">Ellipse major axis.</param>
        /// <param name="minorAxis">Ellipse minor axis.</param>
        /// <remarks>The center Z coordinate represents the elevation of the arc along the normal.</remarks>
        public Ellipse(Vector3f center, double majorAxis, double minorAxis)
            : base(DxfObjectCode.Ellipse)
        {
            this.center = center;
            this.majorAxis = majorAxis;
            this.minorAxis = minorAxis;
            this.startAngle = 0.0f;
            this.endAngle = 360.0f;
            this.rotation = 0.0f;
            this.curvePoints = 30;
            this.thickness = 0.25d;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
        }

        /// <summary>
        /// Initializes a new instance of the <c>ellipse</c> class.
        /// </summary>
        public Ellipse()
            : base(DxfObjectCode.Ellipse)
        {
            this.center = Vector3f.Zero;
            this.majorAxis = 1.0f;
            this.minorAxis = 0.5f;
            this.rotation = 0.0f;
            this.startAngle = 0.0f;
            this.endAngle = 360.0f;
            this.rotation = 0.0f;
            this.curvePoints = 30;
            this.thickness = 0.25d;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the ellipse <see cref="Vector3f">center</see>.
        /// </summary>
        /// <remarks>The center Z coordinate represents the elevation of the arc along the normal.</remarks>
        public Vector3f Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets or sets the ellipse mayor axis.
        /// </summary>
        public double MajorAxis
        {
            get { return this.majorAxis; }
            set
            {
                if(value<=0)
                    throw new ArgumentOutOfRangeException("The major axis value must be greater than zero.");
                this.majorAxis = value;
            }
        }

        /// <summary>
        /// Gets or sets the ellipse minor axis.
        /// </summary>
        public double MinorAxis
        {
            get { return this.minorAxis; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The minor axis value must be greater than zero.");
                this.minorAxis = value;
            }
        }

        /// <summary>
        /// Gets or sets the ellipse rotation along its normal.
        /// </summary>
        public double Rotation
        {
            get { return this.rotation; }
            set { this.rotation = value; }
        }

        /// <summary>
        /// Gets or sets the ellipse start angle in degrees.
        /// </summary>
        /// <remarks><c>StartAngle</c> equals 0 and <c>EndAngle</c> equals 360 for a full ellipse.</remarks>
        public double StartAngle
        {
            get { return this.startAngle; }
            set { this.startAngle = value; }
        }

        /// <summary>
        /// Gets or sets the ellipse end angle in degrees.
        /// </summary>
        /// <remarks><c>StartAngle</c> equals 0 and <c>EndAngle</c> equals 360 for a full ellipse.</remarks>
        public double EndAngle
        {
            get { return this.endAngle; }
            set { this.endAngle = value; }
        }

        /// <summary>
        /// Gets or sets the ellipse <see cref="Vector3f">normal</see>.
        /// </summary>
        public Vector3f Normal
        {
            get { return this.normal; }
            set
            {
                value.Normalize();
                this.normal = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of points generated along the ellipse during the conversion to a polyline.
        /// </summary>
        public int CurvePoints
        {
            get { return this.curvePoints; }
            set { this.curvePoints = value; }
        }

        /// <summary>
        /// Gets or sets the ellipse thickness.
        /// </summary>
        public double Thickness
        {
            get { return this.thickness; }
            set { this.thickness = value; }
        }

        /// <summary>
        /// Checks if the the actual instance is a full ellipse.
        /// </summary>
        public bool IsFullEllipse
        {
            get { return (this.startAngle + this.endAngle == 360); }
        }

        #endregion

        #region IEntityObject Members

        /// <summary>
        /// Gets the entity <see cref="EntityType">type</see>.
        /// </summary>
        public EntityType Type
        {
            get { return TYPE; }
        }

        /// <summary>
        /// Gets or sets the entity <see cref="AciColor">color</see>.
        /// </summary>
        public AciColor Color
        {
            get { return this.color; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.color = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity <see cref="DxfCore.Tables.Layer">layer</see>.
        /// </summary>
        public Layer Layer
        {
            get { return this.layer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.layer = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity <see cref="Tables.LineType">line type</see>.
        /// </summary>
        public LineType LineType
        {
            get { return this.lineType; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.lineType = value;
            }
        }

        /// <summary>
        /// Gets or sets the entity <see cref="RTSafe.DxfCore.XData">extende data</see>.
        /// </summary>
        public Dictionary<ApplicationRegistry, XData> XData
        {
            get { return this.xData; }
            set { this.xData = value; }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Converts the ellipse in a Polyline.
        /// </summary>
        /// <param name="precision">Number of vertexes generated.</param>
        /// <returns>A new instance of <see cref="Polyline">Polyline</see> that represents the ellipse.</returns>
        public Polyline ToPolyline(int precision)
        {
            List<Vector2f> vertexes = this.PolygonalVertexes(precision);
            Vector3d ocsCenter = MathHelper.Transform((Vector3d) this.center,
                                                      (Vector3d)this.normal, MathHelper.CoordinateSystem.World, MathHelper.CoordinateSystem.Object);
            Polyline poly = new Polyline
            {
                Color = this.color,
                Layer = this.layer,
                LineType = this.lineType,
                Normal = this.normal,
                Elevation = (double)ocsCenter.Z,
                Thickness=this.thickness
            };
            poly.XData=this.xData;

            foreach (Vector2f v in vertexes)
            {
                poly.Vertexes.Add(new PolylineVertex((double) (v.X + ocsCenter.X), (double) (v.Y + ocsCenter.Y)));
            }
            if (this.IsFullEllipse)
                poly.IsClosed = true;

            return poly;
        }

        /// <summary>
        /// Converts the ellipse in a list of vertexes.
        /// </summary>
        /// <param name="precision">Number of vertexes generated.</param>
        /// <returns>A list vertexes that represents the ellipse expresed in object coordinate system.</returns>
        public List<Vector2f> PolygonalVertexes(int precision)
        {
            List<Vector2f> points = new List<Vector2f>();
            double beta = (double) (this.rotation*MathHelper.DegToRad);
            double sinbeta = (double) Math.Sin(beta);
            double cosbeta = (double) Math.Cos(beta);

            if (this.IsFullEllipse)
            {
                for (int i = 0; i < 360; i += 360/precision)
                {
                    double alpha = (double) (i*MathHelper.DegToRad);
                    double sinalpha = (double) Math.Sin(alpha);
                    double cosalpha = (double) Math.Cos(alpha);

                    double pointX = 0.5f * (this.majorAxis*cosalpha*cosbeta - this.minorAxis*sinalpha*sinbeta);
                    double pointY =  0.5f * (this.majorAxis * cosalpha * sinbeta + this.minorAxis * sinalpha * cosbeta);

                    points.Add(new Vector2f(pointX, pointY));
                }
            }
            else
            {
                for (int i = 0; i <= precision; i++)
                {
                    double angle = this.startAngle + i*(this.endAngle - this.startAngle)/precision;
                    points.Add(this.PointFromEllipse(angle));
                }
            }
            return points;
        }

        private Vector2f PointFromEllipse(double degrees)
        {
            // Convert the basic input into something more usable
            Vector2f ptCenter = new Vector2f(this.center.X, this.center.Y);
            double radians = (double) (degrees*MathHelper.DegToRad);

            // Calculate the radius of the ellipse for the given angle
            double a = this.majorAxis;
            double b = this.minorAxis;
            double eccentricity = (double) Math.Sqrt(1 - (b*b)/(a*a));
            double radiusAngle = b/(double) Math.Sqrt(1 - (eccentricity*eccentricity)*Math.Pow(Math.Cos(radians), 2));

            // Convert the radius back to Cartesian coordinates
            return new Vector2f(ptCenter.X + radiusAngle*(double) Math.Cos(radians), ptCenter.Y + radiusAngle*(double) Math.Sin(radians));
        }

        #endregion

        #region overrides

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return TYPE.ToString();
        }

        #endregion

        public Vector3f AxisPoint { get; set; }
        public string Tag { get; set; }
        public double Height { get; set; }
        public int Width { get; set; }
        public Brush Stroke { get; set; }
        public double StrokeThickness { get; set; }
        public object StrokeDashArray { get; set; }
    }
}