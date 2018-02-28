using System;
using System.Collections.Generic;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore
{
    /// <summary>
    /// Represents the extended data information of an entity.
    /// </summary>
    public class XData
    {
        #region private fields

        private readonly ApplicationRegistry appReg;
        private List<XDataRecord> xData;

        #endregion

        #region constructors

        /// <summary>
        /// Initialize a new instance of the <c>XData</c> class .
        /// </summary>
        /// <param name="appReg">Name of the application associated with the list of extended data records.</param>
        public XData(ApplicationRegistry appReg)
        {
            this.appReg = appReg;
            this.xData = new List<XDataRecord>();
        }

        #endregion

        #region public propertyes

        /// <summary>
        /// Gets the name of the application associated with the list of extended data records.
        /// </summary>
        public ApplicationRegistry ApplicationRegistry
        {
            get { return this.appReg; }
        }

        /// <summary>
        /// Gets or sets the list of extended data records.
        /// </summary>
        /// <remarks>
        /// This list cannot contain a XDataRecord with a XDataCode of AppReg, this code is reserved to register the name of the application.
        /// Any record with this code will be ommited.
        /// </remarks>
        public List<XDataRecord> XDataRecord
        {
            get { return this.xData; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("value");
                this.xData = value;
            }
        }

        #endregion

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return this.ApplicationRegistry.Name;
        }
    }
}