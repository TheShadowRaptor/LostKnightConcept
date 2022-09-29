using System;
using System.Diagnostics;

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
            MenuManager menuManager = new MenuManager(global.pauseMenuFile);
            InputManager inputManager = new InputManager();
            

            Title title = new Title();
            Gameover gameover = new Gameover();
            Win win = new Win();
            

            Door door = new Door();
            Player player = new Player();
            Inventory inventory = new Inventory();
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
                    hud.ShowHUD(map, player, collectableManager.key, enemyMananger.enemy, enemyMananger.maxEnemies);
                    // Do not allow normal draws when menus are open or game is paused
                    if (!menuManager.focusMenu)
                    {
                        // Draw Map and HUD
                        map.DisplayMap(render);
                        

                        // Draw GameObjects
                        collectableManager.Draw(render);
                        interactableObjectMananger.Draw(render);
                        player.Draw(render);
                        enemyMananger.Draw(render, map);
                    }

                    

                    //Update inputManager
                    inputManager.Update();


                    // Do not allow world updates when menus are open or game is paused
                    if (!menuManager.focusMenu)
                    {
                        // Update GameObjects
                        player.Update(map, render, global, enemyMananger.enemy, collectableManager.collectable, interactableObjectMananger.interactableObject, enemyMananger.maxEnemies, collectableManager.maxCollectables, interactableObjectMananger.maxObjects, inputManager.input);
                        camera.Update(player);

                        collectableManager.Update(player, map, inventory);
                        enemyMananger.Update(player, map, render, interactableObjectMananger.interactableObject, interactableObjectMananger.maxObjects, global);
                    }

                    interactableObjectMananger.Update(player);

                    // Update menuManager
                    menuManager.Update(inputManager.input, inventory, player, interactableObjectMananger.interactableObject);

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
