using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Skeleton : EnemyClass
    {
        private const int startPosX = 7;
        private const int startPosY = 3;

        public Skeleton()
        {
            health = 2;
            damage = 1;

            x = startPosX;
            y = startPosY;

            backColor = ConsoleColor.White;
            foreColor = ConsoleColor.DarkGray;


            charGraphic = '#';
            enemyGraphic = charGraphic;
            name = "Skeleton";
        }

        public new void Update(Player player, Map map)
        {
            CheckIfDead();

            if (isAlive == true)
            {
                Draw();
                Move(map, player);
            }
            else
            {
                xData = map.map.GetLength(0) + 1;
                yData = map.map.GetLength(1) + 1;
            }
        }

        protected new void Move(Map map, Player player)
        {
            int direction;
            int wait;
            bool canMove;

            canMove = false;

            direction = rng.Next(0, 4);
            wait = rng.Next(0, 2);

            if (wait == 1)
            {
                if (direction == 0)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsHit(player, x, y) == false)
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
                        if (IsHit(player, x, y) == true)
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
                        if (IsHit(player, x, y) == false)
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
                        if (IsHit(player, x, y) == true)
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
                        if (IsHit(player, x, y) == false)
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
                        if (IsHit(player, x, y) == true)
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
                        if (IsHit(player, x, y) == false)
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
                        if (IsHit(player, x, y) == true)
                        {
                            y--;
                        }
                    }
                }
            }
        }
    }
}
