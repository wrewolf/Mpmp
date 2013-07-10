using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class CobwebBlock : FlowableBlock
    {
        public CobwebBlock()
            : base(BlockIDs.COBWEB, 0, "Cobweb")
        {
            this.isSolid = true;
            this.isFullBlock = false;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops();
        }
    }
}
