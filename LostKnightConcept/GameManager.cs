using System;

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
            while (isGameActive && player.gameover == false)
            {
                map.DisplayMap();
                hud.ShowHUD(map, player, skeleton, ghost, ghoul, key);
                player.Draw();
                skeleton.Draw();
                ghost.Draw();
                ghoul.Draw();
                player.Update(map, skeleton, ghost, ghoul, door);
                skeleton.Update(player, map);
                ghost.Update(player, map);
                ghoul.Update(player, map);
                /*map.DisplayMap();
                heart.Update(player);
                damageUp.Update(player);
                key.Update(player);
                door.Update(player, key);*/

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
