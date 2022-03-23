using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Ghost : EnemyClass
    {
        private const int startPosX = 5;
        private const int startPosY = 1;

        public Ghost()
        {
            health = 1;
            damage = 1;

            x = startPosX;
            y = startPosY;

            backColor = ConsoleColor.Cyan;
            foreColor = ConsoleColor.DarkBlue;

            charGraphic = 'G';
            enemyGraphic = charGraphic;
            name = "Ghost";
        }

        public new void Update(Player player, Map map)
        {
            IsAlive();

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

            direction = rng2.Next(0, 4);
            wait = rng2.Next(0, 2);

            if (wait == 1)
            {
                if (direction == 0)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == true)
                    {
                        y++;
                    }
                        if (IsHit(player, x, y) == true)
                        {
                            y++;
                        }
                }

                else if (direction == 1)
                {
                    x--;
                    if (map.IsMapBounds(x, y) == true)
                    {
                        x++;
                    }
                    if (IsHit(player, x, y) == true)
                    {
                        x++;
                    }
                }

                else if (direction == 2)
                {
                    x++;
                    if (map.IsMapBounds(x, y) == true)
                    {
                        x--;
                    }
                    if (IsHit(player, x, y) == true)
                    {
                        x--;
                    }
                }

                else if (direction == 3)
                {
                    y++;
                    if (map.IsMapBounds(x, y) == true)
                    {
                        y--;
                    }
                    if (IsHit(player, x, y) == true)
                    {
                        y--;
                    }
                }
            }
        }
    }
}
