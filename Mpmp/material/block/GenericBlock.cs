using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpmp.material.block.misc;
using Mpmp.world;
using Mpmp.API;

namespace Mpmp.material.block
{
    class GenericBlock : Block
    {
        public GenericBlock(int id) : this(id, 0) { }

        public GenericBlock(int id, int meta) : this(id, meta, "Unknown") { }

        public GenericBlock(int id, int meta, string name) : base(id, meta, name) { }

        public Block place(Item item, Player player, Block block, Block target, int face, int fx, int fy, int fz)
        {
            return this.level.setBlock(this, this, true, false, true);
        }

        public bool isBreakable(Item item, Player player)
        {
            return this.breakable;
        }

        public Block onBreak(Item item, Player player)
        {
            return this.level.setBlock(this, new AirBlock(), true, false, true);
        }

        public bool onUpdate(int type)
        {
            if (this.hasPhysics == true && type == GeneralConstants.BLOCK_UPDATE_NORMAL)
            {
                Block down = this.getSide(0);
                if (down.getID() == BlockIDs.AIR || down.isLiquid)
                {
                    Entity data = new Entity(this.x + 0.5, this.y + 0.5, this.z + 0.5, this.id);
                    PocketMinecraftServer server = ServerAPI.request();
                    this.level.setBlock(this, new AirBlock(), false, false, true);
                    Entity e = server.api.entity.add(this.level, GeneralConstants.ENTITY_FALLING, GeneralConstants.FALLING_SAND, data);
                    server.api.entity.spawnToAll(e);
                    server.api.block.blockUpdateAround(this, GeneralConstants.BLOCK_UPDATE_NORMAL, 1);
                }
                return false;
            }
            return false;
        }

        public bool onActivate(Item item, Player player)
        {
            return this.isActivable;
        }

        public Drops getDrops(Item item, Player player)
        {
            return new Drops(this.id, 0, 1);
        }
    }
}
