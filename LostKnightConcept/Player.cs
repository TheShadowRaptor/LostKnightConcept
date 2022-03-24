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
        public bool gameover;
        public bool targetGhost;
        public bool targetGhoul;
        public Player()
        {
            // instatiation
            health = 5;

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
            // Check if taken damage
            TakeDamage(skeleton, ghost, ghoul);

            if (IsAlive() == true)
            {
                TakeDamage(skeleton, ghost, ghoul);
                Move(map, skeleton, ghost, ghoul, door);
            }

            if (IsAlive() == false)
            {
                xData = map.column + 1;
                yData = map.row + 1;
                gameover = true;
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
                targetSkeleton = true;
                return true;        
            }

            if (ghost.xData == xData && ghost.yData == yData)
            {
                PlaySoundHitEnemy();
                targetGhost = true;
                return true;
            }

            if (ghoul.xData == xData && ghoul.yData == yData)
            {
                PlaySoundHitEnemy();
                targetGhoul = true;
                return true;
            }
            return false;
        }
        protected void Move(Map map, Skeleton skeleton, Ghost ghost, Ghoul ghoul, Door door)
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
                if ((map.IsMapBounds(preMoveX, preMoveY) == false) 
                    && map.IsFloor(preMoveX, preMoveY) 
                    && CollidWithEnemy(skeleton, ghost, ghoul, preMoveX, preMoveY) == false)
                {
                    x = preMoveX;
                    y = preMoveY;
                }

                else
                {
                    PlaySoundHitWall();
                }

                break;
            }               
        }        
        protected void TakeDamage(Skeleton skeleton, Ghost ghost, Ghoul ghoul)
        {
            if (skeleton.targetPlayer == true)
            {
                health -= skeleton.damage;
                skeleton.targetPlayer = false;
            }

            if (ghost.targetPlayer == true)
            {
                health -= ghost.damage;
                ghost.targetPlayer = false;
            }

            if (ghoul.targetPlayer == true)
            {
                health -= ghoul.damage;
                ghoul.targetPlayer = false;
            }
        }
    }  
}
