namespace RTSafe.DxfCore
{
    /// <summary>
    /// Dxf sections.
    /// </summary>
    public static class StringCode
    {
        /// <summary>
        /// not defined.
        /// </summary>
        public const string Unknown = "";

        /// <summary>
        /// header.
        /// </summary>
        public const string HeaderSection = "HEADER";

        /// <summary>
        /// clases.
        /// </summary>
        public const string ClassesSection = "CLASSES";

        /// <summary>
        /// tables.
        /// </summary>
        public const string TablesSection = "TABLES";

        /// <summary>
        /// blocks.
        /// </summary>
        public const string BlocksSection = "BLOCKS";

        /// <summary>
        /// entities.
        /// </summary>
        public const string EntitiesSection = "ENTITIES";

        /// <summary>
        /// objects.
        /// </summary>
        public const string ObjectsSection = "OBJECTS";

        /// <summary>
        /// dxf name string.
        /// </summary>
        public const string BeginSection = "SECTION";

        /// <summary>
        /// end secction code.
        /// </summary>
        public const string EndSection = "ENDSEC";

        /// <summary>
        /// layers.
        /// </summary>
        public const string LayerTable = "LAYER";

        /// <summary>
        /// view ports.
        /// </summary>
        public const string ViewPortTable = "VPORT";

        /// <summary>
        /// views.
        /// </summary>
        public const string ViewTable = "VIEW";

        /// <summary>
        /// ucs.
        /// </summary>
        public const string UcsTable = "UCS";
        
        /// <summary>
        /// block records.
        /// </summary>
        public const string BlockRecordTable = "BLOCK_RECORD";

        /// <summary>
        /// line types.
        /// </summary>
        public const string LineTypeTable = "LTYPE";

        /// <summary>
        /// text styles.
        /// </summary>
        public const string TextStyleTable = "STYLE";

        /// <summary>
        /// dim styles.
        /// </summary>
        public const string DimensionStyleTable = "DIMSTYLE";

        /// <summary>
        /// extended data application registry.
        /// </summary>
        public const string ApplicationIDTable = "APPID";

        /// <summary>
        /// end table code.
        /// </summary>
        public const string EndTable = "ENDTAB";

        /// <summary>
        /// dxf name string.
        /// </summary>
        public const string Table = "TABLE";

        /// <summary>
        /// dxf name string.
        /// </summary>
        public const string BeginBlock = "BLOCK";

        /// <summary>
        /// end table code.
        /// </summary>
        public const string EndBlock = "ENDBLK";

        /// <summary>
        /// end of an element sequence
        /// </summary>
        public const string EndSequence = "SEQEND";

        /// <summary>
        /// dictionary
        /// </summary>
        public const string Dictionary = "DICTIONARY";

        /// <summary>
        /// end of file
        /// </summary>
        public const string EndOfFile = "EOF";
    }
}