using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class ResetGame
    {
        Door door = new Door();
        Player player = new Player();
        EnemyMananger enemyMananger = new EnemyMananger();
        CollectableManager collectableManager = new CollectableManager();

        public void Reset()
        {
            //player
            player.health = 5;

            player.playerDamage = 1;
            player.x = player.resetPositionX;
            player.y = player.resetPositionY;

            player.gameover = false;
            player.IsAlive();
        }       
    }
}
