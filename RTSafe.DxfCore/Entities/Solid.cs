
using System;
using System.Collections.Generic;
using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Represents a solid <see cref="IEntityObject">entity</see>.
    /// </summary>
    public class Solid :
        DxfObject,
        IEntityObject
    {
        #region private fields

        private const EntityType TYPE = EntityType.Solid;
        private Vector3f firstVertex;
        private Vector3f secondVertex;
        private Vector3f thirdVertex;
        private Vector3f fourthVertex;
        private double thickness;
        private Vector3f normal;
        private Layer layer;
        private AciColor color;
        private LineType lineType;
        private Dictionary<ApplicationRegistry, XData> xData;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Solid</c> class.
        /// </summary>
        /// <param name="firstVertex">Solid <see cref="Vector3f">first vertex</see>.</param>
        /// <param name="secondVertex">Solid <see cref="Vector3f">second vertex</see>.</param>
        /// <param name="thirdVertex">Solid <see cref="Vector3f">third vertex</see>.</param>
        /// <param name="fourthVertex">Solid <see cref="Vector3f">fourth vertex</see>.</param>
        public Solid(Vector3f firstVertex, Vector3f secondVertex, Vector3f thirdVertex, Vector3f fourthVertex)
            : base(DxfObjectCode.Solid)
        {
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
            this.thirdVertex = thirdVertex;
            this.fourthVertex = fourthVertex;
            this.thickness = 0.25d;
            this.normal = Vector3f.UnitZ;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
        }

        /// <summary>
        /// Initializes a new instance of the <c>Solid</c> class.
        /// </summary>
        public Solid()
            : base(DxfObjectCode.Solid)
        {
            this.firstVertex = Vector3f.Zero;
            this.secondVertex = Vector3f.Zero;
            this.thirdVertex = Vector3f.Zero;
            this.fourthVertex = Vector3f.Zero;
            this.thickness = 0.25d;
            this.normal = Vector3f.UnitZ;
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the first solid <see cref="Vector3f">vertex</see>.
        /// </summary>
        public Vector3f FirstVertex
        {
            get { return this.firstVertex; }
            set { this.firstVertex = value; }
        }

        /// <summary>
        /// Gets or sets the second solid <see cref="Vector3f">vertex</see>.
        /// </summary>
        public Vector3f SecondVertex
        {
            get { return this.secondVertex; }
            set { this.secondVertex = value; }
        }

        /// <summary>
        /// Gets or sets the third solid <see cref="Vector3f">vertex</see>.
        /// </summary>
        public Vector3f ThirdVertex
        {
            get { return this.thirdVertex; }
            set { this.thirdVertex = value; }
        }

        /// <summary>
        /// Gets or sets the fourth solid <see cref="Vector3f">vertex</see>.
        /// </summary>
        public Vector3f FourthVertex
        {
            get { return this.fourthVertex; }
            set { this.fourthVertex = value; }
        }

        /// <summary>
        /// Gets or sets the thickness of the solid.
        /// </summary>
        public double Thickness
        {
            get { return this.thickness; }
            set { this.thickness = value; }
        }

        /// <summary>
        /// Gets or sets the solid <see cref="Vector3f">normal</see>.
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
            set { this.xData = value; }
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

      
        public DxfCore.Model.Point ExtMaxPoint
        {
            get;
            set;
        }

        public DxfCore.Model.Point ExtMinPoint
        {
            get;
            set;
        }
    }
}