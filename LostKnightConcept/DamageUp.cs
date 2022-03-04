using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class DamageUp : Collectables
    {
        private const int startPosX = 2;
        private const int startPosy = 2;
        public DamageUp()
        {
            name = "DamageUp";
            charGraphic = '+';

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;

            x = startPosX;
            y = startPosy;

        }

        public void Update(Player player)
        {
            Draw();
            ItemPickedUp(player, xData, yData);
            CheckIfDead(player);
        }

        private void Draw()
        {
            Console.SetCursorPosition(x + 1, y + 1);
            DrawChar(charGraphic, backColor, foreColor);
            xData = x;
            yData = y;
        }

        private void CheckIfDead(Player player)
        {
            if (PickedUp == true)
            {
                player.playerDamage = player.playerDamage + 1;
                isAlive = false;
            }
        }
    }
}
