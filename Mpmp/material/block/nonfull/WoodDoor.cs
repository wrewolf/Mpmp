using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class WoodDoorBlock : DoorBlock
    {
        public WoodDoorBlock(int meta=0)
            : base(BlockIDs.WOOD_DOOR_BLOCK, meta, "Wood Door Block")
        {
            this.isActivable = false;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops(ItemIDs.WOODEN_DOOR, 0, 1);
        }
    }
}
