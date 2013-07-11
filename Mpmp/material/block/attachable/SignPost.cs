using Mpmp.API;
using Mpmp.constants;
using Mpmp.material.block.misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.attachable
{
    class SignPostBlock : TransparentBlock
    {
        public SignPostBlock(int meta=0) :
            base(BlockIDs.SIGN_POST, meta, "Sign Post")
        {
            this.isSolid = false;
            this.isFullBlock = false;
        }

        public SignPostBlock(int id, int meta, string name)
            : base(id, meta, name)
        {
            this.isSolid = false;
            this.isFullBlock = false;
        }

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            if (face != 0)
            {
                var faces = new Faces();

                faces[2] = 2;
                faces[3] = 3;
                faces[4] = 4;
                faces[5] = 5;

                if (!faces.isset(face))
                {
                    this.meta = Math.Floor(((player.entity.yaw + 180) * 16 / 360) + 0.5) & 0x0F;
                    this.level.setBlock(block, BlockAPI.get(BlockIDs.SIGN_POST, this.meta));
                    return true;
                }
                else
                {
                    this.meta = faces[face];
                    this.level.setBlock(block, BlockAPI.get(BlockIDs.WALL_SIGN, this.meta));
                    return true;
                }
            }
            return false;
        }

        public bool onUpdate(int type)
        {
            if (type == GeneralConstants.BLOCK_UPDATE_NORMAL)
            {
                if (this.getSide(0).getID() == BlockIDs.AIR)
                { //Replace wit common break method
                    ServerAPI.request().api.entity.drop(this, BlockAPI.getItem(ItemIDs.SIGN, 0, 1));
                    this.level.setBlock(this, new AirBlock(), false);
                    return true;
                }
            }
            return false;
        }

        public bool onBreak(Item item, Player player)
        {
            this.level.setBlock(this, new AirBlock(), true, true);
            return true;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops(ItemIDs.SIGN, 0, 1);
        }
    }
}
