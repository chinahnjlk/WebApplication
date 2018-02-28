using System;
using System.Collections.Generic;
using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Represents a attribute <see cref="IEntityObject">entity</see>.
    /// </summary>
    public class Attribute :
        DxfObject,
        IEntityObject
    {
        #region private fields

        private const EntityType TYPE = EntityType.Attribute;
        private readonly AttributeDefinition definition;
        private object value;
        private AciColor color;
        private Layer layer;
        private LineType lineType;
        private Dictionary<ApplicationRegistry, XData> xData;

        #endregion

        #region constructor

        /// <summary>
        /// Intitializes a new instance of the <c>Attribute</c> class.
        /// </summary>
        /// <param name="definition"><see cref="AttributeDefinition">Attribute definition</see>.</param>
        public Attribute(AttributeDefinition definition)
            : base(DxfObjectCode.Attribute)
        {
            this.definition = definition;
            this.value = null;
            this.color = definition.Color;
            this.layer = definition.Layer;
            this.lineType = definition.LineType;
        }

        /// <summary>
        /// Intitializes a new instance of the <c>Attribute</c> class.
        /// </summary>
        /// <param name="definition"><see cref="AttributeDefinition">Attribute definition</see>.</param>
        /// <param name="value">Attribute value.</param>
        public Attribute(AttributeDefinition definition, object value)
            : base(DxfObjectCode.Attribute)
        {
            this.definition = definition;
            this.value = value;
            this.color = definition.Color;
            this.layer = definition.Layer;
            this.lineType = definition.LineType;
        }

        #endregion

        #region public property

        /// <summary>
        /// Gets the attribute definition.
        /// </summary>
        public AttributeDefinition Definition
        {
            get { return this.definition; }
        }

        /// <summary>
        /// Gets or sets the attribute value.
        /// </summary>
        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
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
            set
            {
                throw new ArgumentException("Extended data not avaliable for attributes","value");
            }
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