using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class GameManager
    {
        bool isGameActive = true;
        public void RunGame()
        {
            //instantiation
            Map map = new Map();            
            EnemyClass enemy = new EnemyClass();
            HUD hud = new HUD();
            Heart heart = new Heart();
            Player player = new Player();
            map.DisplayMap();
            heart.Update(player);
            enemy.Update(player, map);
            hud.ShowHUD(player, enemy, map);
            

            while (isGameActive)
            {               
                if (player.isAlive)
                {
                    player.Update(enemy, map);
                }
                else break;

                map.DisplayMap();

                if (enemy.isAlive)
                {
                    enemy.Update(player, map);
                }

                if (heart.isAlive)
                {
                    heart.Update(player);
                }

                hud.ShowHUD(player, enemy, map);               
                
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
