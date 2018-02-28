namespace RTSafe.DxfCore
{
    /// <summary>
    /// Defines the text alignment.
    /// </summary>
    public enum TextAlignment
    {
        /// <summary>
        /// 左上 72=0 73=3
        /// </summary>
        TopLeft,
        /// <summary>
        /// 中上 72=1 73=3
        /// </summary>
        TopCenter,
        /// <summary>
        /// 右上 72=2 73=3
        /// </summary>
        TopRight,
        /// <summary>
        /// 左中 72=0 73=2
        /// </summary>
        MiddleLeft,
        /// <summary>
        /// 正中 72=1 73=2
        /// </summary>
        MiddleCenter,
        /// <summary>
        /// 右中 72=2 73=2
        /// </summary>
        MiddleRight,
        /// <summary>
        /// 左下 72=0 73=1
        /// </summary>
        BottomLeft,
        /// <summary>
        /// 中下 72=1 73=1
        /// </summary>
        BottomCenter,
        /// <summary>
        /// 右下 72=2 73=1
        /// </summary>
        BottomRight,
        /// <summary>
        /// 左 72=0 73=0
        /// </summary>
        BaselineLeft,
        /// <summary>
        /// 中心 72=1 73=0
        /// </summary>
        BaselineCenter,
        /// <summary>
        /// 右 72=2 73=0
        /// </summary>
        BaselineRight
    }
}