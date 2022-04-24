using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Teleporter : InteractableObjects
    {
        public Teleporter()
        {
            name = "Teleporter";
            graphic = "O";

            backColor = ConsoleColor.DarkGreen;
            foreColor = ConsoleColor.Blue;

            /*x = startPosX;
            y = startPosy;*/

            isActive = true;
        }
    }
}
