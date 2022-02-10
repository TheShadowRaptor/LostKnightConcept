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

        static bool isGameActive = true;

        static void Main(string[] args)
        {
            //instantiation
            Map map = new Map();
            Player player = new Player();

            while (isGameActive)
            {
                map.DisplayMap();
                player.Update(map);        
            }        
        }
    }
}
