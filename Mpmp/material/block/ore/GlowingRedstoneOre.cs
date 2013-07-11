using Mpmp.API;
using Mpmp.constants;
using Mpmp.utils;
using Mpmp.world;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.ore
{
    class GlowingRedstoneOreBlock : SolidBlock
    {
        	public GlowingRedstoneOreBlock():base(BlockIDs.GLOWING_REDSTONE_ORE, 0, "Glowing Redstone Ore"){}
	

	public int onUpdate(int type){
		if( type ==GeneralConstants.BLOCK_UPDATE_SCHEDULED ||  type == GeneralConstants.BLOCK_UPDATE_RANDOM){
			 this.level.setBlock( this, BlockAPI.get(BlockIDs.REDSTONE_ORE,  this.meta), false);			
			return GeneralConstants.BLOCK_UPDATE_WEAK;
		}else{
            this.level.scheduleBlockUpdate(new Position(this.x, this.y, this.z, this.level), Utils.getRandomUpdateTicks(), GeneralConstants.BLOCK_UPDATE_RANDOM);
		}
		return 0;
	}
	

	public double getBreakTime(Item  item, Player  player){
		if(( player.gamemode & 0x01) == 0x01){
			return 0.20;
		}		
		switch( item.isPickaxe()){
			case 5:
				return 0.6;
			case 4:
				return 0.75;
			default:
				return 15;
		}
	}
	
	public Drops getDrops(Item  item, Player  player){
		if( item.isPickaxe() >= 4){
            return new Drops();
		}else{
            return new Drops();
		}
	}
    }
}
