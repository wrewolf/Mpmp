using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.liquid
{
    class StillWaterBlock : WaterBlock
    {
        public StillWaterBlock(int meta=0) : base(BlockIDs.STILL_WATER, meta, "Still Water") { }
    }
}
