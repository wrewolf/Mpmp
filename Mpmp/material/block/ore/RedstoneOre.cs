using Mpmp.API;
using Mpmp.constants;
using Mpmp.world;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.ore
{
    class RedstoneOreBlock : SolidBlock
    {
        	public RedstoneOreBlock():base(BlockIDs.REDSTONE_ORE, 0, "Redstone Ore"){
	}
	
	public int onUpdate(int type){
		if(type ==GeneralConstants.BLOCK_UPDATE_NORMAL || type == GeneralConstants.BLOCK_UPDATE_TOUCH){
			this.level.setBlock(this, BlockAPI.get(BlockIDs.GLOWING_REDSTONE_ORE, this.meta), false);
			this.level.scheduleBlockUpdate(new Position(this.x, this.y, this.z, this.level), Utils.getRandomUpdateTicks(), BLOCK_UPDATE_RANDOM);
			return GeneralConstants.BLOCK_UPDATE_WEAK;
		}
		return 0;
	}

	public Drops getDrops(Item item, Player player){
		if(item.isPickaxe() >= 2){
			return new Drops(
				//array(331, 4, mt_rand(4, 5)),
			);
		}else{
			return new Drops();
		}
	}
    }
}
