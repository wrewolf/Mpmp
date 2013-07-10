using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class LiquidBlock : TransparentBlock
    {
        public LiquidBlock(int id) : this(id, 0) { }

        public LiquidBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public LiquidBlock(int id, int meta, string name)
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
