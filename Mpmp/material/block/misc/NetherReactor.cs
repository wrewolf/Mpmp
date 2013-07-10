using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.misc
{
    class NetherReactorBlock : SolidBlock
    {
        public NetherReactorBlock() : this(0) { }
        public NetherReactorBlock(int meta)
            : base(BlockIDs.NETHER_REACTOR, meta, "Nether Reactor")
        {
            this.isActivable = true;
        }
    }
}

