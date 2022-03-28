﻿using System;
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

        public int row;
        public int column;

        public Map()
        {
            Global global = new Global();

            name = "DarkPlains";

            // gives map array the games map
            map = File.ReadAllLines(global.mapFile);
            row = map.Length;
            column = map[0].Length;

    }

        public void DisplayMap()
        {       
            // resets cursor
            Console.SetCursorPosition(0, 0);

            //------------------Top Map Border--------------------
            Console.Write("╔");
            for (int i = 0; i < column; i++)
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
                    Console.Write(map[x][y]);

                    // resets colour
                    Console.ResetColor();
                }
                Console.WriteLine("║");
            }

            //----------------------------------------------------

            //------------------Bottom Map Border-----------------
            Console.Write("╚");
            for (int i = 0; i < column; i++)
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
            if (map[x][y] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
        }
        public bool IsMapBounds(int x, int y)
        {
            if (x >= column || y >= row || x < 0 || y < 0)
            {
               return true;
            }
            return false;
        }

        public bool IsFloor(int x, int y)
        {
            //Inner map bounds
            if (map[y][x] == '*')
            {
                return true;
            }
            return false;
        }

    }
}
