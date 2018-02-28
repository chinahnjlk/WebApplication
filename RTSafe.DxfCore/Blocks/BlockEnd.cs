using RTSafe.DxfCore.DxfCore;
using RTSafe.DxfCore.DxfCore.Tables;
using RTSafe.DxfCore.Tables;

namespace RTSafe.DxfCore.DxfCore.Blocks
{

    /// <summary>
    /// Represents the termination element of the block definiton.
    /// </summary>
    public class BlockEnd :
        DxfObject
    {
        private Layer layer;

        /// <summary>
        /// Initializes a new instance of the <c>BlockEnd</c> class.
        /// </summary>
        public BlockEnd(Layer layer) : base(DxfObjectCode.BlockEnd)
        {
            this.layer = layer;
        }

        /// <summary>
        /// Gets or sets the block end <see cref="DxfCore.Tables.Layer">layer</see>
        /// </summary>
        public Layer Layer
        {
            get { return this.layer; }
            set { if (value != null) this.layer = value; }
        }
    }
}