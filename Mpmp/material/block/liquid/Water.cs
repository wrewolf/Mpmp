using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.liquid
{
    class WaterBlock : LiquidBlock
    {
        public WaterBlock() : this(0) { }
        public WaterBlock(int meta) : base(BlockIDs.WATER, meta, "Water") { }
        public WaterBlock(int id, int meta, string name) : base(id, meta, name) { }

        public bool onUpdate(int type)
        {
            return false;
        }
    }
}
