using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace LostKnightConcept
{
    class Map 
    {
        private string name;
        // fields
        public string[] map;
        public string mapFile = "Map.txt";
        public char mapData;

        public Map()
        {
            name = "DarkPlains";
            // gives map array the games map
            map = File.ReadAllLines(mapFile);
            map[0]
            map[1]            
            map[2]            
        }

        public void DisplayMap()
        {            
            Console.SetCursorPosition(0, 0);
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
                    Console.Write(map);

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
            Console.WriteLine("Map name = " + "{" + name + "}");
            //----------------------------------------------------            
        }

        public void ColourMap(int x, int y)
        {
            // colours spacific char in the map array
            /*if (map == '*')*/
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
        }

        public bool IsFloor(int x, int y)
        {
            //Inner map bounds
            /*if (map == '*')*/
            {
                return true;
            }
            return false;
        }

        public bool IsMapBounds(int x, int y)
        {
            if (x >= map.GetLength(1) || y >= map.GetLength(0) || x < 0 || y < 0)
            {
               return true;
            }
            return false;
        }
    }
}
