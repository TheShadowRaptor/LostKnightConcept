using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class HUD
    {
        public void ShowHUD(Player player, EnemyClass enemy, Map map)
        {
            Console.SetCursorPosition(0, map.mapData.GetLength(0) + 2);
            Console.WriteLine("╔═════════════════════{HUD}═══════════════════════╗");
            Console.Write("║");
            Console.Write("Player name: " + player.name + " health = " + player.health);
            Console.WriteLine("                   ║");
            if (player.showTarget == true)
            {
                Console.WriteLine("");
                Console.WriteLine("║Target name: " + enemy.name + " health = " + enemy.health);
                Console.WriteLine("║╔═╗");
                Console.Write("║║");
                Console.BackgroundColor = enemy.backColor;
                Console.ForegroundColor = enemy.foreColor;
                Console.Write((enemy.enemyGraphic));
                Console.ResetColor();
                Console.WriteLine("║");
                Console.WriteLine("║╚═╝");
                player.showTarget = false;
            }
            else
            {
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
            }
            Console.WriteLine("╚═════════════════════════════════════════════════╝");
        }
    }
}
