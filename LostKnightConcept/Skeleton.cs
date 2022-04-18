using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Skeleton : Enemy
    {
        private Random rng = new Random();

        public Skeleton()
        {
            name = "Skeleton";
            graphic = "S";
            health = 2;
            damage = 1;
            foreColor = ConsoleColor.Gray;
            backColor = ConsoleColor.White;
        }
    }
}
