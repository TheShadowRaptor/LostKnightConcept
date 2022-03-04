using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Collectables 
    {
        protected string name;
        protected char charGraphic;

        protected ConsoleColor backColor;
        protected ConsoleColor foreColor;

        protected int x;
        protected int y;

        protected int xData;
        protected int yData;

        public bool isAlive = true;

        protected bool PickedUp;

        public Collectables()
        {
            
        }

        protected void ItemPickedUp(Player player, int xData, int yData)
        {
            if (player.xData == xData && player.yData == yData)
            {
                PickedUp = true;
            }
        }
        public void DrawChar(char charGraphic, ConsoleColor backColor, ConsoleColor foreColor)
        {
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = foreColor;
            Console.Write(charGraphic);
            Console.ResetColor();
        }
    }
}
