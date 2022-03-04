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
        private char charGraphic;

        private ConsoleColor backColor;
        private ConsoleColor foreColor;

        public int x;
        public int y;

        public int xData;
        public int yData;

        public bool isAlive;

        public Door()
        {
            name = "LockedDoor";
            charGraphic = ']';

            backColor = ConsoleColor.DarkGray;
            foreColor = ConsoleColor.Yellow;

            x = startPosX;
            y = startPosy;

            isAlive = true;

        }
        public void DrawChar(char charGraphic, ConsoleColor backColor, ConsoleColor foreColor)
        {
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = foreColor;
            Console.Write(charGraphic);
            Console.ResetColor();
        }

        public void Update(Player player, Key key)
        {
            Draw();
            UnlockDoor(player, key);
        }

        private void Draw()
        {
            Console.SetCursorPosition(x + 1, y + 1);
            DrawChar(charGraphic, backColor, foreColor);
            xData = x;
            yData = y;
        }

        private void UnlockDoor(Player player, Key key)
        {
            xData = x;
            yData = y;
            if (player.xData == xData && player.yData == yData && key.keys > 0)
            {
                key.keys = key.keys - 1;
                isAlive = false;
            }
            else player.doorCollide = true;
        }
    }
}
