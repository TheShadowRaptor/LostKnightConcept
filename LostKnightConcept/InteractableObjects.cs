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

        public int x;
        public int y;

        public int xData;
        public int yData;

        public bool isActive;

        public bool interacted;

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

        public void onInteract()
        {

        }
    }


}
