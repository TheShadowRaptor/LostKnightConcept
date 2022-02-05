using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Player
    {

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

        public void Update()
        {
            Draw();
            MovePlayer();
        }

        public void Draw()
        {
            // draws player position
            Console.SetCursorPosition(x, y);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine('+');
            Console.ResetColor();
        }

        public void MovePlayer()
        {
            // moves player with button input

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.W)
            {
                y--;
            }

            if (input.Key == ConsoleKey.A)
            {
                x--;
            }

            if (input.Key == ConsoleKey.D)
            {
                x++;
            }

            if (input.Key == ConsoleKey.S)
            {
                y++;
            }
            // waits for input before clearing map
            Console.Clear();
        }

        
    }

    
}
