using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class ResetGame
    {

        public void Reset()
        {
            Door door = new Door();
            Player player = new Player();
            Map map = new Map();
            Global global = new Global();

            EnemyMananger enemyMananger = new EnemyMananger(map, player, global);
            CollectableManager collectableManager = new CollectableManager();

            //player
            player.health = 5;

            player.damage = 1;
            player.x = player.resetPositionX;
            player.y = player.resetPositionY;

            player.gameover = false;
            player.IsAlive();
        }       
    }
}
