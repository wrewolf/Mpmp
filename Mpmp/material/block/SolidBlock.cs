using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class SolidBlock : GenericBlock
    {
        public SolidBlock(int id) : this(id, 0) { }

        public SolidBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public SolidBlock(int id, int meta, string name)
            : base(id, meta, name)
        {
            this.isSolid = true;
            this.isFullBlock = true;
        }
    }
}
