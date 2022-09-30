using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class NPC : InteractableObject 
    {
        public NPC()
        {
            graphic = "!";
            name = "npc";

            foreColor = ConsoleColor.DarkCyan;
            backColor = ConsoleColor.DarkBlue;
        }

        public override void Update(Player player)
        {
            onInteract(player);

        }

    }
}
