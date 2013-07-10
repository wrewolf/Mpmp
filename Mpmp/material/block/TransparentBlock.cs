using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class TransparentBlock : GenericBlock
    {
        public TransparentBlock(int id) : this(id, 0) { }

        public TransparentBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public TransparentBlock(int id, int meta, string name)
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
