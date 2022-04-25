using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class TeleporterDestination : InteractableObject
    {
        public TeleporterDestination()
        {
            name = "Teleporter";
            graphic = "O";

            backColor = ConsoleColor.DarkGreen;
            foreColor = ConsoleColor.Red;

            xData = x;
            yData = y;
        }
    }
}
