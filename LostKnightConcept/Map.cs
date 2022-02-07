using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Map
    {

        private string name = "DarkPlains";
        // fields
        public char[,] map;

        public Map()
        {
            // gives map array the games map
            map = new char[,] 
            {
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                
            };
        }

        public void DisplayMap()
        {
            //------------------Top Map Border--------------------
            Console.Write("╔");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.WriteLine("");
            //----------------------------------------------------

            //------------------------Map-------------------------         

            for (int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write("║");

                for (int y = 0; y < map.GetLength(1); y++)
                {
                    // colour the Map
                    ColourMap(x, y);

                    // draws map
                    Console.Write(map[x, y]);

                    // resets colour
                    Console.ResetColor();
                }
                Console.WriteLine("║");
            }

            //----------------------------------------------------

            //------------------Bottom Map Border-----------------
            Console.Write("╚");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
            Console.WriteLine("");
            //----------------------------------------------------
        }

        public void ColourMap(int x, int y)
        {
            // colours spacific char in the map array
            if (map[x, y] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
        }
    }
}
