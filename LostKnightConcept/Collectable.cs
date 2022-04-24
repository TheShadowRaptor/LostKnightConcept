using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Collectable 
    {
        public string name;
        public int x;
        public int y;

        public int xData;
        public int yData;

        protected string graphic;

        protected ConsoleColor backColor;
        protected ConsoleColor foreColor;


        protected bool isActive = true;


        protected bool PickedUp;

        public Collectable()
        {
            
        }

        private void onPickUp(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (player.xData == xData && player.yData == yData)
            {
                Console.Beep();
                isActive = false;
            }
        }

        public void Draw(string name, Render render)
        {
            render.Draw(x, y, graphic, foreColor, backColor);
        }

        public void Update(Player player, Map map)
        {
            if (isActive)
            {
                onPickUp(player, x, y);
            }
            else
            {
                xData = map.row + 1;
                yData = map.colume + 1;

                x = xData;
                y = yData;
            }
        }

        public bool CollideWithPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == player.xData && yData == player.yData)
            {
                return true;
            }
            return false;
        }

        public bool CollideWithEnemy(Collectable[] collectable, int x, int y, int currentCollectable)
        {
            xData = x;
            yData = y;

            if (xData == collectable[currentCollectable].xData && yData == collectable[currentCollectable].yData && collectable[currentCollectable] != this)
            {
                return true;
            }

            return false;
        }
    }
}
