using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class Player : GameCharacter
    {
        // fields
        private const int startPositionX = 1;
        private const int startPositionY = 1;

        private int preMoveX;
        private int preMoveY;

        private SoundPlayer hitWall = new SoundPlayer();      
        
        public char playerGraphic;

        public bool showTarget;

        public int playerDamage;

        public bool doorCollide;

        public bool targetSkeleton;
        public bool targetGhost;
        public bool targetGhoul;
        public Player()
        {
            // instatiation
            health = 2;

            playerDamage = 1;
            x = startPositionX;
            y = startPositionY;

            backColor = ConsoleColor.DarkYellow;
            foreColor = ConsoleColor.White;

            charGraphic = 'P';
            playerGraphic = charGraphic;
            name = "Guille";

            hit.SoundLocation = "Hit_Enemy.wav";
            hitWall.SoundLocation = "Hit_Wall.wav";
            showTarget = false;
        }

        public void Update(Map map, Skeleton skeleton, Ghost ghost, Ghoul ghoul, Door door)
        {          
            if(IsAlive() == true)
            {        
                Move(map, skeleton, ghost, ghoul, door);
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
        private bool CollidWithEnemy(Skeleton skeleton, Ghost ghost, Ghoul ghoul, int x, int y)
        {            
            xData = x;
            yData = y;

            if (skeleton.xData == xData && skeleton.yData == yData)
            {
                PlaySoundHitEnemy();
                health -= skeleton.damage;
                targetSkeleton = true;
                return true;        
            }

            if (ghost.xData == xData && ghost.yData == yData)
            {
                PlaySoundHitEnemy();
                health -= ghost.damage;
                targetGhost = true;
                return true;
            }

            if (ghoul.xData == xData && ghoul.yData == yData)
            {
                PlaySoundHitEnemy();
                health -= ghoul.damage;
                targetGhoul = true;
                return true;
            }
            return false;
        }
        protected void Move(Map map, Skeleton skeleton, Ghost ghost, Ghoul ghoul, Door door)
        {
            // moves player with button input          
            bool inputLoop;
            inputLoop = true;

            // checks if player can move
            preMoveY = y;
            preMoveX = x;

            while (inputLoop == true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                

                // move player ============================
                if (input.Key == ConsoleKey.W)
                {
                    preMoveY--;
                }

                else if (input.Key == ConsoleKey.S)
                {
                    preMoveY++;
                }

                else if (input.Key == ConsoleKey.A)
                {
                    preMoveX--;
                }

                else if (input.Key == ConsoleKey.D)
                {
                    preMoveX++;
                }
                // =================================
               
                // check for Collision
                if ((map.IsMapBounds(preMoveX, preMoveY) == false) && map.IsFloor(preMoveX, preMoveY))
                {
                    x = preMoveX;
                    y = preMoveY;
                }
                // -------------------------------------------------
                //if hit collision
                else
                {
                    PlaySoundHitWall();
                }
               
                break;
            }               
        }        
    }  
}
