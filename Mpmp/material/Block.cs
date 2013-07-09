using Mpmp.constants;
using Mpmp.world;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material
{
    class Block : Position
    {
        //public static List<KeyValuePair<int,string>> @class=new List<KeyValuePair<int,string>> {new KeyValuePair<int,string>(0,"AirBlock")};
        public static Dictionary<int, string> @class = new Dictionary<int, string>();
        protected int id;
        protected int meta;
        protected string name;
        protected float breakTime;
        public bool isActivable = false;
        public bool breakable = true;
        public bool isFlowable = false;
        public bool isSolid = true;
        public bool isTransparent = false;
        public bool isReplaceable = false;
        public bool isPlaceable = true;
        public Level level = null;
        public bool hasPhysics = false;
        public bool isLiquid = false;
        public bool isFullBlock = true;
        public float x = 0;
        public float y = 0;
        public float z = 0;


        public Block(int id)
            : this(id, 0) { }

        public Block(int id, int meta)
            : this(id, meta, "Unknown") { }

        public Block(int id, int meta, string name)
        {
            this.id = (int)id;
            this.meta = (int)meta;
            this.name = name;
            this.breakTime = 0.20f;
        }

        public string getName()
        {
            return this.name;
        }

        public int getID()
        {
            return this.id;
        }

        public int getMetadata()
        {
            return this.meta & 0x0F;
        }

        public void position(Position v)
        {
            this.level = v.level;
            this.x = (int)v.x;
            this.y = (int)v.y;
            this.z = (int)v.z;
        }

        public int[] getDrops(Item item, Player player)
        {
            if (!@class.ContainsKey(this.id))
            {
                return new int[3];
            }
            else
            {
                return new int[] { this.id, this.meta, 1 };
            }
        }

        public float getBreakTime(Item item, Player player)
        {
            if ((player.gamemode & 0x01) == 0x01)
            {
                return 0.15f;
            }
            else
            {
                return this.breakTime;
            }
        }

        public int getSide(int side)
        {
            int v= base.getSide(side);
            if(this.level.GetType() == typeof(Level))
            {
                return this.level.getBlock(v);
            }
            return v;
        }

        public override string ToString()
        {
            return "Block "+this.name +" ("+this.id.ToString()+":"+this.meta.ToString()+")";
        }
    }
}
