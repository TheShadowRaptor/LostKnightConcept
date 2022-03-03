using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected Random rng;     
    }
}
