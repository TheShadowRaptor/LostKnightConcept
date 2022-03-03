using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Program
    {
        //varibles

        static void Main(string[] args)
        {
            //instantiation
            GameManager gameManager = new GameManager();

            //GameLoop
            gameManager.RunGame();
        }
    }
}
