﻿using System;
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
            Console.WriteLine("╔═════════════════════{HUD}═══════════════════════╗");
            Console.Write("║");
            Console.Write("Player name: " + player.name + " || " + "keys = " + player.keysHeld);
            Console.WriteLine("                  ║");
            Console.Write("║");
            Console.Write("Health = " + player.health + " || " + "Objective = Kill ");
            Console.BackgroundColor = enemy[maxEnemies - 1].backColor;
            Console.ForegroundColor = enemy[maxEnemies - 1].foreColor;
            Console.Write(enemy[maxEnemies - 1].graphic);
            Console.ResetColor();
            Console.WriteLine("                 ║");
            Console.Write("║");
            Console.Write("Damage = " + player.damage);
            Console.WriteLine("                                       ║");
            if (player.targetEnemy == true)
            {
                Console.WriteLine("");
                Console.WriteLine("║Target name: " + enemy[player.currentTarget].name + " health = " + enemy[player.currentTarget].health);
                Console.WriteLine("║╔═╗");
                Console.Write("║║");
                Console.BackgroundColor = enemy[player.currentTarget].backColor;
                Console.ForegroundColor = enemy[player.currentTarget].foreColor;
                Console.Write((enemy[player.currentTarget].graphic));
                Console.ResetColor();
                Console.WriteLine("║");
                Console.WriteLine("║╚═╝");
                player.targetEnemy = false;
            }
            else
            {
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
}
