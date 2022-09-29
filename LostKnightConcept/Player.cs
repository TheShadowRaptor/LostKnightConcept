using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class Player : GameCharacters
    {
        // fields
        private int startPositionX;
        private int startPositionY;

        private const int startHealth = 3;

        private const int startDamage = 1;

        private SoundPlayer hitWall = new SoundPlayer();

        public int resetPositionX;
        public int resetPositionY;

        private int preMoveX;
        private int preMoveY;

        public string playerGraphic;

        public bool showTarget;

        public int currentTarget;

        public bool targetEnemy;
        public bool gameover;

        public int keysHeld;
        public int moneyHeld;

        //public int OffsetX;
        //public int OffsetY;
        
        public Player()
        {
            Global global = new Global();

            // instatiation
            health = startHealth;

            damage = startDamage;

            startPositionX = global.mapRenderSizeY / 2;
            startPositionY = global.mapRenderSizeX / 2;

            x = startPositionX;
            y = startPositionY;

            preMoveX = x;
            preMoveY = y;

            resetPositionX = startPositionX;
            resetPositionY = startPositionY;

            backColor = ConsoleColor.DarkYellow;
            foreColor = ConsoleColor.White;

            characterGraphic = "P";
            playerGraphic = characterGraphic;
            name = "Guille";

            hit.SoundLocation = "Hit_Enemy.wav";
            hitWall.SoundLocation = "Hit_Wall.wav";
            showTarget = false;
        }
        
        public void Draw(Render render)
        {
            render.Draw(x, y, characterGraphic, foreColor, backColor);
        }

        public void Update(Map map, Render render, Global global, Enemy[] enemy, Collectable[] collectable, InteractableObject[] interactableObject, int maxEnemies, int maxCollectables, int maxObjects, ConsoleKey input)
        {
            // Check if taken damage
            CheckIfDamaged(enemy, maxEnemies);

            if (IsAlive() == true)
            {
                CanTeleport(interactableObject, maxObjects);
                Move(map, enemy, render, global, interactableObject, maxEnemies, maxObjects, input);
                ItemCollected(collectable, maxCollectables);
                CheckIfDamaged(enemy, maxEnemies);
            }

            else if (IsAlive() == false)
            {
                xData = map.row + 1;
                yData = map.colume + 1;
            }
        }
        protected void Move(Map map, Enemy[] enemy, Render render, Global global, InteractableObject[] interactableObject, int maxEnemies, int maxObjects, ConsoleKey input)
        {
            // checks if player can move
            preMoveY = y;
            preMoveX = x;
           

            // move player ============================
            if (input == ConsoleKey.W || input == ConsoleKey.UpArrow)
            {
                preMoveY--;
                xData = preMoveX;
                yData = preMoveY;
                
                if (CheckMove(map, enemy, interactableObject, maxEnemies, maxObjects))
                {
                    render.camera.preOffSetX--;
                }
            }
            else if (input == ConsoleKey.S || input == ConsoleKey.DownArrow)
            {
                preMoveY++;
                xData = preMoveX;
                yData = preMoveY;
                
                if (CheckMove(map, enemy, interactableObject, maxEnemies, maxObjects))
                {
                    render.camera.preOffSetX++;
                }
            }
            else if (input == ConsoleKey.A || input == ConsoleKey.LeftArrow)
            {
                preMoveX--;
                xData = preMoveX;
                yData = preMoveY;
               
                if (CheckMove(map, enemy, interactableObject, maxEnemies, maxObjects))
                {
                    render.camera.preOffSetY--;
                }
            }
            else if (input == ConsoleKey.D || input == ConsoleKey.RightArrow)
            {
                preMoveX++;
                xData = preMoveX;
                yData = preMoveY;
               
                if (CheckMove(map, enemy, interactableObject, maxEnemies, maxObjects))
                {
                    render.camera.preOffSetY++;
                }
            }
            else
            {
               
                if (CheckMove(map, enemy, interactableObject, maxEnemies, maxObjects)) ;
            }

            // =================================

           // check for Collision
           render.CheckCameraBounds(map);
           
        }


        private bool CollideWithEnemy(Enemy[] enemy, int checkX, int checkY, int maxEnemies)
        {
            for (currentTarget = 0; currentTarget < maxEnemies; currentTarget++)
            {
                if (enemy[currentTarget].xData == checkX && enemy[currentTarget].yData == checkY)
                {                  
                    PlaySoundHitEnemy();
                    targetEnemy = true;
                    return true;
                }
            }
            return false;
        }

        private bool CheckMove(Map map, Enemy[] enemy, InteractableObject[] interactableObject, int maxEnemies, int maxObjects)
        {
            if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                    && map.IsFloor(preMoveX, preMoveY)
                    && CollideWithEnemy(enemy, preMoveX, preMoveY, maxEnemies) == false
                    && CollideWithDoor(interactableObject, preMoveX, preMoveY, maxObjects) == false
                    && CollideWithShop(interactableObject, preMoveX, preMoveY, maxObjects) == false)
            {               

                        x = preMoveX;
                        y = preMoveY;
                     
                return true;
            }

            else
            {
                PlaySoundHitWall();
               
                return false;
            }
        }
        
        private bool CollideWithDoor(InteractableObject[] interactableObject, int checkX, int checkY, int maxObjects)
        {
            for (int currentTarget = 0; currentTarget < maxObjects; currentTarget++)
            {
                if (checkX == interactableObject[currentTarget].xData && checkY == interactableObject[currentTarget].yData && interactableObject[currentTarget].isActive == true)
                {
                    if (interactableObject[currentTarget].GetType() == typeof(Door)) return true;             
                }
            }
            return false;
        }

        private bool CollideWithShop(InteractableObject[] interactableObject, int checkX, int checkY, int maxObjects)
        {
            for (int currentTarget = 0; currentTarget < maxObjects; currentTarget++)
            {
                if (checkX == interactableObject[currentTarget].xData && checkY == interactableObject[currentTarget].yData && interactableObject[currentTarget].isActive == true)
                {
                    if (interactableObject[currentTarget].GetType() == typeof(Shop)) return true;
                }
            }
            return false;
        }


        protected void CheckIfDamaged(Enemy[] enemy, int maxEnemies)
        {
            for (int currentEnemy = 0; currentEnemy < maxEnemies; currentEnemy++)
            {
                if (enemy[currentEnemy].targetPlayer == true)
                {
                    health -= enemy[currentEnemy].damage;
                    enemy[currentEnemy].targetPlayer = false;
                }
            }
        }

        private void PlaySoundHitWall()
        {
            hitWall.Load();
            hitWall.Play();
        }
        private void PlaySoundHitEnemy()
        {
            hit.Load();
            hit.Play();
        }

        //uses items immediately on pickup
        private void ItemCollected(Collectable[] collectable, int maxCollectables)
        {
            for (int currentTarget = 0; currentTarget < maxCollectables; currentTarget++)
            {
                if (xData == collectable[currentTarget].xData && yData == collectable[currentTarget].yData)
                {
                    //if (collectable[currentTarget].GetType() == typeof(Heart)) health = health + 1;

                    //if (collectable[currentTarget].GetType() == typeof(DamageUp)) damage = damage + 1;

                    if (collectable[currentTarget].GetType() == typeof(Key)) keysHeld = keysHeld + 1;

                    if (collectable[currentTarget].GetType() == typeof(Money)) moneyHeld = moneyHeld + 1;

                    //if (collectable[currentTarget].GetType() == typeof(Money)) moneyHeld = moneyHeld + 1;
                }
            }
        }

        public void ApplyItemEffect(Collectable collectable)
        {
            if (collectable.GetType() == typeof(Heart)) health = health + 1;

            if (collectable.GetType() == typeof(DamageUp)) damage = damage + 1;

            if (collectable.GetType() == typeof(Key)) keysHeld = keysHeld + 1;
        }

        private void CanTeleport(InteractableObject[] interactableObject, int maxObjects)
        {
            for (int currentTarget  = 0; currentTarget < maxObjects; currentTarget++)
            {
                if (xData == interactableObject[currentTarget].xData && yData == interactableObject[currentTarget].yData)
                {
                    if (interactableObject[currentTarget].GetType() == typeof(Teleporter))
                    {                     
                        Console.Beep();
                        //teleport player to teleporterDestination
                    }
                }
            }
        }
    }  
}
