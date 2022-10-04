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
        public int damage;
        public int maxHealth;

        public ConsoleColor backColor;
        public ConsoleColor foreColor;

        public int x;
        public int y;

        protected string characterGraphic;

        protected SoundPlayer hit = new SoundPlayer();

        public bool IsAlive()
        {
            if (health >= 1)
            {
                return true;
            }

            else if (health <= 0)
            {
                health = 0;
                return false;
            }
            return true;
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
