using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Key : Collectable
    {
        /*private const int startPosX = 2;
        private const int startPosy = 2;*/

        public Key()
        {
            name = "Key";
            graphic = "F";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;

            /*x = startPosX;
            y = startPosy;*/

        }
    }
}
