namespace RTSafe.DxfCore
{
    /// <summary>
    /// Symbols for dxf text strings.
    /// </summary>
    /// <remarks>
    /// These special strings translates to symbols in AutoCad. 
    /// </remarks>
    public static class Symbols
    {
        /// <summary>
        /// Text string that shows as a diameter 'Ø' character.
        /// </summary>
        public const string Diameter = "%%c";

        /// <summary>
        /// Text string that shows as a degree '°' character.
        /// </summary>
        public const string Degree = "%%d";

        /// <summary>
        /// Text string that shows as a plus-minus '±' character.
        /// </summary>
        public const string PlusMinus = "%%p";
    }
}