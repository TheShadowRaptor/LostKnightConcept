using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Key : Collectables
    {
        private const int startPosX = 7;
        private const int startPosy = 6;

        public int keys;
        public Key()
        {
            name = "Key";
            charGraphic = 'F';

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
                keys = keys + 1;
                isActive = false;
            }
        }
    }
}
