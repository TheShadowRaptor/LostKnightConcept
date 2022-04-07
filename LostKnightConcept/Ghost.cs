using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Ghost : Enemy
    {
        public Ghost()
        {
            name = "Ghost";
            graphic = "G";
            foreColor = ConsoleColor.Cyan;
            backColor = ConsoleColor.Blue;
        }
    }
}
