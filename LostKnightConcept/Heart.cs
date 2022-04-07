using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Heart : CollectableClass
    {
        private const int startPosX = 4;
        private const int startPosy = 4;
        public Heart()
        {
            name = "Heart";
            graphic = "♥";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Red;

            x = startPosX;
            y = startPosy;

        }
    }
}
