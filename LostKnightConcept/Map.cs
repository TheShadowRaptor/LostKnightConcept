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
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                
            };
        }

        public void DisplayMap()
        {
            //------------------Top Border--------------------
            Console.Write("╔");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.WriteLine("");

            //---------------------Map------------------------           

            //
            for (int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write("║");

                for (int y = 0; y < map.GetLength(1); y++)
                {
                    //Colour the Map
                    ColourMap(x, y);

                    //Draws map
                    Console.Write(map[x, y]);

                    //Resets colour
                    Console.ResetColor();
                }
                Console.WriteLine("║");
            }           


            //------------------Bottom Border--------------------
            Console.Write("╚");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
            Console.WriteLine("");
        }

        public void ColourMap(int x, int y)
        {

            if (map[x, y] == '*')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Green;
            }
        }
    }
}
