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

            rng = new Random(1);
        }

        public void Update(Player player, Map map)
        {
            // Check if taken damage
            TakeDamage(player);

            if (IsAlive())
            {
                Move(map, player);
            }

            if (IsAlive() == false)
            {
                xData = map.column + 1;
                yData = map.row + 1;
            }
        }

        protected new void Move(Map map, Player player)
        {
            // checks if enemy can move
            preMoveY = y;
            preMoveX = x;

            // moves enemy with randomizer
            int direction;
            int wait;

            direction = rng.Next(0, 4);
            wait = rng.Next(0, 2);

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
                && player.targetGhost == false)
            {
                x = preMoveX;
                y = preMoveY;
            }
            // Updates enemies position
            xData = x;
            yData = y;
        }
        private void TakeDamage(Player player)
        {
            if (player.targetGhost == true)
            {
                health -= player.playerDamage;
            }
        }
    }
}
