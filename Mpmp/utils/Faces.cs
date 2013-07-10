using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mpmp.material.block.attachable
{
    class Faces
    {
        private SortedList<int, int> keyValuePair;

        public Faces()
        {
            // TODO: Complete member initialization
            keyValuePair = new SortedList<int, int>();
            keyValuePair.Clear();
        }

        public int this[int index]
        {
            get { return this.keyValuePair[index]; }
            set { this.keyValuePair.Add(index, value); }
        }

        internal bool isset(int face)
        {
            return keyValuePair.ContainsKey(face);
        }

        internal int get(int face)
        {
            return keyValuePair[face];
        }

        internal void Add(KeyValuePair<int, int> kvp)
        {
            this.keyValuePair.Add(kvp.Key, kvp.Value);
        }
    }
}
