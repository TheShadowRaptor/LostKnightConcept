using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Door : InteractableObject
    {             
        public Door()
        {
            name = "LockedDoor";
            graphic = "]";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;
        }

        public override void Update(Player player)
        {
            if (isActive)
            {
                onInteract(player);
                UnlockDoor(player);
            }
        }

        private void UnlockDoor(Player player)
        {
            if (interacted && player.keysHeld > 0)
            {
                player.keysHeld = player.keysHeld - 1;
                isActive = false;
            }
        }
    }
}
