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
    class TorchBlock : FlowableBlock
    {
        public TorchBlock() : this(0) { }
        public TorchBlock(int meta)
            : base(BlockIDs.TORCH, meta, "Torch") { }

        public bool onUpdate(int type)
        {
            if (type == GeneralConstants.BLOCK_UPDATE_NORMAL)
            {
                int side = this.getMetadata();
                var faces = new Faces();
                faces[1] = 4;
                faces[2] = 5;
                faces[3] = 2;
                faces[4] = 3;
                faces[5] = 0;
                faces[6] = 0;
                faces[0] = 0;

                if (this.getSide(faces[side]).isTransparent == true && !(side == 0 && this.getSide(0).getID() == BlockIDs.FENCE))
                { //Replace wit common break method
                    ServerAPI.request().api.entity.drop(this, BlockAPI.getItem(this.id, 0, 1));
                    this.level.setBlock(this, new AirBlock(), false);
                    return true;
                }
            }
            return false;
        }

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            if (target.isTransparent == false && face != 0)
            {
                var faces = new Faces();
                faces[1] = 5;
                faces[2] = 4;
                faces[3] = 3;
                faces[4] = 2;
                faces[5] = 1;

                this.meta = faces[face];
                this.level.setBlock(block, this);
                return true;
            }
            else if (this.getSide(0).isTransparent == false || this.getSide(0).getID() == BlockIDs.FENCE)
            {
                this.meta = 0;
                this.level.setBlock(block, this);
                return true;
            }
            return false;
        }
    }
}
