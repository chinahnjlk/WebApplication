using System;

namespace RTSafe.DxfCore.DxfCore
{
    /// <summary>
    /// Represents the base class for all dxf objects.
    /// </summary>
    public class DxfObject
    {
        #region private fields

        private readonly string codeName;
        private string handle;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>DxfObject</c> class.
        /// </summary>
        public DxfObject(string codeName)
        {
            this.codeName = codeName;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets the dxf entity type string.
        /// </summary>
        public string CodeName
        {
            get { return this.codeName; }
        }

        /// <summary>
        /// Gets or sets the handle asigned of the dxf object.
        /// </summary>
        /// <remarks>Only the getter is public.</remarks>
        public string Handle
        {
            get { return this.handle; }
            set { this.handle = value;}
        }

        #endregion

        #region public methods

        /// <summary>
        /// Asigns a handle to the object based in a integer counter.
        /// </summary>
        /// <param name="entityNumber">Number to asign.</param>
        /// <returns>Next avaliable entity number.</returns>
        /// <remarks>
        /// Some objects might consume more than one, is, for example, the case of polylines that will asign
        /// automatically a handle to its vertexes. The entity number will be converted to an hexadecimal number.
        /// </remarks>
        public virtual int AsignHandle(int entityNumber)
        {
            this.handle = Convert.ToString(entityNumber, 16);
            return entityNumber + 1;
        }

        #endregion
    }
}