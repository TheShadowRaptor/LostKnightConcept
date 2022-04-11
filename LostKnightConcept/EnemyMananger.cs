using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class EnemyMananger 
    {
        public Enemy[] enemy;

        int maxEnemies = 5;
        int SkeletonCount = 2;

        int posX;
        int posY;

        private Random rngX = new Random (0);
        private Random rngY = new Random (1);

        public EnemyMananger(Map map)
        {
            int maxNumber = maxEnemies - 1;
            enemy = new Enemy[maxEnemies];

            for (int i = 0; i < maxEnemies; i++)
            {
                posX = rngX.Next(0, map.colume);
                posY = rngY.Next(0, map.row);

                if (i < SkeletonCount) enemy[i] = new Skeleton();
                else if (i == maxNumber) enemy[i] = new Ghoul();
                else enemy[i] = new Ghost();         
            }
        }

        public void Draw(Render render, Map map, Global global)
        {
            for (int i = 0; i < maxEnemies; i++)
            {                                             
                enemy[i].Draw(posX, posY, enemy[i].name, render);            
            }
        }

        public void Update(Player player, Map map, Render render, Global global)
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                enemy[i].Move(map, player, render);

            }
        }       
    }
}
