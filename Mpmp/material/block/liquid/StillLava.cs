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
                public StillLavaBlock(int meta=0) : base(BlockIDs.STILL_LAVA, meta, "Still Lava") { }
    }
}
