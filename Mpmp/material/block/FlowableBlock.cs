using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class FlowableBlock : TransparentBlock
    {
        public FlowableBlock(int id) : this(id, 0) { }

        public FlowableBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public FlowableBlock(int id, int meta, string name)
            : base(id, meta, name)
        {
            this.isFlowable = true;
            this.isFullBlock = false;
            this.isSolid = false;
        }
    }
}
