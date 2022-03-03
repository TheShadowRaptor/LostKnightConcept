using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class Enemy : Character
    {
        // fields
        private const int startPositionX = 5;
        private const int startPositionY = 2;

      
        public Enemy()
        {
            // instatiation
            health = 2;

            x = startPositionX;
            y = startPositionY;

            rng = new Random();

            name = "Skeleton";
        }

        public void Update(Player player, Map map)
        {

            checkIfDead();
            if (isAlive == true)
            {
                Draw();
                MoveEnemy(map, player);
            }                                
        }

        public void Draw()
        {
            // draws enemy position
            if (isAlive)
            {
                Console.SetCursorPosition(x + 1, y + 1);
            }

            else Console.SetCursorPosition(300, 300);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('#');
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void MoveEnemy(Map map, Player player)
        {
            int direction;
            int stall;
            bool canMove;

            canMove = false;

            direction = rng.Next(0, 4);
            stall = rng.Next(0, 2);
            
            if(stall == 1)
            {
                if (direction == 0)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnPlayer(player, x, y) == false)
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
                        if (IsOnPlayer(player, x, y) == true)
                        {
                            y++;
                        }
                    }
                }

                else if (direction == 1)
                {
                    x--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnPlayer(player, x, y) == false)
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
                        if (IsOnPlayer(player, x, y) == true)
                        {
                            x++;
                        }
                    }
                }

                else if (direction == 2)
                {
                    x++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnPlayer(player, x, y) == false)
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
                        if (IsOnPlayer(player, x, y) == true)
                        {
                            x--;
                        }
                    }
                }

                else if (direction == 3)
                {
                    y++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnPlayer(player, x, y) == false)
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
                        if (IsOnPlayer(player, x, y) == true)
                        {
                            y--;
                        }
                    }
                }
            }           
        }

        private bool IsOnPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == player.xData && yData == player.yData)
            {
                player.health -= 1;
                SystemSounds.Beep.Play();
                return true;
            }
            return false;
        }

        /*private bool IsPlayerClose(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == player.xData && yData == player.yData - 1 ||
                xData == player.xData && yData == player.yData + 1 ||
                yData == player.yData && xData == player.xData - 1 ||
                yData == player.yData && xData == player.xData + 1)
            {
                Console.Beep();
                player.health -= 1;
                return true;
            }
            return false;
        }*/

        private void checkIfDead()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
                xData = 30;
                yData = 30;
            }
        }
    }
}
