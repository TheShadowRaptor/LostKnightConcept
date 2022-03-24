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
            if (player.targetSkeleton == true)
            {
                health -= player.playerDamage;
            }
        }
    }
}
