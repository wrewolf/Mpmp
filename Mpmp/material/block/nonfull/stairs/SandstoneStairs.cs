using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull.stairs
{
    class SandstoneStairsBlock : StairBlock
    {
        public SandstoneStairsBlock() : this(0) { }
        public SandstoneStairsBlock(int meta) : base(BlockIDs.SANDSTONE_STAIRS, meta, "Sandstone Stairs") { }
    }
}
