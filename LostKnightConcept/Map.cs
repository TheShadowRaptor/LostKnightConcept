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
        public string mapFile = "Map.txt";
        public string[] map;

        protected int row;
        protected int column;

        public Map()
        {
            name = "DarkPlains";

            // gives map array the games map
            map = File.ReadAllLines(mapFile);
            row = map.Length;
            column = map[0].Length;

    }

        public void DisplayMap()
        {            
            Console.SetCursorPosition(0, 0);
            //------------------Top Map Border--------------------
            Console.Write("╔");
            for (int i = 0; i < row; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.WriteLine("");
            //----------------------------------------------------

            //------------------------Map-------------------------         

            for (int x = 0; x < row; x++)
            {
                Console.Write("║");

                for (int y = 0; y < column; y++)
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
            for (int i = 0; i < row; i++)
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
            if (x >= row || y >= column || x < 0 || y < 0)
            {
               return true;
            }
            return false;
        }
    }
}
