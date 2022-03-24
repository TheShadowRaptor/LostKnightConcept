using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class HUD
    {
        public void ShowHUD(Map map, Player player, Skeleton skeleton, Ghost ghost, Ghoul ghoul, Key key)
        {
            Console.SetCursorPosition(0, map.row + 3);
            Console.WriteLine("╔═════════════════════{HUD}═══════════════════════╗");
            Console.Write("║");
            Console.Write("Player name: " + player.name + " || " + "keys = " + key.keys);
            Console.WriteLine("                  ║");
            Console.Write("║");
            Console.Write("Health = " + player.health);
            Console.WriteLine("                                       ║");
            Console.Write("║");
            Console.Write("Damage = " + player.playerDamage);
            Console.WriteLine("                                       ║");
            if (player.targetSkeleton == true)
            {
                Console.WriteLine("");
                Console.WriteLine("║Target name: " + skeleton.name + " health = " + skeleton.health);
                Console.WriteLine("║╔═╗");
                Console.Write("║║");
                Console.BackgroundColor = skeleton.backColor;
                Console.ForegroundColor = skeleton.foreColor;
                Console.Write((skeleton.enemyGraphic));
                Console.ResetColor();
                Console.WriteLine("║");
                Console.WriteLine("║╚═╝");
                player.targetSkeleton = false;
            }

            else if (player.targetGhost == true)
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
