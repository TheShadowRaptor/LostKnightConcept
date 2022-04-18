using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Ghost : Enemy
    {
        public Ghost()
        {
            name = "Ghost";
            graphic = "G";
            health = 1;
            damage = 1;
            foreColor = ConsoleColor.Cyan;
            backColor = ConsoleColor.Blue;
        }

        //Ghost movement (Can go through walls)
        public override void Move(Map map, Player player, Render render, Enemy[] enemy, int maxEnemies,  int currentEnemy, Global global)
        {
            // checks if enemy can move
            preMoveY = y;
            preMoveX = x;

            // moves enemy with randomizer
            int direction;
            int wait;

            direction = global.rng.Next(0, 4);
            wait = global.rng.Next(0, 2);

            if (wait == 1)
            {
                if (direction == 0)
                {
                    preMoveY--;
                }

                else if (direction == 1)
                {
                    preMoveY++;
                }

                else if (direction == 2)
                {
                    preMoveX--;
                }

                else if (direction == 3)
                {
                    preMoveX++;
                }
            }

            if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                && CollideWithPlayer(player, preMoveX, preMoveY) == false
                && CollideWithEnemy(enemy, preMoveX, preMoveY, maxEnemies, currentEnemy) == false
                && player.targetEnemy == false)
            {
                x = preMoveX;
                y = preMoveY;
            }
            // Updates enemies position
            xData = x;
            yData = y;
        }
    }
}
