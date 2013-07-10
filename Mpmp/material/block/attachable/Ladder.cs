using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.attachable
{
    class LadderBlock : TransparentBlock
    {
        public LadderBlock() : this(0) { }
        public LadderBlock(int meta)
            : base(BlockIDs.LADDER, meta, "Ladder")
        {
            this.isSolid = false;
            this.isFullBlock = false;
        }
        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            if (target.isTransparent == false)
            {

                var faces = new Faces();
                faces[2] = 2;
                faces[3] = 3;
                faces[4] = 4;
                faces[5] = 5;
                if (faces.isset(face))
                {
                    this.meta = faces.get(face);
                    this.level.setBlock(block, this);
                    return true;
                }
            }
            return false;
        }
    }
}
