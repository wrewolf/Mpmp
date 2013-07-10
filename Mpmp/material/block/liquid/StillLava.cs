using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.liquid
{
    class StillLavaBlock : LiquidBlock
    {
                public StillLavaBlock() : this(0) { }
                public StillLavaBlock(int meta) : base(BlockIDs.STILL_LAVA, meta, "Still Lava") { }
    }
}
