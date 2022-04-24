using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class InteractableObjects
    {
        protected const int startPosX = 17;
        protected const int startPosy = 4;

        protected string name;

        protected string graphic;

        protected ConsoleColor backColor;
        protected ConsoleColor foreColor;

        protected bool interacted;

        public int x;
        public int y;

        public int xData;
        public int yData;

        public bool isActive;

        public void Update(Player player)
        {
            if (isActive)
            {
                onInteract(player);
            }
        }

        public void Draw(Render render)
        {
            if (isActive)
            {
                render.Draw(x, y, graphic, foreColor, backColor);
            }
        }

        public void onInteract(Player player)
        {
            xData = x;
            yData = y;

            // Looks for interaction once
            if (player.xData == xData && player.yData == yData)
            {
                interacted = true;
            }
            else
            {
                interacted = false;
            }
        }
    }
}
