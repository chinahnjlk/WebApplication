namespace RTSafe.DxfCore
{
    /// <summary>
    /// Represents the minimun information element in a dxf file.
    /// </summary>
    public struct CodeValuePair
    {
        private readonly int code;
        private readonly string value;

        /// <summary>
        /// Initalizes a new instance of the <c>CodeValuePair</c> class.
        /// </summary>
        /// <param name="code">Dxf code.</param>
        /// <param name="value">Value for the specified code.</param>
        public CodeValuePair(int code, string value)
        {
            this.code = code;
            this.value = value;
        }

        /// <summary>
        /// Gets the dxf code.
        /// </summary>
        public int Code
        {
            get { return this.code; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }
    }
}