using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class HUD
    {
        public void ShowHUD(Map map, Player player, Key key, Enemy[] enemy, int currentEnemy)
        {
            Console.SetCursorPosition(0, + 18);
            Console.WriteLine("╔═════════════════════{HUD}═══════════════════════╗");
            Console.Write("║");
            Console.Write("Player name: " + player.name + " || " + "keys = " + key.keys);
            Console.WriteLine("                  ║");
            Console.Write("║");
            /*Console.Write("Health = " + player.health + " || " + "Objective = Kill ");
            Console.BackgroundColor = ghoul.backColor;
            Console.ForegroundColor = ghoul.foreColor;
            Console.Write(ghoul.enemyGraphic);*/
            Console.ResetColor();
            Console.WriteLine("                                                 ║");
            Console.Write("║");
            Console.Write("Damage = " + player.damage);
            Console.WriteLine("                                       ║");
            if (player.targetEnemy == true)
            {
                Console.WriteLine("");
                Console.WriteLine("║Target name: " + enemy[currentEnemy].name + " health = " + enemy[currentEnemy].health);
                Console.WriteLine("║╔═╗");
                Console.Write("║║");
                Console.BackgroundColor = enemy[currentEnemy].backColor;
                Console.ForegroundColor = enemy[currentEnemy].foreColor;
                Console.Write((enemy[currentEnemy].graphic));
                Console.ResetColor();
                Console.WriteLine("║");
                Console.WriteLine("║╚═╝");
                player.targetEnemy = false;
            }

            /*else if (player.targetGhost == true)
            {
                Console.WriteLine("");
                Console.WriteLine("║Target name: " + ghost.name + " health = " + ghost.health);
                Console.WriteLine("║╔═╗");
                Console.Write("║║");
                Console.BackgroundColor = ghost.backColor;
                Console.ForegroundColor = ghost.foreColor;
                Console.Write((ghost.enemyGraphic));
                Console.ResetColor();
                Console.WriteLine("║");
                Console.WriteLine("║╚═╝");
                player.targetGhost = false;
            }

            else if (player.targetGhoul == true)
            {
                Console.WriteLine("");
                Console.WriteLine("║Target name: " + ghoul.name + " health = " + ghoul.health);
                Console.WriteLine("║╔═╗");
                Console.Write("║║");
                Console.BackgroundColor = ghoul.backColor;
                Console.ForegroundColor = ghoul.foreColor;
                Console.Write((ghoul.enemyGraphic));
                Console.ResetColor();
                Console.WriteLine("║");
                Console.WriteLine("║╚═╝");
                player.targetGhoul = false;
            }*/
            /*else
            {*/
            Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
                Console.WriteLine("║                                                 ║");
            /*}*/
            Console.WriteLine("╚═════════════════════════════════════════════════╝");
        }
    }
}
