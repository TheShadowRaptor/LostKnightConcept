using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class DamageUp : Collectable
    {
        public DamageUp()
        {
            name = "DamageUp";
            graphic = "+";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.White;
        }       
    }
}
