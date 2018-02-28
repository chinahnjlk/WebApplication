namespace RTSafe.DxfCore
{
    /// <summary>
    /// Represents an entry in the extended data of an entity.
    /// </summary>
    public struct XDataRecord
    {
        #region private fields

        private object value;
        private int code;

        #endregion

        /// <summary>
        /// An extended data control string can be either “{”or “}?
        /// These braces enable applications to organize their data by subdividing the data into lists.
        /// The left brace begins a list, and the right brace terminates the most recent list. Lists can be nested
        /// </summary>
        public static XDataRecord OpenControlString
        {
            get { return new XDataRecord(XDataCode.ControlString, "{"); }
        }

        /// <summary>
        /// An extended data control string can be either "{" or "}".
        /// These braces enable applications to organize their data by subdividing the data into lists.
        /// The left brace begins a list, and the right brace terminates the most recent list. Lists can be nested
        /// </summary>
        public static XDataRecord CloseControlString
        {
            get { return new XDataRecord(XDataCode.ControlString, "}"); }
        }

        #region constructors

        /// <summary>
        /// Initializes a new XDataRecord.
        /// </summary>
        /// <param name="code">XData code.</param>
        /// <param name="value">XData value.</param>
        public XDataRecord(int code, object value)
        {
            this.code = code;
            this.value = value;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or set the XData code.
        /// </summary>
        public int Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        /// <summary>
        /// Gets or sets the XData value.
        /// </summary>
        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.code, this.value);
        }
    }
}