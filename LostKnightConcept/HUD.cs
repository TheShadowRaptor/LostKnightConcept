using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class HUD
    {
        public void ShowHUD(Map map, Player player, Key key, Enemy[] enemy, int maxEnemies)
        {
            Console.SetCursorPosition(0, + 18);
            Console.WriteLine("═════════════════════{HUD}═══════════════════════");
            Console.Write(" Player name: " + player.name + " || " + "keys = " + player.keysHeld + " || " + "money = " + player.moneyHeld);
            Console.Write("\n\r Health = " + player.health + " || " + "Objective = Kill ");
            Console.BackgroundColor = enemy[maxEnemies - 1].backColor;
            Console.ForegroundColor = enemy[maxEnemies - 1].foreColor;
            Console.Write(enemy[maxEnemies - 1].graphic);
            Console.ResetColor();
            Console.Write("\n\r Damage = " + player.damage);
            if (player.targetEnemy == true)
            {
                Console.WriteLine("\n\r Target name: " + enemy[player.currentTarget].name + " || health = "+ enemy[player.currentTarget].health + "    ");
                Console.Write(" ");
                Console.BackgroundColor = enemy[player.currentTarget].backColor;
                Console.ForegroundColor = enemy[player.currentTarget].foreColor;
                Console.Write((enemy[player.currentTarget].graphic));
                Console.ResetColor();
                //player.targetEnemy = false;
            }
        }
    }
}
