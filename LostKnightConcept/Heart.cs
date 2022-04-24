using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Heart : Collectable
    {
        public Heart()
        {
            name = "Heart";
            graphic = "♥";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Red;
        }
    }
}
