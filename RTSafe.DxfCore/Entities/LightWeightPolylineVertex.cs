using System;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Represents a lightweight polyline vertex.
    /// </summary>
    public class LightWeightPolylineVertex
    {
        #region private fields

        protected const EntityType TYPE = EntityType.LightWeightPolylineVertex;
        protected Vector2f location;
        protected double beginThickness;
        protected double endThickness;
        protected double bulge;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>LightWeightPolylineVertex</c> class.
        /// </summary>
        public LightWeightPolylineVertex()
        {
            this.location = Vector2f.Zero;
            this.bulge = 0.0f;
            this.beginThickness = 0.0f;
            this.endThickness = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <c>LightWeightPolylineVertex</c> class.
        /// </summary>
        /// <param name="location">Lightweight polyline <see cref="netDxf.Vector2f">vertex</see> coordinates.</param>
        public LightWeightPolylineVertex(Vector2f location)
        {
            this.location = location;
            this.bulge = 0.0f;
            this.beginThickness = 0.0f;
            this.endThickness = 0.0f;
        }

        /// <summary>
        /// Initializes a new instance of the <c>LightWeightPolylineVertex</c> class.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public LightWeightPolylineVertex(double x, double y)
        {
            this.location = new Vector2f(x, y);
            this.bulge = 0.0f;
            this.beginThickness = 0.0f;
            this.endThickness = 0.0f;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the polyline vertex <see cref="netDxf.Vector2f">location</see>.
        /// </summary>
        public Vector2f Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        /// <summary>
        /// Gets or sets the light weight polyline begin thickness.
        /// </summary>
        public double BeginThickness
        {
            get { return this.beginThickness; }
            set { this.beginThickness = value; }
        }

        /// <summary>
        /// Gets or sets the light weight polyline end thickness.
        /// </summary>
        public double EndThickness
        {
            get { return this.endThickness; }
            set { this.endThickness = value; }
        }

        /// <summary>
        /// Gets or set the light weight polyline bulge. Accepted values range from -1 to 1.
        /// </summary>
        /// <remarks>
        /// The bulge is the tangent of one fourth the included angle for an arc segment, 
        /// made negative if the arc goes clockwise from the start point to the endpoint. 
        /// A bulge of 0 indicates a straight segment, and a bulge of 1 is a semicircle.
        /// </remarks>
        public double Bulge
        {
            get { return this.bulge; }
            set
            {                
                this.bulge = value;
            }
        }

        /// <summary>
        /// Gets the entity <see cref="netDxf.Entities.EntityType">type</see>.
        /// </summary>
        public EntityType Type
        {
            get { return TYPE; }
        }

        #endregion

        #region overrides

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return String.Format("{0} ({1})", TYPE, this.location);
        }

        #endregion
    }
}