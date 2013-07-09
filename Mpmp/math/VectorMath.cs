using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.math
{
    class VectorMath
    {
        public static Vector2 getDirection2D(double azimuth)
        {
            return new Vector2(Math.Cos(azimuth), Math.Sin(azimuth));
        }
    }
}
