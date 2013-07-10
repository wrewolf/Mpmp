using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull.stairs
{
    class NetherBricksStairsBlock : StairBlock
    {
        public NetherBricksStairsBlock() : this(0) { }
        public NetherBricksStairsBlock(int meta) : base(BlockIDs.NETHER_BRICKS_STAIRS, meta, "Nether Bricks Stairs") { }
    }
}
