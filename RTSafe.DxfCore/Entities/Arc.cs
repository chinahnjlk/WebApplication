using System;
using System.Collections.Generic;
using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Entities
{

    /// <summary>
    /// Represents a circular arc <see cref="IEntityObject">entity</see>.
    /// </summary>
    public class Arc :
        DxfObject,
        IEntityObject 
    {
        #region private fields

        private const EntityType TYPE = EntityType.Arc;
        private Vector3f center;
        private double radius;
        private double startAngle;
        private double endAngle;
        private double thickness;
        private Vector3f normal;
        private AciColor color;
        private Layer layer;
        private LineType lineType;
        private Dictionary<ApplicationRegistry, XData> xData;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Arc</c> class.
        /// </summary>
        /// <param name="center">Arc <see cref="Vector3f">center</see> in object coordinates.</param>
        /// <param name="radius">Arc radius.</param>
        /// <param name="startAngle">Arc start angle in degrees.</param>
        /// <param name="endAngle">Arc end angle in degrees.</param>
        /// <remarks>The center Z coordinate represents the elevation of the arc along the normal.</remarks>
        public Arc(Vector3f center, double radius, double startAngle, double endAngle) : base (DxfObjectCode.Arc)
        {
            this.center = center;
            this.radius = radius;
            this.startAngle = startAngle;
            this.endAngle = endAngle;
            this.thickness = 0.25d;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
        }

        /// <summary>
        /// Initializes a new instance of the <c>Arc</c> class.
        /// </summary>
        public Arc() :
            base(DxfObjectCode.Arc)
        {
            this.center = Vector3f.Zero;
            this.radius = 0.0f;
            this.startAngle = 0.0f;
            this.endAngle = 0.0f;
            this.thickness = 0.25d;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the arc <see cref="Vector3f">center</see>.
        /// </summary>
        /// <remarks>The center Z coordinate represents the elevation of the arc along the normal.</remarks>
        public Vector3f Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets or sets the arc radius.
        /// </summary>
        public int Radius
        {
            get { return (int) this.radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value",value.ToString());
                this.radius = value;
            }
        }

        /// <summary>
        /// Gets or sets the arc start angle in degrees.
        /// </summary>
        public double StartAngle
        {
            get { return this.startAngle; }
            set { this.startAngle = value; }
        }

        /// <summary>
        /// Gets or sets the arc end angle in degrees.
        /// </summary>
        public double EndAngle
        {
            get { return this.endAngle; }
            set { this.endAngle = value; }
        }

        /// <summary>
        /// Gets or sets the arc thickness.
        /// </summary>
        public double Thickness
        {
            get { return this.thickness; }
            set { this.thickness = value; }
        }

        /// <summary>
        /// Gets or sets the arc <see cref="Vector3f">normal</see>.
        /// </summary>
        public Vector3f Normal
        {
            get { return this.normal; }
            set
            {
                if (Vector3f.Zero == value)
                    throw new ArgumentNullException("value", "The normal can not be the zero vector");
                value.Normalize();
                this.normal = value;
            }
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
            set{ this.xData = value;}
        }

        #endregion

        #region public methods

        /// <summary>
        /// Converts the arc in a list of vertexes.
        /// </summary>
        /// <param name="precision">Number of vertexes generated.</param>
        /// <returns>A list vertexes that represents the arc expresed in object coordinate system.</returns>
        public List<Vector2f> PoligonalVertexes(int precision)
        {
            if (precision < 2)
                throw new ArgumentOutOfRangeException("The arc precision must be greater or equal to two");

            List<Vector2f> ocsVertexes = new List<Vector2f>();
            double start = (double) (this.startAngle*MathHelper.DegToRad);
            double end = (double) (this.endAngle*MathHelper.DegToRad);
            double angle = (end - start) / precision;

            for (int i = 0; i <= precision; i++)
            {
                double sine = (double)(this.radius * Math.Sin(start + angle * i));
                double cosine = (double)(this.radius * Math.Cos(start + angle * i));
                ocsVertexes.Add(new Vector2f(cosine + this.center.X, sine + this.center.Y));
            }

            return ocsVertexes;
        }

        /// <summary>
        /// Converts the arc in a list of vertexes.
        /// </summary>
        /// <param name="precision">Number of vertexes generated.</param>
        /// <param name="weldThreshold">Tolerance to consider if two new generated vertexes are equal.</param>
        /// <returns>A list vertexes that represents the arc expresed in object coordinate system.</returns>
        public List<Vector2f> PoligonalVertexes(int precision, double weldThreshold)
        {
            if (precision < 2)
                throw new ArgumentOutOfRangeException("The arc precision must be greater or equal to two");

            List<Vector2f> ocsVertexes = new List<Vector2f>();
            double start = (double)(this.startAngle * MathHelper.DegToRad);
            double end = (double)(this.endAngle * MathHelper.DegToRad);

            if (2*this.radius >= weldThreshold)
            {
                double angulo = (end - start)/precision;
                Vector2f prevPoint;
                Vector2f firstPoint;

                double sine = (double) (this.radius*Math.Sin(start));
                double cosine = (double) (this.radius*Math.Cos(start));
                firstPoint = new Vector2f(cosine + this.center.X, sine + this.center.Y);
                ocsVertexes.Add(firstPoint);
                prevPoint = firstPoint;

                for (int i = 1; i <= precision; i++)
                {
                    sine = (double) (this.radius*Math.Sin(start + angulo*i));
                    cosine = (double) (this.radius*Math.Cos(start + angulo*i));
                    Vector2f point = new Vector2f(cosine + this.center.X, sine + this.center.Y);

                    if (!point.Equals(prevPoint, weldThreshold) && !point.Equals(firstPoint, weldThreshold))
                    {
                        ocsVertexes.Add(point);
                        prevPoint = point;
                    }
                }
            }

            return ocsVertexes;
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



     
    }
}