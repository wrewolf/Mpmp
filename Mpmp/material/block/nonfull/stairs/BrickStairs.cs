using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull.stairs
{
    class BrickStairsBlock : StairBlock
    {
        public BrickStairsBlock(int meta=0) : base(BlockIDs.BRICK_STAIRS, meta, "Brick Stairs") { }
    }
}
