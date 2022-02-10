using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Player : Character
    {
        private string name = "Guille";

        // fields
        private const int startPositionX = 1;
        private const int startPositionY = 1;

        
        public Player()
        {
            // instatiation
            x = startPositionX;
            y = startPositionY;
        }

        public void Update(Map map)
        {
            Draw();
            MovePlayer(map);            
        }

        public void Draw()
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

                if(map.IsWall(x, y) == true)
                {
                    y++;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.A)
            {
                //move left
                x--;
                if(map.IsWall(x, y) == true)
                {
                    x++;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.D)
            {
                //move right
                x++;
                if(map.IsWall(x, y) == true)
                {
                    x--;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.S)
            {
                //move down
                y++;
                if (map.IsWall(x, y) == true)
                {
                    y--;
                    map.boundsHit = false;
                }
            }
            Console.SetCursorPosition(0, 0);
        }   
        
        
    }

    
}
