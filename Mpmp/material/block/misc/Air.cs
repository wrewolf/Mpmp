using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.misc
{
    class AirBlock : TransparentBlock
    {
        public AirBlock()
            : base(BlockIDs.AIR, 0, "Air")
        {
            this.isActivable = false;
            this.breakable = false;
            this.isFlowable = true;
            this.isTransparent = true;
            this.isReplaceable = true;
            this.isPlaceable = false;
            this.hasPhysics = false;
            this.isSolid = false;
            this.isFullBlock = true;
        }
    }
}
