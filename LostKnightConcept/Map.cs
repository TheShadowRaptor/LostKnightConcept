using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class Map
    {
        private string name = "DarkPlains";
        // fields
        public char[,] mapData;

        public Map()
        {
            // gives map array the games map
            mapData = new char[,] 
            {
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','^','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                {'*','*','*','*','^','*','*','*','*','*','*','*','*','*','*','^','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','^','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','^','*','*','*','*','*','*','*'},
                {'*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*','*'},
                
            };
        }

        public void DisplayMap()
        {
            //------------------Top Map Border--------------------
            Console.Write("╔");
            for (int i = 0; i < mapData.GetLength(1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.WriteLine("");
            //----------------------------------------------------

            //------------------------Map-------------------------         

            for (int x = 0; x < mapData.GetLength(0); x++)
            {
                Console.Write("║");

                for (int y = 0; y < mapData.GetLength(1); y++)
                {
                    // colour the Map
                    ColourMap(x, y);

                    // draws map
                    Console.Write(mapData[x, y]);

                    // resets colour
                    Console.ResetColor();
                }
                Console.WriteLine("║");
            }

            //----------------------------------------------------

            //------------------Bottom Map Border-----------------
            Console.Write("╚");
            for (int i = 0; i < mapData.GetLength(1); i++)
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
            if (mapData[x, y] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
        }

        public bool IsFloor(int x, int y)
        {
            //Inner map bounds
            if (mapData[y, x] == '*')
            {
                return true;
            }
            return false;
        }

        public bool IsMapBounds(int x, int y)
        {
            if (x >= mapData.GetLength(1) || y >= mapData.GetLength(0) || x < 0 || y < 0)
            {
               return true;
            }
            else return false;
        }
    }
}
