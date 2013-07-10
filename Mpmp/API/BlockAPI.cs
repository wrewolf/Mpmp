using Mpmp.material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.API
{
    class BlockAPI
    {
        internal static Block get(int id, int meta)
        {
            throw new NotImplementedException();
        }

        internal static Block get(int id)
        {
            return BlockAPI.get(id, 0);
        }

        internal static Item getItem(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        internal static object getItem(int p1, int p2, int p3)
        {
            throw new NotImplementedException();
        }
    }
}
