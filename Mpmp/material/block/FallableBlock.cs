using Mpmp.API;
using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class FallableBlock : SolidBlock
    {
        public FallableBlock(int id) : this(id, 0) { }

        public FallableBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public FallableBlock(int id, int meta, string name)
            : base(id, meta, name)
        {
            this.hasPhysics = true;
        }

        public Block place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            Block ret = this.level.setBlock(this, this, true, false, true);
            ServerAPI.request().api.block.blockUpdate(this, GeneralConstants.BLOCK_UPDATE_NORMAL);
            return ret;
        }
    }
}
