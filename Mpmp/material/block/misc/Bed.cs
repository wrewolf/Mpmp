using Mpmp.constants;
using Mpmp.material.block.attachable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.misc
{
    class BedBlock : TransparentBlock
    {
        public BedBlock()
            : base(BlockIDs.BED_BLOCK, 0, "Bed Block")
        {
            this.isActivable = true;
            this.isFullBlock = false;
        }

        public bool onActivate(Item item, Player player){
		player.dataPacket(MC_CLIENT_MESSAGE, array(
			"message" => "This bed has been corrupted by your hands!"
		));
		return true;
	}

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz){
			var down = this.getSide(0);
			if(down.isTransparent == false){
                                var faces = new Faces();
					faces[0 ]= 3;
					faces[1 ]= 4;
					faces[2 ]= 2;
					faces[3 ]= 5;

				var d = player.entity.getDirection();
				var next = this.getSide(faces[((d + 3) % 4)]);
				var downNext = this.getSide(0);
				if(next.isReplaceable === true and downNext.isTransparent == false){
					meta = ((d + 3) % 4) & 0x03;
					this.level.setBlock(block, BlockAPI.get(this.id, meta));
					this.level.setBlock(next, BlockAPI.get(this.id, meta | 0x08));
					return true;
				}
			}
		return false;
	}

        public bool onBreak(Item item, Player player)
        {
            var blockNorth = this.getSide(2); //Gets the blocks around them
            var blockSouth = this.getSide(3);
            var blockEast = this.getSide(5);
            var blockWest = this.getSide(4);

            if ((this.meta & 0x08) == 0x08)
            { //This is the Top part of bed			
                if (blockNorth.getID() == this.id && blockNorth.meta != 0x08)
                { //Checks if the block ID and meta are right
                    this.level.setBlock(blockNorth, new AirBlock());
                }
                else if (blockSouth.getID() == this.id && blockSouth.meta != 0x08)
                {
                    this.level.setBlock(blockSouth, new AirBlock());
                }
                else if (blockEast.getID() == this.id && blockEast.meta != 0x08)
                {
                    this.level.setBlock(blockEast, new AirBlock());
                }
                else if (blockWest.getID() == this.id && blockWest.meta != 0x08)
                {
                    this.level.setBlock(blockWest, new AirBlock());
                }
            }
            else
            { //Bottom Part of Bed
                if (blockNorth.getID() == this.id && (blockNorth.meta & 0x08) == 0x08)
                {
                    this.level.setBlock(blockNorth, new AirBlock());
                }
                else if (blockSouth.getID() == this.id && (blockSouth.meta & 0x08) == 0x08)
                {
                    this.level.setBlock(blockSouth, new AirBlock());
                }
                else if (blockEast.getID() == this.id && (blockEast.meta & 0x08) == 0x08)
                {
                    this.level.setBlock(blockEast, new AirBlock());
                }
                else if (blockWest.getID() == this.id && (blockWest.meta & 0x08) == 0x08)
                {
                    this.level.setBlock(blockWest, new AirBlock());
                }
            }
            this.level.setBlock(this, new AirBlock());
            return true;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops(ItemIDs.BED, 0, 1);
        }
    }
}
