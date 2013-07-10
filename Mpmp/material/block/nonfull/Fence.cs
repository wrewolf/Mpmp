using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class FenceBlock : TransparentBlock
    {
        public FenceBlock()
            : base(BlockIDs.FENCE, 0, "Fence")
        {
            this.isFullBlock = false;
        }
    }
}
