using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull.stairs
{
    class QuartzStairsBlock : StairBlock
    {
        public QuartzStairsBlock() : this(0) { }
        public QuartzStairsBlock(int meta) : base(BlockIDs.QUARTZ_STAIRS, meta, "Quartz Stairs") { }
    }
}
