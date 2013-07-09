using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpmp.API;

namespace Mpmp.inventory
{
    class Window
    {
         const int WINDOW_CHEST = 0;
         const int WINDOW_WORKBENCH = 1;
         const int WINDOW_FURNACE = 2;

        private PocketMinecraftServer server;
        public Window()
        {
            server = ServerAPI.request();
        }

    }
}
