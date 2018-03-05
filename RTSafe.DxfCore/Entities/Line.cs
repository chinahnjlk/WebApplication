using System;
using System.Collections.Generic;
using RTSafe.DxfCore;
using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Model;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Represents a line <see cref="IEntityObject">entity</see>.
    /// </summary>
    public class Line :
        DxfObject,
        IEntityObject
    {
        #region private fields

        private const EntityType TYPE = EntityType.Line;
        private Vector3f startPoint;
        private Vector3f endPoint;
        private double thickness;
        private AciColor color;
        private Layer layer;
        private LineType lineType;
        private Vector3f normal;
        private Dictionary<ApplicationRegistry, XData> xData;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Line</c> class.
        /// </summary>
        /// <param name="startPoint">Line <see cref="Vector3f">start point.</see></param>
        /// <param name="endPoint">Line <see cref="Vector3f">end point.</see></param>
        public Line(Vector3f startPoint, Vector3f endPoint) 
            : base(DxfObjectCode.Line)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.thickness = 0.25d;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
        }

        /// <summary>
        /// Initializes a new instance of the <c>Line</c> class.
        /// </summary>
        public Line()
            : base(DxfObjectCode.Line)
        {
            this.startPoint = Vector3f.Zero;
            this.endPoint = Vector3f.Zero;
            this.thickness = 0.25d;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the line <see cref="Vector3f">start point</see>.
        /// </summary>
        public Vector3f StartPoint
        {
            get { return this.startPoint; }
            set { this.startPoint = value; }
        }

        /// <summary>
        /// Gets or sets the line <see cref="Vector3f">end point</see>.
        /// </summary>
        public Vector3f EndPoint
        {
            get { return this.endPoint; }
            set { this.endPoint = value; }
        }

        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        public double Thickness
        {
            get { return this.thickness ; }
            set { this.thickness = value; }
        }

        /// <summary>
        /// Gets or sets the line <see cref="Vector3f">normal</see>.
        /// </summary>
        public Vector3f Normal
        {
            get { return this.normal; }
            set
            {
                if (Vector3f.Zero == value)
                    throw new ArgumentNullException("value","The normal can not be the zero vector");
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
            set { this.xData = value; }
        }

        //public string Tag { get; set; }
        //public Media.Brush Stroke { get; set; }
        //public double StrokeThickness { get; set; }
        //public double X1 { get; set; }
        //public double Y1 { get; set; }
        //public double X2 { get; set; }
        //public double Y2 { get; set; }
        //public DoubleCollection StrokeDashArray { get; set; }

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