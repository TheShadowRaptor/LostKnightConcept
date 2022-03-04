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
            Ghost ghost = new Ghost();
            Ghoul ghoul = new Ghoul();
            HUD hud = new HUD();
            Heart heart = new Heart();
            Player player = new Player();
            map.DisplayMap();
            heart.Update(player);
            skeleton.Update(player, map);
            ghost.Update(player, map);
            ghoul.Update(player, map);
            hud.ShowHUD(player, skeleton, map);
            

            while (isGameActive)
            {               
                if (player.isAlive)
                {
                    player.Update(map, skeleton, ghost, ghoul);
                }
                else break;

                map.DisplayMap();
                
                if (heart.isAlive)
                {
                    heart.Update(player);
                }

                if (skeleton.isAlive)
                {
                    skeleton.Update(player, map);
                }

                if (ghost.isAlive)
                {
                    ghost.Update(player, map);
                }

                if (ghoul.isAlive)
                {
                    ghoul.Update(player, map);
                }               

                hud.ShowHUD(player, skeleton, map);               
                
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
