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
        public int xData;
        public int yData;
        public int health;
        public bool isAlive = true;

        protected int x;
        protected int y;
        protected bool attacked = false;
        protected bool attackUp;
        protected bool attackDown;
        protected bool attackRight;
        protected bool attackLeft;

        public string name;

        protected Random rng;
      
    }
}
