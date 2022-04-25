using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Ghoul : Enemy
    {
        bool moveTwice;
        public Ghoul()
        {
            name = "Ghoul";
            graphic = "G";
            health = 6;
            damage = 1;
            foreColor = ConsoleColor.White;
            backColor = ConsoleColor.Red;
        }

        public override void Move(Map map, Player player, Render render, Enemy[] enemy, int maxEnemies, int currentEnemy, Global global)
        {
            // moves enemy with randomizer
            int direction;
            int wait;
            bool passedTwice = false;

            moveTwice = true;
            while (moveTwice)
            {
                // checks if enemy can move
                preMoveX = x;
                preMoveY = y;

                direction = global.rng.Next(0, 4);
                wait = global.rng.Next(0, 2);


                if (wait == 1)
                {
                    if (direction == 0)
                    {
                        preMoveX--;
                    }

                    else if (direction == 1)
                    {
                        preMoveX++;
                    }

                    else if (direction == 2)
                    {
                        preMoveY--;
                    }

                    else if (direction == 3)
                    {
                        preMoveY++;
                    }
                }

                if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                    && map.IsFloor(preMoveX, preMoveY)
                    && CollideWithPlayer(player, preMoveX, preMoveY) == false
                    && CollideWithEnemy(enemy, preMoveX, preMoveY, currentEnemy) == false
                    && player.targetEnemy == false)
                {
                    x = preMoveX;
                    y = preMoveY;
                }

                if (passedTwice)
                {
                    moveTwice = false;
                }

                passedTwice = true;

                // Updates enemies position
                xData = x;
                yData = y;
            }
        }
    }
}
