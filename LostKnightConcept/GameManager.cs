using System;

namespace LostKnightConcept
{
    class GameManager
    {
        public bool isGameActive;
        public GameManager()
        {
            isGameActive = true;
        }
        public void RunGame()
        {
            //instantiation
            GameManager gameManager = new GameManager();
            ResetGame resetGame = new ResetGame();
            Map map = new Map();
            HUD hud = new HUD();

            Title title = new Title();
            Gameover gameover = new Gameover();
            Win win = new Win();

            Door door = new Door();
            Player player = new Player();
            EnemyMananger enemyMananger = new EnemyMananger();
            CollectableManager collectableManager = new CollectableManager();

            // Gameloop
            while (gameManager.isGameActive) 
            {
                //Title
                while (title.isActive)
                {
                    title.Draw(player);
                    title.Update(gameManager);
                }

                if (gameManager.isGameActive)
                {
                    // Draw UI
                    map.DisplayMap();
                    hud.ShowHUD(map, player, enemyMananger.skeleton, enemyMananger.ghost, enemyMananger.ghoul, collectableManager.key);

                    // Draw GameObjects
                    collectableManager.DrawCollectables();
                    player.Draw();
                    enemyMananger.DrawEnemies();
                    door.Draw();

                    // Update GameObjects
                    collectableManager.UpdateCollectables(player);
                    player.Update(map, enemyMananger.skeleton, enemyMananger.ghost, enemyMananger.ghoul, door);
                    enemyMananger.UpdateEnemies(player, map);
                    door.Update(player, collectableManager.key);

                    // Reset Cursor
                    Console.SetCursorPosition(0, 0);

                    // Gameover
                    if (player.IsAlive() == false)
                    {
                        gameover.Draw();
                        gameover.Update(gameManager);
                    }

                    if (enemyMananger.ghoul.IsAlive() == false)
                    {
                        win.Draw();
                        win.Update(gameManager);
                    }
                }

            }           
        }
    }
}
