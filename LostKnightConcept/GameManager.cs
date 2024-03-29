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
            Global global = new Global();
            GameManager gameManager = new GameManager();
            ResetGame resetGame = new ResetGame();
            

            Title title = new Title();
            Gameover gameover = new Gameover();
            Win win = new Win();
            

            Door door = new Door();
            Player player = new Player();
            Map map = new Map();
            InteractableObjectMananger interactableObjectMananger = new InteractableObjectMananger(global, map, player);
            EnemyMananger enemyMananger = new EnemyMananger(map, player, global);
            CollectableManager collectableManager = new CollectableManager(map, player, global);

            Camera camera = new Camera();
            Render render = new Render(camera, global);

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
                    hud.ShowHUD(map, player, collectableManager.key, enemyMananger.enemy, enemyMananger.maxEnemies);

                    // Draw GameObjects
                    collectableManager.Draw(render);
                    interactableObjectMananger.Draw(render);
                    player.Draw(render);
                    enemyMananger.Draw(render, map);

                    // Update GameObjects
                    player.Update(map, render, global,  enemyMananger.enemy, collectableManager.collectable, interactableObjectMananger.interactableObject, enemyMananger.maxEnemies, collectableManager.maxCollectables, interactableObjectMananger.maxObjects);
                    camera.Update(player);

                    collectableManager.Update(player, map);
                    enemyMananger.Update(player, map, render, interactableObjectMananger.interactableObject, interactableObjectMananger.maxObjects, global);
                    interactableObjectMananger.Update(player, map);

                    // Gameover
                    if (player.IsAlive() == false)
                    {
                        gameover.Draw();
                        gameover.Update(gameManager);
                    }

                    // Gamewin
                    if (enemyMananger.enemy[enemyMananger.maxEnemies - 1].IsAlive() == false)
                    {
                        win.Draw();
                        win.Update(gameManager);
                    }
                }
            }           
        }
    }
}
