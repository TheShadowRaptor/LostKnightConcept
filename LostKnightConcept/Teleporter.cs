using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Teleporter : InteractableObject
    {       
        public Teleporter()
        {
            name = "Teleporter";
            graphic = "O";

            backColor = ConsoleColor.DarkGreen;
            foreColor = ConsoleColor.Blue;

            xData = x;
            yData = y;
        }

        public override void Update(Player player)
        {
            onInteract(player);
        }
    }
}
