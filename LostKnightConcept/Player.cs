using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

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
                Draw();           
                MovePlayer(map, enemy);
            }
                           
                
        }

        public void Draw()
        {
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('+');
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void MovePlayer(Map map, Enemy enemy)
        {
            // moves player with button input          
            bool inputLoop;
            bool canMove;
            inputLoop = true;
            canMove = false;
  
            while (inputLoop == true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.W)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }                       
                    }

                    if (canMove == false)
                    {
                        y++;
                        if (IsOnEnemy(enemy, x, y) == true)
                        {
                            y++;
                        }
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.A)
                {
                    x--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        x++;
                        if (IsOnEnemy(enemy, x, y) == true)
                        {
                            x++;
                        }
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.D)
                {
                    x++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        x--;
                        if (IsOnEnemy(enemy, x, y) == true)
                        {
                            x--;
                        }
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.S)
                {
                    y++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        y--;
                        if (IsOnEnemy(enemy, x, y) == true)
                        {
                            y--;
                        }
                        break;
                    }
                    break;
                }
            }               
        }
        private bool IsOnEnemy(Enemy enemy, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == enemy.xData && yData == enemy.yData)
            {           
                SystemSounds.Hand.Play();
                enemy.health -= 1;
                return true;        
            }
            return false;
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
