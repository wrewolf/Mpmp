using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class StairBlock : TransparentBlock
    {
        public StairBlock(int id, int meta=0, string name = "Unknown")
            : base(id, meta, name)
        {
            if ((this.meta & 0x04) == 0x04)
            {
                this.isFullBlock = true;
            }
            else
            {
                this.isFullBlock = false;
            }
        }


        public Drops getDrops(Item item, Player player)
        {
            if (item.isPickaxe() >= 1)
            {
                return new Drops(this.id, 0, 1);
            }
            else
            {
                return new Drops();
            }
        }
    }
}
