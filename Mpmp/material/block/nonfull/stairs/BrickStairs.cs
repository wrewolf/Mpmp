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
        public BrickStairsBlock() : this(0) { }
        public BrickStairsBlock(int meta) : base(BlockIDs.BRICK_STAIRS, meta, "Brick Stairs") { }
    }
}
