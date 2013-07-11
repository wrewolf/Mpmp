using Mpmp.constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.material.block.ore
{
    class LapisOreBlock : SolidBlock
    {
        	public LapisOreBlock():base(BlockIDs.LAPIS_ORE, 0, "Lapis Ore"){
	}
	
	public double getBreakTime(Item item, Player player){
		if((player.gamemode & 0x01) == 0x01){
			return 0.20;
		}		
		switch(item.isPickaxe()){
			case 5:
				return 0.6;
			case 4:
				return 0.75;
			case 3:
				return 1.15;
			default:
				return 15;
		}
	}

	public Drops getDrops(Item item, Player player){
		if(item.isPickaxe() >= 3){
            var r = new Random();
			return new Drops(ItemIDs.DYE, 4, r.Next(4, 8));
		}else{
			return new Drops();
		}
	}
    }
}
