using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Skeleton : Enemy
    {
        public Skeleton()
        {
            name = "Skeleton";
            graphic = "S";
            foreColor = ConsoleColor.Gray;
            backColor = ConsoleColor.White;
        }
    }
}
