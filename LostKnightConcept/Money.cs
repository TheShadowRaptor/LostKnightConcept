using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    internal class Money : Collectable
    {
        public Money()
        {
            name = "Money";
            graphic = "$";

            backColor = ConsoleColor.Green;
            foreColor = ConsoleColor.DarkGreen;
        }
    }
}
