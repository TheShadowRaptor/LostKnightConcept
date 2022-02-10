using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Stats
    {
        public void ShowStats(Player player, Enemy enemy)
        {
            Console.WriteLine(player.name + " health = " + player.health);
            Console.WriteLine(enemy.name + " health = " + enemy.health);
        }
    }
}
