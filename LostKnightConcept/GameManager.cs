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
            
            // Gameloop
            while (isGameActive)
            {
                map.DisplayMap();
                hud.ShowHUD(map, player, skeleton, ghost, ghoul, key);
                player.Draw();
                player.Update(map, skeleton, ghost, ghoul, door);
                /*map.DisplayMap();
                heart.Update(player);
                damageUp.Update(player);
                key.Update(player);
                door.Update(player, key);
                skeleton.Update(player, map);
                ghost.Update(player, map);*/

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
