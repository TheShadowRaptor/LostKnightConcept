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
            Global global = new Global();
            GameManager gameManager = new GameManager();
            ResetGame resetGame = new ResetGame();
            

            Title title = new Title();
            Gameover gameover = new Gameover();
            Win win = new Win();
            

            Door door = new Door();
            Player player = new Player();
            Map map = new Map();
            EnemyMananger enemyMananger = new EnemyMananger(map);
            CollectableManager collectableManager = new CollectableManager();

            Camera camera = new Camera();
            Render render = new Render(camera);

            HUD hud = new HUD();

            // Gameloop
            while (gameManager.isGameActive) 
            {
                //Title
                while (title.isActive)
                {
                    title.Draw();
                    title.Update(gameManager);
                }

                if (gameManager.isGameActive)
                {
                    // Draw UI                  
                    map.DisplayMap(render);
                    hud.ShowHUD(map, player, collectableManager.key);

                    // Draw GameObjects
                   /* collectableManager.Draw(render);*/
                    player.Draw(render);
                    enemyMananger.Draw(render, map, global);
                    /*door.Draw();*/

                    // Update GameObjects
                    /*collectableManager.Update(player);*/
                    player.Update(map, door, render, global);
                    camera.Update(player);

                    enemyMananger.UpdateEnemies(player, map, render, global);
                    /*door.Update(player, collectableManager.key);*/

                    // Gameover
                    if (player.IsAlive() == false)
                    {
                        gameover.Draw();
                        gameover.Update(gameManager);
                    }

                    // Gamewin
                    /*if (enemyMananger.ghoul.IsAlive() == false)
                    {
                        win.Draw();
                        win.Update(gameManager);
                    }*/
                }
            }           
        }
    }
}
