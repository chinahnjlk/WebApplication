using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTSafe.DxfCore.Entities;

namespace RTSafe.DxfCore
{
    class Blocks
    {
        public class Block
        {
            public IEnumerable<Text> Entities { get; set; }

            public Vector3f BasePoint { get; set; }
        }
    }
}
