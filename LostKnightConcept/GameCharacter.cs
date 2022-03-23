using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace LostKnightConcept
{
    class GameCharacter
    {
        //fields       
        public bool isAlive = true;
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

        protected Random rng;
        protected Random rng2;
        protected Random rng3;

        protected bool IsAlive()
        {
            if (health <= 0)
            {
                health = 0;
                return false;
            }
            return true;
        }
        public void Draw()
        {
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            DrawChar(charGraphic, backColor, foreColor);
            Console.CursorVisible = false;
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
