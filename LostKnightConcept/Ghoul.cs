using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept 
{
    class Ghoul : EnemyClass
    {
        private const int startPosX = 11;
        private const int startPosY = 2;

        public Ghoul()
        {
            health = 5;

            x = startPosX;
            y = startPosY;

            backColor = ConsoleColor.DarkRed;
            foreColor = ConsoleColor.Red;

            charGraphic = '%';
            enemyGraphic = charGraphic;
            name = "Ghoul";
        }

        protected new void Move(Map map, Player player)
        {
            int direction;
            int wait;

            bool canMove;
            canMove = false;

            bool moveTwice;
            moveTwice = true;

            bool lastMove;
            lastMove = false;

            direction = rng3.Next(0, 4);
            wait = rng3.Next(0, 2);

            if (wait == 1)
            {
                if (direction == 0)
                {
                    while (moveTwice == true)
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

                        if (lastMove == true)
                        {
                            moveTwice = false;
                        }

                        lastMove = true;
                    }
                }

                else if (direction == 1)
                {
                    while (moveTwice == true)
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

                        if (lastMove == true)
                        {
                            moveTwice = false;
                        }

                        lastMove = true;
                    }
                }

                else if (direction == 2)
                {
                    while (moveTwice == true)
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

                        if (lastMove == true)
                        {
                            moveTwice = false;
                        }

                        lastMove = true;
                    }
                }

                else if (direction == 3)
                {
                    while (moveTwice == true)
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

                        if (lastMove == true)
                        {
                            moveTwice = false;
                        }

                        lastMove = true;
                    }
                }
            }
        }
        protected new void Draw()
        {
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            DrawChar(charGraphic, backColor, foreColor);
            Console.CursorVisible = false;
        
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
                xData = map.mapData.GetLength(0) + 1;
                yData = map.mapData.GetLength(1) + 1;
            }
        }
    }
}
