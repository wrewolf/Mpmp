using Mpmp.constants;
using Mpmp.world;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material
{
    class Block : Position
    {
        //public static List<KeyValuePair<int,string>> @class=new List<KeyValuePair<int,string>> {new KeyValuePair<int,string>(0,"AirBlock")};
        //public static Dictionary<int, string> @class = new Dictionary<int, string>();
        protected int id;
        public int meta;
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

        public static SortedList @class = new SortedList();
        public static int Inited = 0;
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
            if (Block.Inited == 0)
            {
                Block.@class.Add(BlockIDs.AIR, "AirBlock");
                Block.@class.Add(BlockIDs.STONE, "StoneBlock");
                Block.@class.Add(BlockIDs.GRASS, "GrassBlock");
                Block.@class.Add(BlockIDs.DIRT, "DirtBlock");
                Block.@class.Add(BlockIDs.COBBLESTONE, "CobblestoneBlock");
                Block.@class.Add(BlockIDs.PLANKS, "PlanksBlock");
                Block.@class.Add(BlockIDs.SAPLING, "SaplingBlock");
                Block.@class.Add(BlockIDs.BEDROCK, "BedrockBlock");
                Block.@class.Add(BlockIDs.WATER, "WaterBlock");
                Block.@class.Add(BlockIDs.STILL_WATER, "StillWaterBlock");
                Block.@class.Add(BlockIDs.LAVA, "LavaBlock");
                Block.@class.Add(BlockIDs.STILL_LAVA, "StillLavaBlock");
                Block.@class.Add(BlockIDs.SAND, "SandBlock");
                Block.@class.Add(BlockIDs.GRAVEL, "GravelBlock");
                Block.@class.Add(BlockIDs.GOLD_ORE, "GoldOreBlock");
                Block.@class.Add(BlockIDs.IRON_ORE, "IronOreBlock");
                Block.@class.Add(BlockIDs.COAL_ORE, "CoalOreBlock");
                Block.@class.Add(BlockIDs.WOOD, "WoodBlock");
                Block.@class.Add(BlockIDs.LEAVES, "LeavesBlock");
                Block.@class.Add(BlockIDs.GLASS, "GlassBlock");
                Block.@class.Add(BlockIDs.LAPIS_ORE, "LapisOreBlock");
                Block.@class.Add(BlockIDs.LAPIS_BLOCK, "LapisBlock");
                Block.@class.Add(BlockIDs.SANDSTONE, "SandstoneBlock");
                Block.@class.Add(BlockIDs.BED_BLOCK, "BedBlock");
                Block.@class.Add(BlockIDs.COBWEB, "CobwebBlock");
                Block.@class.Add(BlockIDs.TALL_GRASS, "TallGrassBlock");
                Block.@class.Add(BlockIDs.DEAD_BUSH, "DeadBushBlock");
                Block.@class.Add(BlockIDs.WOOL, "WoolBlock");
                Block.@class.Add(BlockIDs.DANDELION, "DandelionBlock");
                Block.@class.Add(BlockIDs.CYAN_FLOWER, "CyanFlowerBlock");
                Block.@class.Add(BlockIDs.BROWN_MUSHROOM, "BrownMushroomBlock");
                Block.@class.Add(BlockIDs.RED_MUSHROOM, "RedMushRoomBlock");
                Block.@class.Add(BlockIDs.GOLD_BLOCK, "GoldBlock");
                Block.@class.Add(BlockIDs.IRON_BLOCK, "IronBlock");
                Block.@class.Add(BlockIDs.DOUBLE_SLAB, "DoubleSlabBlock");
                Block.@class.Add(BlockIDs.SLAB, "SlabBlock");
                Block.@class.Add(BlockIDs.BRICKS_BLOCK, "BricksBlock");
                Block.@class.Add(BlockIDs.TNT, "TNTBlock");
                Block.@class.Add(BlockIDs.BOOKSHELF, "BookshelfBlock");
                Block.@class.Add(BlockIDs.MOSS_STONE, "MossStoneBlock");
                Block.@class.Add(BlockIDs.OBSIDIAN, "ObsidianBlock");
                Block.@class.Add(BlockIDs.TORCH, "TorchBlock");
                Block.@class.Add(BlockIDs.FIRE, "FireBlock");
                Block.@class.Add(BlockIDs.WOOD_STAIRS, "WoodStairsBlock");
                Block.@class.Add(BlockIDs.CHEST, "ChestBlock");
                Block.@class.Add(BlockIDs.DIAMOND_ORE, "DiamondOreBlock");
                Block.@class.Add(BlockIDs.DIAMOND_BLOCK, "DiamondBlock");
                Block.@class.Add(BlockIDs.WORKBENCH, "WorkbenchBlock");
                Block.@class.Add(BlockIDs.WHEAT_BLOCK, "WheatBlock");
                Block.@class.Add(BlockIDs.FARMLAND, "FarmlandBlock");
                Block.@class.Add(BlockIDs.FURNACE, "FurnaceBlock");
                Block.@class.Add(BlockIDs.BURNING_FURNACE, "BurningFurnaceBlock");
                Block.@class.Add(BlockIDs.SIGN_POST, "SignPostBlock");
                Block.@class.Add(BlockIDs.WOOD_DOOR_BLOCK, "WoodDoorBlock");
                Block.@class.Add(BlockIDs.LADDER, "LAdderBlock");
                Block.@class.Add(BlockIDs.COBBLESTONE_STAIRS, "CobblestoneStairsBlock");
                Block.@class.Add(BlockIDs.WALL_SIGN, "WallSignBlock");
                Block.@class.Add(BlockIDs.IRON_DOOR_BLOCK, "IronDoorBlock");
                Block.@class.Add(BlockIDs.REDSTONE_ORE, "RedstoneOreBlock");
                Block.@class.Add(BlockIDs.GLOWING_REDSTONE_ORE, "GlowingRedstoneOreBlock");
                Block.@class.Add(BlockIDs.SNOW_LAYER, "SnowLayerBlock");
                Block.@class.Add(BlockIDs.ICE, "IceBlock");
                Block.@class.Add(BlockIDs.SNOW_BLOCK, "SnowBlock");
                Block.@class.Add(BlockIDs.CACTUS, "CactusBlock");
                Block.@class.Add(BlockIDs.CLAY_BLOCK, "ClayBlock");
                Block.@class.Add(BlockIDs.SUGARCANE_BLOCK, "SugarcaneBlock");
                Block.@class.Add(BlockIDs.FENCE, "FenceBlock");
                Block.@class.Add(BlockIDs.NETHERRACK, "NetherrackBlock");
                Block.@class.Add(BlockIDs.SOUL_SAND, "SoulSandBlock");
                Block.@class.Add(BlockIDs.GLOWSTONE_BLOCK, "GlowstoneBlock");
                Block.@class.Add(BlockIDs.CAKE_BLOCK, "CakeBlock");
                Block.@class.Add(BlockIDs.TRAPDOOR, "TrapdoorBlock");
                Block.@class.Add(BlockIDs.STONE_BRICKS, "StoneBricksBlock");
                Block.@class.Add(BlockIDs.GLASS_PANE, "GlassPaneBlock");
                Block.@class.Add(BlockIDs.MELON_BLOCK, "MelonBlock");
                Block.@class.Add(BlockIDs.MELON_STEM, "MelonStemBlock");
                Block.@class.Add(BlockIDs.FENCE_GATE, "FenceGateBlock");
                Block.@class.Add(BlockIDs.BRICK_STAIRS, "BrickStairsBlock");
                Block.@class.Add(BlockIDs.STONE_BRICK_STAIRS, "StoneBrickStairsBlock");
                Block.@class.Add(BlockIDs.NETHER_BRICKS, "NetherBricksBlock");
                Block.@class.Add(BlockIDs.NETHER_BRICKS_STAIRS, "NetherBricksStairsBlock");
                Block.@class.Add(BlockIDs.SANDSTONE_STAIRS, "SandstoneStairsBlock");
                Block.@class.Add(BlockIDs.QUARTZ_BLOCK, "QuartzBlock");
                Block.@class.Add(BlockIDs.QUARTZ_STAIRS, "QuartzStairsBlock");
                Block.@class.Add(BlockIDs.STONECUTTER, "StonecutterBlock");
                Block.@class.Add(BlockIDs.GLOWING_OBSIDIAN, "GlowingObsidianBlock");
                Block.@class.Add(BlockIDs.NETHER_REACTOR, "NetherReactorBlock");
                Block.Inited = 1;
            }
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

        public Block getSide(int side)
        {
            Block v = base.getSide(side);

            try
            {
                return this.level.getBlock(v);
            }
            catch (Exception)
            {
                return v;
            }
        }

        public override string ToString()
        {
            return "Block " + this.name + " (" + this.id.ToString() + ":" + this.meta.ToString() + ")";
        }

        abstract bool isBreakable(Item item, Player player);
        abstract bool onBreak(Item item, Player player);
        abstract bool onActivate(Item item, Player player);
        abstract bool onUpdate(Block item);
        abstract bool onActivate(Item item, Player player, Block block, Block target, double face, double fx, double fy, double fz);
    }
}
