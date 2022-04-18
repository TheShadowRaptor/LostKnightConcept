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

        private const int startHealth = 5;

        private const int startDamage = 1;

        public int resetPositionX;
        public int resetPositionY;

        private int preMoveX;
        private int preMoveY;

        //public int OffsetX;
        //public int OffsetY;

        private SoundPlayer hitWall = new SoundPlayer();      
        
        public string playerGraphic;

        public bool showTarget;

        public int currentTarget;

        public bool targetEnemy;
        public bool gameover;
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

        public void Update(Map map, Door door, Render render, Global global, Enemy[] enemy, int maxEnemies)
        {
            // Check if taken damage
            CheckIfDamaged(enemy, maxEnemies);

            if (IsAlive() == true)
            {
                CheckIfDamaged(enemy, maxEnemies);
                Move(map, enemy, door, render, global, maxEnemies);
            }

            else if (IsAlive() == false)
            {
                xData = map.row + 1;
                yData = map.colume + 1;
            }
        }
        protected void Move(Map map, Enemy[] enemy, Door door, Render render, Global global, int maxEnemies)
        {
            // checks if player can move
            preMoveY = y;
            preMoveX = x;

            // moves player with button input          
            bool inputLoop;
            inputLoop = true;

            while (inputLoop == true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);


                // move player ============================
                if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
                {
                    preMoveY--;
                    if (CheckMove(map, door, enemy, maxEnemies)) render.camera.preOffSetX--;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
                {
                    preMoveY++;
                    if (CheckMove(map, door, enemy, maxEnemies)) render.camera.preOffSetX++;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
                {
                    preMoveX--;
                    if (CheckMove(map, door, enemy, maxEnemies)) render.camera.preOffSetY--;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
                {
                    preMoveX++;
                    if (CheckMove(map, door, enemy, maxEnemies)) render.camera.preOffSetY++;
                    inputLoop = false;
                }

                // =================================

                // check for Collision
                render.CheckCameraScroll(map);
            }
        }
        private bool CollideWithEnemy(Enemy[] enemy, int x, int y, int maxEnemies)
        {
            xData = x;
            yData = y;

            for (currentTarget = 0; currentTarget < maxEnemies; currentTarget++)
            {
                if (enemy[currentTarget].xData == xData && enemy[currentTarget].yData == yData)
                {
                    PlaySoundHitEnemy();
                    targetEnemy = true;
                    return true;
                }
            }
            return false;
        }

        private bool CheckMove(Map map, Door door, Enemy[] enemy, int maxEnemies)
        {
            if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                    && map.IsFloor(preMoveX, preMoveY)
                    && CollideWithEnemy(enemy, preMoveX, preMoveY, maxEnemies) == false
                    && CollideWithDoor(door, preMoveX, preMoveY) == false)
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
        
        private bool CollideWithDoor(Door door, int x, int y)
        {
            xData = x;
            yData = y;

            if (door.xData == xData && door.yData == yData && door.isActive == true)
            {
                return true;
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
    }  
}
