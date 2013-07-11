using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.nonfull
{
    class IronDoorBlock : DoorBlock
    {
        public IronDoorBlock(int meta=0) : base(BlockIDs.IRON_DOOR_BLOCK, meta, "Iron Door Block") { }

        public double getBreakTime(Item  item, Player  player){
		if(( player.gamemode & 0x01) == 0x01){
			return 0.20;
		}		
		switch( item.isPickaxe()){
			case 5:
				return 0.95;
			case 4:
				return 1.25;
			case 3:
				return 1.9;
			case 2:
				return 0.65;
			case 1:
				return 3.75;
			default:
				return 25;
		}
	}
	
	public Drops getDrops(Item  item, Player  player){
		if( item.isPickaxe() >= 1){
			return new Drops(ItemIDs.IRON_DOOR, 0, 1);
		}else{
            return new Drops();
		}
	}
    }
}
