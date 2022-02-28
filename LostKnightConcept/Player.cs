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
            health = 2;

            x = startPositionX;
            y = startPositionY;

            name = "Guille";
        }

        public void Update(Enemy enemy, Map map)
        {
            CheckIfDead();
            
            if(isAlive)
            {
                checkIfOnEnemy(enemy);
                Draw();           
                MovePlayer(map, enemy);
            }
                           
                
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

        public void MovePlayer(Map map, Enemy enemy)
        {
            // moves player with button input          
            bool inputLoop;
            inputLoop = true;           

            if(hitEnemy == false)
            {
                while (inputLoop == true)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    if (input.Key == ConsoleKey.W)
                    {
                        // move up
                        y--;
                        if (map.IsWall(x, y) == true)
                        {
                            y++;
                            map.boundsHit = false;
                        }
                        break;
                    }

                    else if (input.Key == ConsoleKey.A)
                    {
                        //move left
                        x--;
                        if (map.IsWall(x, y) == true)
                        {
                            x++;
                            map.boundsHit = false;
                        }
                        break;
                    }

                    else if (input.Key == ConsoleKey.D)
                    {
                        //move right
                        x++;
                        if (map.IsWall(x, y) == true)
                        {
                            x--;
                            map.boundsHit = false;
                        }
                        inputLoop = false;
                        break;
                    }

                    else if (input.Key == ConsoleKey.S)
                    {
                        //move down
                        y++;
                        if (map.IsWall(x, y) == true)
                        {
                            y--;
                            map.boundsHit = false;
                        }
                        inputLoop = false;
                        break;
                    }
                }
            }                  
        }
        public void checkIfOnEnemy(Enemy enemy)
        {
            hitEnemy = false;
            if (xData == enemy.xData && yData == enemy.yData)
            {           
                Console.Beep();
                enemy.health -= 1;
                hitEnemy = true;           
            }           
        }
        private void CheckIfDead()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }
    }  
}
