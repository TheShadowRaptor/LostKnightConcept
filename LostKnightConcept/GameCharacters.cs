using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace LostKnightConcept
{
    class GameCharacters
    {
        //fields       
        public int xData;
        public int yData;
        public string name;

        public int health;

        public ConsoleColor backColor;
        public ConsoleColor foreColor;

        protected int x;
        protected int y;

        protected char charGraphic;

        protected SoundPlayer hit = new SoundPlayer();

        protected bool IsAlive()
        {
            if (this.health <= 0)
            {
                this.health = 0;
                return false;
            }
            return true;
        }
        public void Draw()
        {
            if (IsAlive())
            {
                // draws char position if alive
                Console.SetCursorPosition(x + 1, y + 1);

                DrawChar(charGraphic, backColor, foreColor);
                Console.CursorVisible = false;
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
