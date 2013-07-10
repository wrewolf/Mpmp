using Mpmp.material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.world
{
    class Position
    {
        public Level level;
        public int x;

        public int y;

        public int z;

        internal Block getSide(Block side)
        {
            throw new NotImplementedException();
        }
        internal Block getSide(int side)
        {
            throw new NotImplementedException();
        }
    }
}
