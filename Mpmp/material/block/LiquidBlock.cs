using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class LiquidBlock : TransparentBlock
    {
        public LiquidBlock(int id, int meta=0, string name = "Unknown")
            : base(id, meta, name)
        {
            this.isLiquid = true;
            this.breakable = false;
            this.isReplaceable = true;
            this.isSolid = false;
            this.isFullBlock = true;
        }
    }
}
