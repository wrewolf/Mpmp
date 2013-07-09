using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpmp.constants
{
    class GeneralConstants
    {

        public   const int PMF_LEVEL_DEFLATE_LEVEL = 6;

        //Gamemodes
        public   const int SURVIVAL = 0;
        public   const int CREATIVE = 1;
        public   const int ADVENTURE = 2;
        public   const int VIEW = 3;
        public   const int VIEWER = 3;


        //Players
        public   const int MAX_CHUNK_RATE = 20;
        public   const float max_chunks_per_second= 3.5f; //Default rate ~172 kB/s
        public   const int PLAYER_MAX_QUEUE = 1024;

        public   const int PLAYER_SURVIVAL_SLOTS = 36;
        public   const int PLAYER_CREATIVE_SLOTS = 111;


        //Block Updates
        public   const int BLOCK_UPDATE_NORMAL = 1;
        public   const int BLOCK_UPDATE_RANDOM = 2;
        public   const int BLOCK_UPDATE_SCHEDULED = 3;
        public   const int BLOCK_UPDATE_WEAK = 4;
        public   const int BLOCK_UPDATE_TOUCH = 5;


        //Entities
        public   const int ENTITY_PLAYER = 1;

        public   const int ENTITY_MOB = 2;
        public   const int MOB_CHICKEN = 10;
        public   const int MOB_COW = 11;
        public   const int MOB_PIG = 12;
        public   const int MOB_SHEEP = 13;

        public   const int MOB_ZOMBIE = 32;
        public   const int MOB_CREEPER = 33;
        public   const int MOB_SKELETON = 34;
        public   const int MOB_SPIDER = 35;
        public   const int MOB_PIGMAN = 36;

        public   const int ENTITY_OBJECT = 3;
        public   const int OBJECT_ARROW = 80;
        public   const int OBJECT_PAINTING = 83;

        public   const int ENTITY_ITEM = 4;

        public   const int ENTITY_FALLING = 5;
        public   const int FALLING_SAND = 66;


        //TileEntities
        public   const string TILE_SIGN = "Sign";
        public   const string TILE_CHEST = "Chest";
        public   const int CHEST_SLOTS = 27;
        public   const string TILE_FURNACE = "Furnace";
        public   const int FURNACE_SLOTS = 3;
    }
}
