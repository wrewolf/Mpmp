using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.misc
{
    class FireBlock : FlowableBlock
    {
        public FireBlock(int meta=0)
            : base(BlockIDs.FIRE, meta, "Fire")
        {
            this.isReplaceable = true;
            this.breakable = false;
            this.isFullBlock = true;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops();
        }

        public bool onUpdate(int type)
        {
            if (type == GeneralConstants.BLOCK_UPDATE_NORMAL)
            {
                for (int s = 0; s <= 5; ++s)
                {
                    var side = this.getSide(s);
                    if (side.getID() != BlockIDs.AIR && !(side.isLiquid))
                    {
                        return false;
                    }
                }
                this.level.setBlock(this, new AirBlock(), false);
                return true;
            }
            else if (type == GeneralConstants.BLOCK_UPDATE_RANDOM)
            {
                if (this.getSide(0).getID() != BlockIDs.NETHERRACK)
                {
                    this.level.setBlock(this, new AirBlock(), false);
                    return true;
                }
            }
            return false;
        }
    }
}
