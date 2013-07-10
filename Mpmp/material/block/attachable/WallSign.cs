using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.attachable
{
    class WallSignBlock : SignPostBlock
    {
        public WallSignBlock() : this(0) { }
        public WallSignBlock(int meta)
            : base(BlockIDs.WALL_SIGN, meta, "Wall Sign")
        {
        }

        public bool onUpdate(int type)
        {
            return false;
        }
    }
}
