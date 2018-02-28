using System;

namespace RTSafe.DxfCore.Entities
{
    /// <summary>
    /// Defines the polyline type.
    /// </summary>
    /// <remarks>Bit flag.</remarks>
    [Flags]
    public enum PolylineTypeFlags
    {
        OpenPolyline = 0,
        ClosedPolylineOrClosedPolygonMeshInM = 1,
        CurveFit = 2,
        SplineFit = 4,
        Polyline3D = 8,
        PolygonMesh = 16,
        ClosedPolygonMeshInN = 32,
        PolyfaceMesh = 64,
        ContinuousLineTypePatter = 128
    }

    /// <summary>
    /// Defines the curves and smooth surface type.
    /// </summary>
    public enum SmoothType
    {
        /// <summary>
        /// No smooth surface fitted
        /// </summary>
        NoSmooth=0,
        /// <summary>
        /// Quadratic B-spline surface
        /// </summary>
        Quadratic=5,
        /// <summary>
        /// Cubic B-spline surface
        /// </summary>
        Cubic=6,
        /// <summary>
        /// Bezier surface
        /// </summary>
        Bezier=8
    }
  
    /// <summary>
    /// Represents a generic polyline.
    /// </summary>
    public interface IPolyline :
        IEntityObject
    {
        /// <summary>
        /// Gets the polyline type.
        /// </summary>
        PolylineTypeFlags Flags { get; }
    }
}