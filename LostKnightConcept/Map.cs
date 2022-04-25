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

        public int colume;
        public int row;

        private int mapRenderSizeX;
        private int mapRenderSizeY;

        public Map()
        {
            Global global = new Global();

            name = "DarkPlains";

            // gives map array the games map
            map = File.ReadAllLines(global.mapFile);

            colume = map[0].Length;
            row = map.Length;

            mapRenderSizeX = global.mapRenderSizeX;
            mapRenderSizeY = global.mapRenderSizeY;
        }
        
        public void DisplayMap(Render render)
        {       
            // resets cursor
            Console.SetCursorPosition(0, 0);

            //------------------Top Map Border--------------------
            Console.Write("╔");
            for (int i = 0; i < mapRenderSizeY; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.WriteLine("");
            //----------------------------------------------------

            //------------------------Map-------------------------         
            for (int x = 0; x < mapRenderSizeX; x++)
            {
                Console.Write("║");

                for (int y = 0; y < mapRenderSizeY; y++)
                {
                    // colour the Map
                    ColourMap(x, y, render);

                    // draws map             
                    render.MapDraw(y, x, map[x + render.camera.offsetX][y + render.camera.offsetY]);


                    // resets colour
                    Console.ResetColor();
                }
                Console.WriteLine("║");
            }

            //----------------------------------------------------

            //------------------Bottom Map Border-----------------
            Console.Write("╚");
            for (int i = 0; i < mapRenderSizeY; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");            
            Console.WriteLine("");
            Console.WriteLine("Map name = " + "{" + name + "}");
            //----------------------------------------------------            
        }

        public void ColourMap(int x, int y, Render render)
        {
            // colours spacific char in the map array
            if (map[x + render.camera.offsetX][y + render.camera.offsetY] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }

            if (map[x + render.camera.offsetX][y + render.camera.offsetY] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }

            if (map[x + render.camera.offsetX][y + render.camera.offsetY] == '=')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }

            if (map[x + render.camera.offsetX][y + render.camera.offsetY] == '▓')
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Blue;
            }

            if (map[x + render.camera.offsetX][y + render.camera.offsetY] == '≡')
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.Blue;
            }

        }
        public bool IsMapBounds(int x, int y)
        {
            if (x >= colume + 1 || y >= row + 1 || x < 1 || y < 1)
            {               
               return true;
            }
            return false;
        }

        public bool CheckCameraBoundX(int x, Global global)
        {
            
            if (x >= row - global.mapRenderSizeX + 1 || x < 0)
            {
                return true;
            }
            return false;
        }
        public bool CheckCameraBoundY(int y, Global global)
        {           
            if (y >= colume  - mapRenderSizeY + 1 || y < 0)
            {
                return true;
            }
            return false;
        }

        public bool IsFloor(int x, int y)
        {
            //Inner map bounds
            if (map[y][x] == '*' || map[y][x] == '≡')
            {
                return true;
            }
            return false;
        }

        public bool GhostBounds(int x, int y)
        {
            //Inner map bounds
            if (map[y][x] == '═' || map[y][x] == '║')
            {
                return true;
            }
            return false;
        }
    }
}
