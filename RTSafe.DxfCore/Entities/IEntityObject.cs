using System.Collections.Generic;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Defines the entity type.
    /// </summary>
    public enum EntityType
    {
        /// <summary>
        /// line.
        /// </summary>
        Line,

        /// <summary>
        /// polyline.
        /// </summary>
        Polyline,

        /// <summary>
        /// 3d polyline .
        /// </summary>
        Polyline3d,

        /// <summary>
        /// lightweight polyline.
        /// </summary>
        LightWeightPolyline,

        /// <summary>
        /// polyface mesh.
        /// </summary>
        PolyfaceMesh,

        /// <summary>
        /// circle.
        /// </summary>
        Circle,

        /// <summary>
        /// nurbs curve
        /// </summary>
        NurbsCurve,

        /// <summary>
        /// ellipse.
        /// </summary>
        Ellipse,

        /// <summary>
        /// point.
        /// </summary>
        Point,

        /// <summary>
        /// arc.
        /// </summary>
        Arc,

        /// <summary>
        /// text string.
        /// </summary>
        Text,

        /// <summary>
        /// 3d face.
        /// </summary>
        Face3D,

        /// <summary>
        /// solid.
        /// </summary>
        Solid,

        /// <summary>
        /// block insertion.
        /// </summary>
        Insert,

        /// <summary>
        /// hatch.
        /// </summary>
        Hatch,

        /// <summary>
        /// attribute.
        /// </summary>
        Attribute,

        /// <summary>
        /// attribute definition.
        /// </summary>
        AttributeDefinition,

        /// <summary>
        /// lightweight polyline vertex.
        /// </summary>
        LightWeightPolylineVertex,

        /// <summary>
        /// polyline vertex.
        /// </summary>
        PolylineVertex,

        /// <summary>
        /// polyline 3d vertex.
        /// </summary>
        Polyline3dVertex,

        /// <summary>
        /// polyface mesh vertex.
        /// </summary>
        PolyfaceMeshVertex,

        /// <summary>
        /// polyface mesh face.
        /// </summary>
        PolyfaceMeshFace,

        /// <summary>
        /// dim.
        /// </summary>
        Dimension,

        /// <summary>
        /// A generi Vertex
        /// </summary>
        Vertex,
        /// <summary>
        /// 贝塞尔曲线
        /// </summary>
        Spline
    }

    /// <summary>
    /// Represents a generic entity.
    /// </summary>
    public interface IEntityObject
    {
        /// <summary>
        /// Gets the entity <see cref="EntityType">type</see>.
        /// </summary>
        EntityType Type { get; }

        /// <summary>
        /// Gets or sets the entity <see cref="AciColor">color</see>.
        /// </summary>
        AciColor Color { get; set; }

        /// <summary>
        /// Gets or sets the entity <see cref="Layer">layer</see>.
        /// </summary>
        Layer Layer { get; set; }

        /// <summary>
        /// Gets or sets the entity <see cref="LineType">line type</see.
        /// </summary>
        LineType LineType { get; set; }

        /// <summary>
        /// Gets or sets the entity <see cref="XData">extended data</see.
        /// </summary>
        Dictionary<ApplicationRegistry, XData> XData { get; set; }


    }
}