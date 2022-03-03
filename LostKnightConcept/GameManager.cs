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
            Stats stats = new Stats();
            Player player = new Player();
            Enemy enemy = new Enemy();


            while (isGameActive)
            {
                map.DisplayMap();
                stats.ShowStats(player, enemy);
                if (enemy.isAlive)
                {
                    enemy.Update(player, map);
                }

                if (player.isAlive)
                {
                    player.Update(enemy, map);
                }
                else break;
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
