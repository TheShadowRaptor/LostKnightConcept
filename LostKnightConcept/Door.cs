using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Door
    {
        private const int startPosX = 17;
        private const int startPosy = 4;

        private string name;

        private string graphic;

        private ConsoleColor backColor;
        private ConsoleColor foreColor;

        public int x;
        public int y;

        public int xData;
        public int yData;

        public bool isActive;

        public Door()
        {
            name = "LockedDoor";
            graphic = "]";

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;

            x = startPosX;
            y = startPosy;

            isActive = true;

        }

        public void Update(Player player)
        {
            if (isActive)
            {
                UnlockDoor(player);
            }
        }

        public void Draw(Render render)
        {
            if (isActive)
            {
                render.Draw(x, y, graphic, foreColor, backColor);
            }
        }

        private void UnlockDoor(Player player)
        {
            xData = x;
            yData = y;

            if (player.xData == xData && player.yData == yData && player.keysHeld > 0)
            {
                player.keysHeld = player.keysHeld - 1;
                isActive = false;
            }
        }
    }
}
