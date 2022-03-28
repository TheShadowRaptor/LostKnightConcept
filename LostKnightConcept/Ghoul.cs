using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept 
{
    class Ghoul : EnemyClass
    {
        private const int startPosX = 18;
        private const int startPosY = 5;

        private bool moveTwice;

        public Ghoul()
        {
            health = 5;
            damage = 1;

            x = startPosX;
            y = startPosY;

            backColor = ConsoleColor.DarkRed;
            foreColor = ConsoleColor.Red;

            rng = new Random(2);

            charGraphic = '%';
            enemyGraphic = charGraphic;
            name = "Ghoul";
        }
        protected new void Move(Map map, Player player)
        {
            // checks if enemy can move
            preMoveY = y;
            preMoveX = x;

            // moves Twice
            moveTwice = true;

            // moves enemy with randomizer
            int direction;
            int wait;

            while (true)
            {
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
                    && map.IsFloor(preMoveX, preMoveY)
                    && CollideWithPlayer(player, preMoveX, preMoveY) == false
                    && player.targetGhoul == false)
                {
                    x = preMoveX;
                    y = preMoveY;
                }

                // Updates enemies position
                xData = x;
                yData = y;

                if (moveTwice == false)
                {
                    break;
                }

                moveTwice = false;
            }
            
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
        private void TakeDamage(Player player)
        {
            if (player.targetGhoul == true)
            {
                health -= player.playerDamage;
            }
        }
    }
}
