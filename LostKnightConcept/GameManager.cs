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
            DamageUp damageUp = new DamageUp();
            Key key = new Key();
            Door door = new Door();
            Player player = new Player();
            map.DisplayMap();
            heart.Update(player);
            damageUp.Update(player);
            key.Update(player);
            door.Update(player, key);
            skeleton.Update(player, map);
            ghost.Update(player, map);
            ghoul.Update(player, map);
            hud.ShowHUD(map, player, skeleton, ghost, ghoul, key);
            

            while (isGameActive)
            {
                map.DisplayMap();
                Console.ReadKey();
                /*if (player.isAlive)
                {
                    player.Update(map, skeleton, ghost, ghoul, door);
                }
                else break;

                map.DisplayMap();
                
                if (heart.isAlive)
                {
                    heart.Update(player);
                }

                if (damageUp.isAlive)
                {
                    damageUp.Update(player);
                }

                if (key.isAlive)
                {
                    key.Update(player);
                }

                if (door.isAlive)
                {
                    door.Update(player, key);
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

                hud.ShowHUD(map, player, skeleton, ghost, ghoul, key);               
                
                Console.SetCursorPosition(0, 0);*/
            }
        }
    }
}
