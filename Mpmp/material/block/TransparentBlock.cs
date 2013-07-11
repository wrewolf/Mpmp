using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class TransparentBlock : GenericBlock
    {
        public TransparentBlock(int id, int meta=0, string name = "Unknown")
            : base(id, meta, name)
        {
            this.isActivable = false;
            this.breakable = true;
            this.isFlowable = false;
            this.isTransparent = true;
            this.isReplaceable = false;
            this.isPlaceable = true;
            this.isSolid = true;
        }
    }
}
