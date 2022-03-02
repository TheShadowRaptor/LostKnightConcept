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
                MovePlayer(map);
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

        public void MovePlayer(Map map)
        {
            // moves player with button input          
            bool inputLoop;
            bool moveBack;
            inputLoop = true;
            moveBack = true;

            while (inputLoop == true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.W)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == false)
                    {                      
                        if (map.IsFloor(x, y))
                        {
                            moveBack = false;                            
                        }
                    }

                    if (moveBack)
                    {
                        y++;
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.A)
                {
                    x--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (map.IsFloor(x, y))
                        {
                            moveBack = false;
                        }
                    }

                    if (moveBack)
                    {
                        x++;
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.D)
                {
                    x++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (map.IsFloor(x, y))
                        {
                            moveBack = false;
                        }
                    }

                    if (moveBack)
                    {
                        x--;
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.S)
                {
                    y++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (map.IsFloor(x, y))
                        {
                            moveBack = false;
                        }
                    }

                    if (moveBack)
                    {
                        y--;
                        break;
                    }
                    break;
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
