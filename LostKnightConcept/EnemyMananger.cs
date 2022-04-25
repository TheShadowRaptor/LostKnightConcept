using System;

namespace LostKnightConcept
{
    class EnemyMananger 
    {
        public int maxEnemies;

        int SkeletonCount;

        public Enemy[] enemy;

        public EnemyMananger(Map map, Player player, Global global)
        {
            maxEnemies = 20;

            SkeletonCount = 10;

            int maxNumber = maxEnemies - 1;
            enemy = new Enemy[maxEnemies];

            for (int currentEnemy = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                if (currentEnemy < SkeletonCount) enemy[currentEnemy] = new Skeleton();
                else if (currentEnemy == maxNumber) enemy[currentEnemy] = new Ghoul();
                else enemy[currentEnemy] = new Ghost();

                //Checks if there are any obsticals in the way of spawning
                bool canSpawn = false;

                while (canSpawn == false)
                {
                    enemy[currentEnemy].x = global.rng.Next(1, map.colume);
                    enemy[currentEnemy].y = global.rng.Next(1, map.row);

                    if (enemy[currentEnemy].GetType() == typeof(Ghoul))
                    {                       
                        enemy[currentEnemy].x = 69;
                        enemy[currentEnemy].y = 4; 
                    }

                    if ((map.IsMapBounds(enemy[currentEnemy].x, enemy[currentEnemy].y) == false)
                    && map.IsFloor(enemy[currentEnemy].x, enemy[currentEnemy].y)
                    && enemy[currentEnemy].CollideWithPlayer(player, enemy[currentEnemy].x, enemy[currentEnemy].y) == false
                    && enemy[currentEnemy].CollideWithEnemy(enemy, enemy[currentEnemy].x, enemy[currentEnemy].y, currentEnemy) == false)
                    {
                        canSpawn = true;
                        break;
                    }
                }
            }
        }

        public void Draw(Render render, Map map)
        {
            for (int currentEnemy = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                enemy[currentEnemy].Draw(enemy[currentEnemy].name, render);
            }
        }

        public void Update(Player player, Map map, Render render, InteractableObject[] interactableObject, int maxObjects, Global global)
        {
            for (int currentEnemy  = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                enemy[currentEnemy].Update(player, map, render, enemy, interactableObject, maxEnemies, maxObjects, player.currentTarget, global);
            }          
        }       
    }
}
