using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class EnemyMananger : GameManager
    {
        public Skeleton skeleton = new Skeleton();
        public Ghost ghost = new Ghost();
        public Ghoul ghoul = new Ghoul();

        public void DrawEnemies()
        {
            skeleton.Draw();
            ghost.Draw();
            ghoul.Draw();
        }

        public void UpdateEnemies(Player player, Map map)
        {
            skeleton.Update(player, map);
            ghost.Update(player, map);
            ghoul.Update(player, map);
        }


    }
}
