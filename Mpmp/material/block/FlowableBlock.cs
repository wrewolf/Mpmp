using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class FlowableBlock : TransparentBlock
    {
        public FlowableBlock(int id, int meta=0, string name = "Unknown")
            : base(id, meta, name)
        {
            this.isFlowable = true;
            this.isFullBlock = false;
            this.isSolid = false;
        }
    }
}
