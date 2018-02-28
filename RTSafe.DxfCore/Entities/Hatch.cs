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
    public class Hatch :
        DxfObject,
        IEntityObject
    {
        #region private fields

        private const EntityType TYPE = EntityType.Hatch;
        private string baseHandle;
        private List<IEntityObject> entities;
        private Vector3f normal;
        private AciColor color;
        private Layer layer;
        private LineType lineType;
        private Dictionary<ApplicationRegistry, XData> xData;
        private Vector3d basePoint;

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
        public Hatch()
            : base(DxfObjectCode.Hatch)
        {
            this.entities = new List<IEntityObject>();
            this.layer = Layer.Default;
            this.color = AciColor.ByLayer;
            this.lineType = LineType.ByLayer;
            this.normal = Vector3f.UnitZ;
            basePoint = Vector3d.Zero;
        }

        ///// <summary>
        ///// Initializes a new instance of the <c>Arc</c> class.
        ///// </summary>
        //public Hatch() :
        //    base(DxfObjectCode.Hatch)
        //{
        //    this.entities = new List<IEntityObject>();
        //    this.layer = Layer.Default;
        //    this.color = AciColor.ByLayer;
        //    this.lineType = LineType.ByLayer;
        //    this.normal = Vector3f.UnitZ;
        //}

        #endregion

        #region public properties


        /// <summary>
        /// 拉伸方向
        /// </summary>
        public Vector3f Normal
        {
            get { return this.normal; }
            set
            {
                if (Vector3f.Zero == value)
                    value = Vector3f.UnitZ;
                value.Normalize();
                this.normal = value;
            }
        }
        /// <summary>
        /// 标高点
        /// </summary>
        public Vector3d BasePoint
        {
            get { return this.basePoint; }
            set
            {
                if (Vector3d.Zero == value)
                    value = Vector3d.UnitZ;
                value.Normalize();
                this.basePoint = value;
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
        ///边界点的句柄 
        /// </summary>
        public string BaseHandle
        {
            get { return this.baseHandle; }
            set
            {
                this.baseHandle = value;
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
        /// 边界
        /// </summary>
        public List<IEntityObject> Entities
        {
            get { return this.entities; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.entities = value;
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
    }
}