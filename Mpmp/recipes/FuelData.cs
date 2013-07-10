using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.recipes
{
    class FuelData
    {
        public static SortedList duration { get{
            if (Inited == 0)
            {
                throw new Exception("write this");
                Inited = 1;
            }
            return _duration;
        } }
        public static int Inited = 0;
        private static SortedList _duration;
    }
}
