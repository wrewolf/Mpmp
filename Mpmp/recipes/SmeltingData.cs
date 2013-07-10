using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.recipes
{
    class SmeltingData
    {
        public static SortedList product
        {
            get
            {
                if (Inited == 0)
                {
                    throw new Exception("write this");
                    /**
                     * 		COBBLESTONE => array(STONE, 0),
                     * 		SAND => array(GLASS, 0),
                     * 		TRUNK => array(COAL, 1), //Charcoal
                     * 		GOLD_ORE => array(GOLD_INGOT, 0),
                     * 		IRON_ORE => array(IRON_INGOT, 0),
                     * 		NETHERRACK => array(NETHER_BRICK, 0),
                     * 		RAW_PORKCHOP => array(COOKED_PORKCHOP, 0),
                     * 		CLAY => array(BRICK, 0),
                     * 		RAW_FISH => array(COOKED_FISH, 0),
                     * 		CACTUS => array(DYE, 2),
                     * 		RED_MUSHROOM => array(DYE, 1),
                     * 		RAW_BEEF => array(STEAK, 0),
                     * 		RAW_CHICKEN => array(COOKED_CHICKEN, 0),
                     * 		RED_MUSHROOM => array(DYE, 1),
                     */ 

                    Inited = 1;
                }
                return _product;
            }
        }
        public static int Inited = 0;
        private static SortedList _product;
        
    }
}
