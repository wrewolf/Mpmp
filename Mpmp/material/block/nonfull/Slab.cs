using Mpmp.API;
using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class SlabBlock : TransparentBlock
    {
        public SlabBlock() : this(0) { }
        public SlabBlock(int meta)
            : base(BlockIDs.SLAB, meta, "Slab")
        {
            var names = new Names();

            names[0] = "Stone";
            names[1] = "Sandstone";
            names[2] = "Wooden";
            names[3] = "Cobblestone";
            names[4] = "Brick";
            names[5] = "Stone Brick";
            names[6] = "Nether Brick";
            names[7] = "Quartz";

            this.name = ((this.meta & 0x08) == 0x08 ? "Upper " : "") + names[this.meta & 0x07] + " Slab";
            if ((this.meta & 0x08) == 0x08)
            {
                this.isFullBlock = true;
            }
            else
            {
                this.isFullBlock = false;
            }
        }

        public bool place(Item item, Player player, Block block, Block target, int face, double fx, double fy, double fz)
        {
            this.meta &= 0x07;
            if (face == 0)
            {
                if (target.getID() == BlockIDs.SLAB && (target.getMetadata() & 0x08) == 0x08 && (target.getMetadata() & 0x07) == (this.meta & 0x07))
                {
                    this.level.setBlock(target, BlockAPI.get(BlockIDs.DOUBLE_SLAB, this.meta));
                    return true;
                }
                else
                {
                    this.meta |= 0x08;
                }
            }
            else if (face == 1)
            {
                if (target.getID() == BlockIDs.SLAB && (target.getMetadata() & 0x08) == 0 && (target.getMetadata() & 0x07) == (this.meta & 0x07))
                {
                    this.level.setBlock(target, BlockAPI.get(BlockIDs.DOUBLE_SLAB, this.meta));
                    return true;
                }
            }
            else if (!player.entity.inBlock(block))
            {
                if (block.getID() == BlockIDs.SLAB)
                {
                    if ((block.getMetadata() & 0x07) == (this.meta & 0x07))
                    {
                        this.level.setBlock(block, BlockAPI.get(BlockIDs.DOUBLE_SLAB, this.meta));
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (fy > 0.5)
                    {
                        this.meta |= 0x08;
                    }
                }
            }
            else
            {
                return false;
            }
            if (block.getID() == SLAB && (target.getMetadata() & 0x07) != (this.meta & 0x07))
            {
                return false;
            }
            this.level.setBlock(block, this);
            return true;
        }

        public double getBreakTime(Item item, Player player)
        {
            if ((player.gamemode & 0x01) == 0x01)
            {
                return 0.20;
            }
            switch (this.meta & 0x07)
            {
                case 2:
                    if (item.isAxe() > 0)
                    {
                        return 0.40;
                    }
                    return 0.70;
                    break;
                case 0:
                case 1:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    switch (item.isPickaxe())
                    {
                        case 5:
                            return 0.4;
                        case 4:
                            return 0.5;
                        case 3:
                            return 0.75;
                        case 2:
                            return 0.25;
                        case 1:
                            return 1.5;
                        default:
                            return 10;
                    }
                    break;
            }
            return 10;
        }

        public Drops getDrops(Item item, Player player)
        {
            if (item.isPickaxe() >= 1)
            {
                return new Drops(this.id, this.meta & 0x07, 1);
            }
            else
            {
                return new Drops();
            }
        }
    }
}
