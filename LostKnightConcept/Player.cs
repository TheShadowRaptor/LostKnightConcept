using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Player
    {
        private string name = "Guille";

        // fields
        private int startPositionX = 1;
        private int startPositionY = 1;

        private int x;
        private int y;
        public Player()
        {
            // instatiation
            x = startPositionX;
            y = startPositionY;
        }

        public void Update(Map map)
        {
            Draw(map);
            MovePlayer(map);            
        }

        public void Draw(Map map)
        {
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine('+');
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void MovePlayer(Map map)
        {
            // moves player with button input
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.W)
            {
                // move up
                y--;

                if(y < 0 || map.IsWall(x, y) == true)
                {
                    y++;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.A)
            {
                x--;
                if(x < 0 || map.IsWall(x, y) == true)
                {
                    x++;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.D)
            {
                x++;
                if(x >= map.mapData.GetLength(1) || map.IsWall(x, y) == true)
                {
                    x--;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.S)
            {
                y++;
                if (y >= map.mapData.GetLength(0) || map.IsWall(x, y) == true)
                {
                    y--;
                    map.boundsHit = false;
                }
            }
            Console.SetCursorPosition(0, 0);
        }   
        
        
    }

    
}
