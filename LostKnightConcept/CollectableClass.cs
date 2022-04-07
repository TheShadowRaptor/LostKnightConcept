using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class CollectableClass 
    {
        protected string name;
        protected string graphic;

        protected ConsoleColor backColor;
        protected ConsoleColor foreColor;

        protected int x;
        protected int y;

        protected bool isActive = true;

        protected int xData;
        protected int yData;

        protected bool PickedUp;

        public CollectableClass()
        {
            
        }

        protected void ItemPickedUp(Player player, int xData, int yData)
        {
            if (player.xData == xData && player.yData == yData)
            {
                PickedUp = true;
            }
        }
        public void Draw(Render render)
        {
            render.Draw(x, y, graphic, foreColor, backColor);
        }

        public void Update(Player player)
        {
            if (isActive)
            {
                ItemPickedUp(player, xData, yData);
                CheckIfDead(player);
            }
        }

        private void CheckIfDead(Player player)
        {
            if (PickedUp == true)
            {
                isActive = false;
            }
        }
    }
}
