using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Ghoul : Enemy
    {
        public Ghoul()
        {
            name = "Ghoul";
            graphic = "G";
            foreColor = ConsoleColor.White;
            backColor = ConsoleColor.Red;
        }
    }
}
