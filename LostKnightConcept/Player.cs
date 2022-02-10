using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Player : Character
    {
        // fields
        private const int startPositionX = 1;
        private const int startPositionY = 1;

        public Player()
        {
            // instatiation
            health = 3;

            x = startPositionX;
            y = startPositionY;

            name = "Guille";
        }

        public void Update(Enemy enemy, Map map)
        {
                Draw();
                MovePlayer(map);
                hitEnemy(enemy);
                CheckIfAlive();
        }

        public void Draw()
        {          
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            xData = x;
            yData = y;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('+');
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void MovePlayer(Map map)
        {
            attackUp = false;
            attackDown = false;
            attackRight = false;
            attackLeft = false;
            attacked = false;

            // moves player with button input
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.W)
            {
                // move up
                y--;
                attackUp = true;

                if(map.IsWall(x, y) == true)
                {
                    y++;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    y++;
                    attacked = false;
                }
            }

            if (input.Key == ConsoleKey.A)
            {
                //move left
                x--;
                attackLeft = true;
                if(map.IsWall(x, y) == true)
                {
                    x++;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    x++;
                    attacked = false;
                }
            }

            if (input.Key == ConsoleKey.D)
            {
                //move right
                x++;
                attackRight = true;
                if(map.IsWall(x, y) == true)
                {
                    x--;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    x--;
                    attacked = false;
                }
            }

            if (input.Key == ConsoleKey.S)
            {
                //move down
                y++;
                attackDown = true;
                if (map.IsWall(x, y) == true)
                {
                    y--;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    y--;
                    attacked = false;
                }
            }          
        }
        public void hitEnemy(Enemy enemy)
        {
            if (yData + 1 == enemy.yData && xData == enemy.xData && attackDown == true)
            {
                attacked = true;
                Console.Beep();
                enemy.health -= 1;
            }

            if (yData - 1 == enemy.yData && xData == enemy.xData && attackUp == true)
            {
                attacked = true;
                Console.Beep();
                enemy.health -= 1;
            }

            if (xData + 1 == enemy.xData && yData == enemy.yData && attackRight == true)
            {
                attacked = true;
                Console.Beep();
                enemy.health -= 1;
            }

            if (xData - 1 == enemy.xData && yData == enemy.xData && attackLeft == true)
            {
                attacked = true;
                Console.Beep();
                enemy.health -= 1;
            }           
        }
        private void CheckIfAlive()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }
    }  
}
