using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Key : CollectableClass
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
            if (isActive)
            {
                ItemPickedUp(player, xData, yData);
                CheckIfDead(player);
            }
        }

        public void Draw()
        {
            if (isActive)
            {
                Console.SetCursorPosition(x + 1, y + 1);
                DrawChar(charGraphic, backColor, foreColor);
                xData = x;
                yData = y;
            }
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
