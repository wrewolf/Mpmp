using Mpmp.constants;
using Mpmp.material.block.attachable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class FenceGateBlock : TransparentBlock
    {
        public FenceGateBlock() : this(0) { }
        public FenceGateBlock(int meta)
            : base(BlockIDs.FENCE_GATE, meta, "Fence Gate")
        {
            this.isActivable = true;
            if ((this.meta & 0x04) == 0x04)
            {
                this.isFullBlock = true;
            }
            else
            {
                this.isFullBlock = false;
            }
        }

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz){
		 var faces = new Faces();
			faces[0]= 3;
			faces[1]= 0;
			faces[2]= 1;
			faces[3]= 2;
		);
		 this.meta =  faces[ player.entity.getDirection()] & 0x03;
		 this.level.setBlock( block,  this);
		return true;
	}
        public Drops getDrops(Item item, Player player)
        {
            return new Drops(this.id, 0, 1);
        }

        public bool onActivate(Item item, Player player)
        {
            var faces = new Faces();
            faces[0] = 3;
            faces[1] = 0;
            faces[2] = 1;
            faces[3] = 2;

            this.meta = (faces[player.entity.getDirection()] & 0x03) | ((~this.meta) & 0x04);
            this.level.setBlock(this, this);
            return true;
        }

    }
}
