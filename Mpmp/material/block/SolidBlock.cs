using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block
{
    class SolidBlock : GenericBlock
    {
        public SolidBlock(int id, int meta=0, string name = "Unknown")
            : base(id, meta, name)
        {
            this.isSolid = true;
            this.isFullBlock = true;
        }
    }
}
