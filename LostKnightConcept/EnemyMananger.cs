using System;

namespace LostKnightConcept
{
    class EnemyMananger 
    {
        public int maxEnemies = 5;
        int SkeletonCount = 2;

        public Enemy[] enemy;

        public EnemyMananger(Map map, Global global)
        {
            int maxNumber = maxEnemies - 1;
            enemy = new Enemy[maxEnemies];

            for (int currentEnemy = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                if (currentEnemy < SkeletonCount) enemy[currentEnemy] = new Skeleton();
                else if (currentEnemy == maxNumber) enemy[currentEnemy] = new Ghoul();
                else enemy[currentEnemy] = new Ghost();

                enemy[currentEnemy].x = global.rng.Next(1, /*map.colume*/ 10);
                enemy[currentEnemy].y = global.rng.Next(1, /*map.row*/ 10);
            }
        }

        public void Draw(Render render, Map map)
        {

            for (int currentEnemy = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                enemy[currentEnemy].Draw(enemy[currentEnemy].name, render);
            }
        }

        public void Update(Player player, Map map, Render render, Global global)
        {
            for (int currentEnemy  = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                enemy[currentEnemy].Update(player, map, render, enemy, maxEnemies, global);
            }          
        }       
    }
}
