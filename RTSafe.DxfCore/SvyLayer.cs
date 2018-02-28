using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTSafe.DxfCore
{
    public class SvyLayer
    {
        public object ID { get; set; }
        public bool IsClose { get; set; }
        public string LayerName { get; set; }
        public int Type { get; set; }
    }
}
