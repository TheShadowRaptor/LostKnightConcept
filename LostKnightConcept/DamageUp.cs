using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class DamageUp : Collectable
    {
        private const int startPosX = 3;
        private const int startPosy = 4;
        public DamageUp()
        {
            name = "DamageUp";
            graphic = "+";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.White;

            x = startPosX;
            y = startPosy;
        }       
    }
}
