using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpmp.material.block.nonfull
{
    class Names
    {
        private SortedList<int, string> keyValuePair;

        public string this[int index]
        {
            get { return this.keyValuePair[index]; }
            set { this.keyValuePair.Add(index, value); }
        }

        internal bool isset(int face)
        {
            return keyValuePair.ContainsKey(face);
        }
    }
}
