using Mpmp.constants;
using Mpmp.material.block.misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class CakeBlock : TransparentBlock
    {
        public CakeBlock(int meta=0)
            : base(BlockIDs.CAKE_BLOCK, 0, "Cake Block")
        {
            this.isFullBlock = false;
            this.isActivable = true;
            this.meta = meta & 0x07;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops();
        }

        public bool onActivate(Item item, Player player)
        {
            if (player.entity.getHealth() < 20)
            {
                ++this.meta;
                player.entity.heal(3, "cake");
                if (this.meta >= 0x06)
                {
                    this.level.setBlock(this, new AirBlock());
                }
                else
                {
                    this.level.setBlock(this, this);
                }
                return true;
            }
            return false;
        }
    }
}
