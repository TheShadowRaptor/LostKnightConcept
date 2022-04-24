using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Door : InteractableObjects
    {      
        public Door()
        {
            name = "LockedDoor";
            graphic = "]";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;

            x = startPosX;
            y = startPosy;

            isActive = true;
        }

        

        private void UnlockDoor(Player player)
        {
            xData = x;
            yData = y;

            if (player.xData == xData && player.yData == yData && player.keysHeld > 0)
            {
                player.keysHeld = player.keysHeld - 1;
                isActive = false;
            }
        }
    }
}
