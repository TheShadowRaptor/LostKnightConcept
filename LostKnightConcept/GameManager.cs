using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class GameManager
    {
        bool isGameActive = true;
        public void RunGame()
        {
            //instantiation
            Map map = new Map();            
            Skeleton skeleton = new Skeleton();
            HUD hud = new HUD();
            Heart heart = new Heart();
            Player player = new Player();
            map.DisplayMap();
            heart.Update(player);
            skeleton.Update(player, map);
            hud.ShowHUD(player, skeleton, map);
            

            while (isGameActive)
            {               
                if (player.isAlive)
                {
                    player.Update(skeleton, map);
                }
                else break;

                map.DisplayMap();

                if (skeleton.isAlive)
                {
                    skeleton.Update(player, map);
                }

                if (heart.isAlive)
                {
                    heart.Update(player);
                }

                hud.ShowHUD(player, skeleton, map);               
                
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
