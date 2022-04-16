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

        int x;
        int y;

        protected Random rng = new Random();

        public EnemyMananger(Map map)
        {
            int maxNumber = maxEnemies - 1;
            enemy = new Enemy[maxEnemies];

            for (int i = 0; i < maxEnemies; i++)
            {
                if (i < SkeletonCount) enemy[i] = new Skeleton();
                else if (i == maxNumber) enemy[i] = new Ghoul();
                else enemy[i] = new Ghost();

                enemy[i].x = rng.Next(1, map.colume);
                enemy[i].y = rng.Next(1, map.row);
            }
        }

        public void Draw(Render render, Map map, Global global)
        {

            for (int i = 0; i < maxEnemies; i++)
            {
                enemy[i].Draw(enemy[i].name, render);
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
