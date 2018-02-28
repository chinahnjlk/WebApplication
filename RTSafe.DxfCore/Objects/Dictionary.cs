using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.Objects
{
    public class Dictionary :
        DxfObject,
        ITableObject
    {
        #region private fields

        private readonly string name;

        #endregion

        #region constants

        public static Dictionary Default
        {
            get { return new Dictionary("ACAD_GROUP"); }
        }

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>View</c> class.
        /// </summary>
        public Dictionary(string name)
            : base(DxfObjectCode.Dictionary)
        {
            this.name = name;
        }

        #endregion

        #region public properties

        #endregion

        #region ITableObject Members

        /// <summary>
        /// Gets the table name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        #endregion

        #region overrides

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