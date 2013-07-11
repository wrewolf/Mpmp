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
        private float p1;
        private float p2;
        private float p3;
        private Level level1;

        public Position(float p1, float p2, float p3, Level level1)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.level1 = level1;
        }

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
