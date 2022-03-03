using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace LostKnightConcept
{
    class Character
    {
        //fields       
        public bool isAlive = true;
        public int xData;
        public int yData;
        public string name;

        public int health;
        
        protected int x;
        protected int y;

        protected char charGraphic;

        protected SoundPlayer hit = new SoundPlayer();

        protected Random rng;

        public Character()
        {

        }
        protected void CheckIfDead()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }

        protected void DrawChar(char charGraphic, ConsoleColor backColor, ConsoleColor foreColor)
        {
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = foreColor;
            Console.Write(charGraphic);
        }
    }
}
