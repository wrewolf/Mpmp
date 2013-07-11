using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.attachable
{
    class TrapdoorBlock : TransparentBlock
    {
        public TrapdoorBlock(int meta=0) :
            base(BlockIDs.TRAPDOOR, meta, "Trapdoor")
        {
            this.isActivable = true;
            if ((this.meta & 0x04) == 0x04)
            {
                this.isFullBlock = false;
            }
            else
            {
                this.isFullBlock = true;
            }
        }

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            if ((target.isTransparent == false || target.getID() == BlockIDs.SLAB) && face != 0 && face != 1)
            {
                var faces = new Faces();
                faces[2] = 0;
                faces[3] = 1;
                faces[4] = 2;
                faces[5] = 3;
                this.meta = faces[face] & 0x03;
                if (fy > 0.5)
                {
                    this.meta |= 0x08;
                }
                this.level.setBlock(block, this);
                return true;
            }
            return false;
        }

        public bool onActivate(Item item, Player player)
        {
            this.meta ^= 0x04;
            this.level.setBlock(this, this);
            return true;
        }
    }
}
