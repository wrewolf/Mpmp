using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull.stairs
{
    class WoodStairsBlock : StairBlock
    {
                public WoodStairsBlock() : this(0) { }
                public WoodStairsBlock(int meta) : base(BlockIDs.WOOD_STAIRS, meta, "Wood Stairs") { }
    }
}
