using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Heart : CollectableClass
    {
        private const int startPosX = 4;
        private const int startPosy = 4;
        public Heart()
        {
            name = "Heart";
            charGraphic = '♥';

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Red;

            x = startPosX;
            y = startPosy;

        }

        public void Update(Player player)
        {   
            if (isActive)
            {
                ItemPickedUp(player, xData, yData);
                CheckIfPickedUp(player);
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

        private void CheckIfPickedUp(Player player)
        {
            if (PickedUp == true)
            {
                player.health = player.health + 1;
                isActive = false;
            }
        }
    }
}
