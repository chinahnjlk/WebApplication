using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.DxfCore.Entities
{

    /// <summary>
    /// Represents the terminator element of a vertex sequence in polylines or attributes in a block reference.
    /// </summary>
    public class EndSequence :
        DxfObject
    {
        private Layer layer;

        /// <summary>
        /// Initializes a new instance of the <c>EndSequence</c> class.
        /// </summary>
        public EndSequence() : base(DxfObjectCode.EndSequence)
        {
            this.layer = Layer.Default;
        }

        /// <summary>
        /// Gets or sets the end sequence <see cref="DxfCore.Tables.Layer">layer</see>
        /// </summary>
        public Layer Layer
        {
            get { return this.layer; }
            set { if (value != null) this.layer = value; }
        }
    }
}