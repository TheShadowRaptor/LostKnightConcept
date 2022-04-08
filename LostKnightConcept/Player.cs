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

        public int playerDamage;

        public bool targetSkeleton;
        public bool gameover;
        public bool targetGhost;
        public bool targetGhoul;
        public Player()
        {
            Global global = new Global();

            // instatiation
            health = startHealth;

            playerDamage = startDamage;
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
        
        public void Draw(Render render, Map map)
        {
            render.Draw(x, y, characterGraphic, foreColor, backColor, map);
        }

        public void Update(Map map, Door door, Render render)
        {
            // Check if taken damage
            /*TakeDamage(skeleton);*/

            if (IsAlive() == true)
            {
                /*TakeDamage(skeleton);*/
                Move(map, /*skeleton*/ door, render);
            }

            else if (IsAlive() == false)
            {
                xData = map.row + 1;
                yData = map.colume + 1;
            }
        }
        protected void Move(Map map, /*Skeleton skeleton*/ Door door, Render render)
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
                    if (CheckMove(map, door)) render.camera.preOffSetX--;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
                {
                    preMoveY++;
                    if (CheckMove(map, door)) render.camera.preOffSetX++;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
                {
                    preMoveX--;
                    if (CheckMove(map, door)) render.camera.preOffSetY--;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
                {
                    preMoveX++;
                    if (CheckMove(map, door)) render.camera.preOffSetY++;
                    inputLoop = false;
                }

                // =================================

                // check for Collision
                render.CheckCameraScroll(map, render);
            }
        }
        /*private bool CollidWithEnemy(Skeleton skeleton, Ghost ghost, Ghoul ghoul, int x, int y)
        {            
            xData = x;
            yData = y;

            if (skeleton.xData == xData && skeleton.yData == yData)
            {
                PlaySoundHitEnemy();
                targetSkeleton = true;
                return true;        
            }
            return false;
        }*/

        private bool CheckMove(Map map, Door door)
        {
            if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                    && map.IsFloor(preMoveX, preMoveY)
                    /*&& CollidWithEnemy(skeleton, ghost, ghoul, preMoveX, preMoveY) == false*/
                    && CollidWithDoor(door, preMoveX, preMoveY) == false)
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
        
        private bool CollidWithDoor(Door door, int x, int y)
        {
            xData = x;
            yData = y;

            if (door.xData == xData && door.yData == yData && door.isActive == true)
            {
                return true;
            }
            return false;
        }
        /*protected void TakeDamage(Skeleton skeleton, Ghost ghost, Ghoul ghoul)
        {
            if (skeleton.targetPlayer == true)
            {
                health -= skeleton.damage;
                skeleton.targetPlayer = false;
            }
        }*/

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
