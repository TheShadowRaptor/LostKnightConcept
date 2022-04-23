using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Key : Collectable
    {
        private const int startPosX = 7;
        private const int startPosy = 6;

        public int keys;
        public Key()
        {
            name = "Key";
            graphic = "F";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;

            x = startPosX;
            y = startPosy;

        }
    }
}
