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
            EnemyMananger enemyMananger = new EnemyMananger();
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
                hud.ShowHUD(map, player, enemyMananger.skeleton, enemyMananger.ghost, enemyMananger.ghoul, key);
                player.Draw();
                heart.Draw();
                enemyMananger.DrawEnemies();
                player.Update(map, enemyMananger.skeleton, enemyMananger.ghost, enemyMananger.ghoul, door);
                heart.Update(player);
                enemyMananger.UpdateEnemies(player, map);
                /*map.DisplayMap();
                damageUp.Update(player);
                key.Update(player);
                door.Update(player, key);*/

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
