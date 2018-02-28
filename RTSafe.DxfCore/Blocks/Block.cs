using System;
using System.Collections.Generic;
using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Entities;
using RTSafe.DxfCore.Tables;


namespace RTSafe.DxfCore.DxfCore.Blocks
{
    /// <summary>
    /// Represents a block definition.
    /// </summary>
    public class Block :
        DxfObject
    {
        #region private fields

        private readonly BlockRecord record;
        private readonly BlockEnd end;
        private string name;
        private Layer layer;
        private Vector3f basePoint;
        private Dictionary<string, AttributeDefinition> attributes;
        private List<IEntityObject> entities;

        #endregion

        #region constants

        public static Block ModelSpace
        {
            get { return new Block("*Model_Space"); }
        }

        public static Block PaperSpace
        {
            get { return new Block("*Paper_Space"); }
        }

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Block</c> class.
        /// </summary>
        /// <param name="name">Block name.</param>
        public Block(string name)
            : base(DxfObjectCode.Block)
        {
            if (string.IsNullOrEmpty(name))
                throw (new ArgumentNullException("name"));

            this.name = name;
            this.basePoint = Vector3f.Zero;
            this.layer = Layer.Default;
            this.attributes = new Dictionary<string, AttributeDefinition>();
            this.entities = new List<IEntityObject>();
            this.record = new BlockRecord(name);
            this.end = new BlockEnd(this.layer);
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets the block name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the block base point.
        /// </summary>
        public Vector3f BasePoint
        {
            get { return this.basePoint; }
            set { this.basePoint = value; }
        }

        /// <summary>
        /// Gets or sets the block <see cref="Layer">layer</see>.
        /// </summary>
        public Layer Layer
        {
            get { return this.layer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.layer = value;
                this.end.Layer = value;
            }
        }

        /// <summary>
        /// Gets or sets the block <see cref="AttributeDefinition">attribute definition</see> list.
        /// </summary>
        public Dictionary<string, AttributeDefinition> Attributes
        {
            get { return this.attributes; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("value");
                this.attributes = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IEntityObject">entity</see> list that makes the block.
        /// </summary>
        public List<IEntityObject> Entities
        {
            get { return this.entities; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("value");
                this.entities = value;
            }
        }

        public BlockRecord Record
        {
            get { return this.record; }
        }

        public BlockEnd End
        {
            get { return this.end; }
        }


        #endregion

        #region overrides

        /// <summary>
        /// Asigns a handle to the object based in a integer counter.
        /// </summary>
        /// <param name="entityNumber">Number to asign.</param>
        /// <returns>Next avaliable entity number.</returns>
        /// <remarks>
        /// Some objects might consume more than one, is, for example, the case of polylines that will asign
        /// automatically a handle to its vertexes. The entity number will be converted to an hexadecimal number.
        /// </remarks>
        public override int AsignHandle(int entityNumber)
        {
            entityNumber = this.record.AsignHandle(entityNumber);
            entityNumber = this.end.AsignHandle(entityNumber);
            foreach (AttributeDefinition attDef in this.attributes.Values)
            {
                entityNumber = attDef.AsignHandle(entityNumber);
            }
            foreach (IEntityObject entity in this.entities)
            {
                entityNumber = ((DxfObject)entity).AsignHandle(entityNumber);
            }
            return base.AsignHandle(entityNumber);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return this.name;
        }

        #endregion
    }
}