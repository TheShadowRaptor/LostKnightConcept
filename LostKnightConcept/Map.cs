using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Map
    {
        static private char[,] map;

        public Map()
        {
            map = new char[,] 
            {
                {'*','*','*','*','*','*'},
                {'*','*','*','*','*','*'},
                {'*','*','*','*','*','*'},
                {'*','*','*','*','*','*'},
                {'*','*','*','*','*','*'},
                {'*','*','*','*','*','*'},
            };
        }

        public void DisplayMap()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Console.Write(map[x, y]);
                }
            }
        }
    }
}
