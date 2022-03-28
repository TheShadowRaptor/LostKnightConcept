using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class EnemyMananger 
    {
        int numOfSkeletons = 25;

        public Skeleton[] skeleton;
        public Ghost ghost = new Ghost();
        public Ghoul ghoul = new Ghoul();

        public void DrawEnemies()
        {
            skeleton = new Skeleton[numOfSkeletons];
            for(int i = 0; i < numOfSkeletons; i++)
            {
                skeleton[i].Draw();
            }          
            ghost.Draw();
            ghoul.Draw();
        }

        public void UpdateEnemies(Player player, Map map)
        {
            skeleton = new Skeleton[numOfSkeletons];
            for (int i = 0; i < numOfSkeletons; i++)
            {
                skeleton[i].Update(player, map);
            }
            ghost.Update(player, map);
            ghoul.Update(player, map);
        }

        private void EnemySpawnPos()
        {

        }

    }
}
