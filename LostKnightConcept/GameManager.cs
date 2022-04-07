﻿using System;

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

            Camera camera = new Camera();
            Render render = new Render(camera);

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
                    collectableManager.Draw(render);
                    player.Draw(render);
                    /*enemyMananger.Draw(render, map);*/
                    door.Draw();

                    // Update GameObjects
                    collectableManager.Update(player);
                    player.Update(map, door);
                    camera.Update(player);
                    /*enemyMananger.UpdateEnemies(player, map);*/
                    door.Update(player, collectableManager.key);


                    // Reset Cursor
                    Console.SetCursorPosition(0, 0);

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
