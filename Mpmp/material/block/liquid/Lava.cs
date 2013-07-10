using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.liquid
{
    class LavaBlock : LiquidBlock
    {
        public LavaBlock() : this(0) { }
        public LavaBlock(int meta) : base(BlockIDs.LAVA, meta, "Lava") { }
    }
}
