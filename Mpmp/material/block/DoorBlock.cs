using Mpmp.API;
using Mpmp.material.block.misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class DoorBlock : TransparentBlock
    {
        public DoorBlock(int id) : this(id, 0) { }

        public DoorBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public DoorBlock(int id, int meta, string name)
            : base(id, meta, name)
        {
            this.isSolid = false;
        }

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            if (face == 1)
            {
                var blockUp = this.getSide(1);
                var blockDown = this.getSide(0);
                if (blockUp.isReplaceable == false || blockDown.isTransparent == true)
                {
                    return false;
                }
                var direction = player.entity.getDirection();
                var faces = new int[] { 3, 4, 2, 5 };
                var next = this.getSide(faces[((direction + 2) % 4)]);
                var next2 = this.getSide(faces[direction]);
                var metaUp = 0x08;
                if (next.getID() == this.id || (next2.isTransparent == false && next.isTransparent == true))
                { //Door hinge
                    metaUp |= 0x01;
                }
                this.level.setBlock(blockUp, BlockAPI.get(this.id, metaUp)); //Top

                this.meta = direction & 0x03;
                this.level.setBlock(block, this); //Bottom
                return true;
            }
            return false;
        }

        public bool onBreak(Item item, Player player)
        {
            if ((this.meta & 0x08) == 0x08)
            {
                var down = this.getSide(0);
                if (down.getID() == this.id)
                {
                    this.level.setBlock(down, new AirBlock());
                }
            }
            else
            {
                var up = this.getSide(1);
                if (up.getID() == this.id)
                {
                    this.level.setBlock(up, new AirBlock());
                }
            }
            this.level.setBlock(this, new AirBlock());
            return true;
        }

        public bool onActivate(Item item, Player player)
        {
            if ((this.meta & 0x08) == 0x08)
            { //Top
                var down = this.getSide(0);
                if (down.getID() == this.id)
                {
                    meta = down.getMetadata() ^ 0x04;
                    this.level.setBlock(down, BlockAPI.get(this.id, meta));
                    return true;
                }
                return false;
            }
            else
            {
                this.meta ^= 0x04;
                this.level.setBlock(this, this);
            }
            return true;
        }
    }
}
