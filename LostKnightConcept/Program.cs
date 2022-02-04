using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();

            map.DisplayMap();
            Console.ReadKey(true);
        }
    }
}
