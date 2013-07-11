using Mpmp.constants;
using Mpmp.material.block.misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class SnowLayerBlock : FlowableBlock
    {
        public SnowLayerBlock(int meta = 0)
            : base(BlockIDs.SNOW_LAYER, meta, "Snow Layer")
        {
            this.isReplaceable = true;
            this.isSolid = false;
            this.isFullBlock = false;
        }

        public bool onUpdate(int type)
        {
            if (type == GeneralConstants.BLOCK_UPDATE_NORMAL)
            {
                if (this.getSide(0).getID() == BlockIDs.AIR)
                { //Replace wit common break method
                    this.level.setBlock(this, new AirBlock(), false);
                    return true;
                }
            }
            return false;
        }

        public Drops getDrops(Item item, Player player)
        {
            if (item.isShovel() > 0)
            {
                return new Drops(ItemIDs.SNOWBALL, 0, 1);
            }
            return new Drops();
        }
    }
}
