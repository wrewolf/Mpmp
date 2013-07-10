using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull.stairs
{
    class StoneBrickStairsBlock : StairBlock
    {
        public StoneBrickStairsBlock() : this(0) { }
        public StoneBrickStairsBlock(int meta) : base(BlockIDs.STONE_BRICK_STAIRS, meta, "Stone Brick Stairs") { }
    }
}
