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
        private ConsoleColor backColor;
        private ConsoleColor foreColor;

        public char enemyGraphic;
        public Enemy()
        {
            // instatiation
            health = 2;

            x = startPositionX;
            y = startPositionY;

            backColor = ConsoleColor.Red;
            foreColor = ConsoleColor.Red;

            rng = new Random();
            
            charGraphic = '#';
            enemyGraphic = charGraphic;
            name = "Skeleton";
        }

        public void Update(Player player, Map map)
        {
            CheckIfDead();

            if (isAlive == true)
            {
                Draw();
                MoveEnemy(map, player);
            }
            else
            {
                xData = map.mapData.GetLength(0) + 1;
                yData = map.mapData.GetLength(1) + 1;
            }
        }

        private void Draw()
        {
            // draws enemy position
            if (isAlive)
            {
                Console.SetCursorPosition(x + 1, y + 1);
            }

            else Console.SetCursorPosition(300, 300);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(charGraphic);
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        private void MoveEnemy(Map map, Player player)
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
    }
}
