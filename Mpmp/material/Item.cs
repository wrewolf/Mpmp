using Mpmp.API;
using Mpmp.constants;
using Mpmp.recipes;
using Mpmp.world;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material
{
    class Item
    {
        public int id;
        public int meta;
        public String name;
        protected Block block = BlockAPI.get(BlockIDs.AIR);
        public int count;
        protected int maxStackSize = 64;
        protected int durability = 0;
        public bool isActivable = false;

        public static SortedList @class = new SortedList();
        public static int Inited = 0;

        public Item(int id, int meta = 0, int count = 1, string name = "Unknown")
        {
            this.id = id;
            this.meta = meta;
            this.@count = count;
            this.name = name;
            if (this.id <= 0xff && Block.@class.ContainsKey(this.id))
            {
                this.block = BlockAPI.get(this.id, this.meta);
                this.name = this.block.getName();
            }

            if (this.isTool() != false)
            {
                this.maxStackSize = 1;
            }

            if (Item.Inited == 0)
            {
                Item.@class.Add(ItemIDs.SUGARCANE, "SugarcaneItem");
                Item.@class.Add(ItemIDs.WHEAT_SEEDS, "WheatSeedsItem");
                Item.@class.Add(ItemIDs.MELON_SEEDS, "MelonSeedsItem");
                Item.@class.Add(ItemIDs.SIGN, "SignItem");
                Item.@class.Add(ItemIDs.WOODEN_DOOR, "WoodenDoorItem");
                Item.@class.Add(ItemIDs.BUCKET, "BucketItem");
                Item.@class.Add(ItemIDs.IRON_DOOR, "IronDoorItem");
                Item.@class.Add(ItemIDs.CAKE, "CakeItem");
                Item.@class.Add(ItemIDs.BED, "BedItem");
                Item.@class.Add(ItemIDs.PAINTING, "PaintingItem");
                Item.@class.Add(ItemIDs.COAL, "CoalItem");
                Item.@class.Add(ItemIDs.APPLE, "AppleItem");
                Item.@class.Add(ItemIDs.SPAWN_EGG, "SpawnEggItem");
                Item.@class.Add(ItemIDs.DIAMOND, "DiamondItem");
                Item.@class.Add(ItemIDs.STICK, "StickItem");
                Item.@class.Add(ItemIDs.BOWL, "BowlItem");
                Item.@class.Add(ItemIDs.FEATHER, "FeatherItem");
                Item.@class.Add(ItemIDs.BRICK, "BrickItem");
                Item.@class.Add(ItemIDs.IRON_INGOT, "IronIngotItem");
                Item.@class.Add(ItemIDs.GOLD_INGOT, "GoldIngotItem");
                Item.@class.Add(ItemIDs.IRON_SHOVEL, "IronShovelItem");
                Item.@class.Add(ItemIDs.IRON_PICKAXE, "IronPickaxeItem");
                Item.@class.Add(ItemIDs.IRON_AXE, "IronAxeItem");
                Item.@class.Add(ItemIDs.IRON_HOE, "IronHoeItem");
                Item.@class.Add(ItemIDs.WOODEN_SWORD, "WoodenSwordItem");
                Item.@class.Add(ItemIDs.WOODEN_SHOVEL, "WoodenShovelItem");
                Item.@class.Add(ItemIDs.WOODEN_PICKAXE, "WoodenPickaxeItem");
                Item.@class.Add(ItemIDs.WOODEN_AXE, "WoodenAxeItem");
                Item.@class.Add(ItemIDs.FLINT_STEEL, "FlintSteelItem");
                Item.Inited = 1;
            }
        }

        public string getName()
        {
            return this.name;
        }

        public bool isPlaceable()
        {
            return this.block.isPlaceable;
        }

        public Block getBlock()
        {
            return this.block;
        }

        public int getID()
        {
            return this.id;
        }

        public int getMetadata()
        {
            return this.meta;
        }

        public int getMaxStackSize()
        {
            return this.maxStackSize;
        }

        public double getFuelTime()
        {
            if (!FuelData.duration.ContainsKey(this.id))
            {
                return 0;
            }
            if (this.id != ItemIDs.BUCKET || this.meta == 10)
            {
                return (int)FuelData.duration.GetByIndex(this.id);
            }
            return 0;
        }

        public void useOn()
        {
            if (this.isTool())
            {
                this.meta++;
            }
        }

        public bool isTool()
        {
            return (this.id == ItemIDs.FLINT_STEEL || this.id == ItemIDs.SHEARS || this.isPickaxe() != 0 || this.isAxe() != 0 || this.isShovel() != 0 || this.isSword() != 0 || this.isHoe() != 0);
        }

        public int isPickaxe()
        { //Returns false or level of the pickaxe
            switch (this.id)
            {
                case ItemIDs.IRON_PICKAXE:
                    return 4;
                case ItemIDs.WOODEN_PICKAXE:
                    return 1;
                case ItemIDs.STONE_PICKAXE:
                    return 3;
                case ItemIDs.DIAMOND_PICKAXE:
                    return 5;
                case ItemIDs.GOLD_PICKAXE:
                    return 2;
                default:
                    return 0;
            }
        }

        public int isAxe()
        {
            switch (this.id)
            {
                case ItemIDs.IRON_AXE:
                    return 4;
                case ItemIDs.WOODEN_AXE:
                    return 1;
                case ItemIDs.STONE_AXE:
                    return 3;
                case ItemIDs.DIAMOND_AXE:
                    return 5;
                case ItemIDs.GOLD_AXE:
                    return 2;
                default:
                    return 0;
            }
        }

        public int isSword()
        {
            switch (this.id)
            {
                case ItemIDs.IRON_SWORD:
                    return 4;
                case ItemIDs.WOODEN_SWORD:
                    return 1;
                case ItemIDs.STONE_SWORD:
                    return 3;
                case ItemIDs.DIAMOND_SWORD:
                    return 5;
                case ItemIDs.GOLD_SWORD:
                    return 2;
                default:
                    return 0;
            }
        }

        public int isShovel()
        {
            switch (this.id)
            {
                case ItemIDs.IRON_SHOVEL:
                    return 4;
                case ItemIDs.WOODEN_SHOVEL:
                    return 1;
                case ItemIDs.STONE_SHOVEL:
                    return 3;
                case ItemIDs.DIAMOND_SHOVEL:
                    return 5;
                case ItemIDs.GOLD_SHOVEL:
                    return 2;
                default:
                    return 0;
            }
        }

        public int isHoe()
        {
            switch (this.id)
            {
                case ItemIDs.IRON_HOE:
                case ItemIDs.WOODEN_HOE:
                case ItemIDs.STONE_HOE:
                case ItemIDs.DIAMOND_HOE:
                case ItemIDs.GOLD_HOE:
                    return 1;
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            return "Item " + this.name.ToString() + " (" + this.id.ToString() + ":" + this.meta.ToString() + ")";
        }

        public double getDestroySpeed(Block block, Player player)
        {
            return 1;
        }

        public bool onActivate(Level level, Player player, Block block, Block target, double face, double fx, double fy, double fz)
        {
            return false;
        }
    }
}
