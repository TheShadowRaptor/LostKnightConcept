﻿using System;
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

        private const int startHealth = 5;

        private const int startDamage = 1;

        public int resetPositionX;
        public int resetPositionY;

        private int preMoveX;
        private int preMoveY;

        private SoundPlayer hitWall = new SoundPlayer();      
        
        public char playerGraphic;

        public bool showTarget;

        public int playerDamage;

        public bool targetSkeleton;
        public bool gameover;
        public bool targetGhost;
        public bool targetGhoul;
        public Player()
        {
            // instatiation
            health = startHealth;

            playerDamage = startDamage;

            x = startPositionX;
            y = startPositionY;

            resetPositionX = startPositionX;
            resetPositionY = startPositionY;

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
            }
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
                if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
                {
                    preMoveY--;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
                {
                    preMoveY++;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
                {
                    preMoveX--;
                    inputLoop = false;
                }

                else if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
                {
                    preMoveX++;
                    inputLoop = false;
                }

                // =================================

                // check for Collision
                if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                    && map.IsFloor(preMoveX, preMoveY)
                    && CollidWithEnemy(skeleton, ghost, ghoul, preMoveX, preMoveY) == false
                    && CollidWithDoor(door, preMoveX, preMoveY) == false)
                {
                    x = preMoveX;
                    y = preMoveY;
                }

                else
                {
                    PlaySoundHitWall();
                }
            }
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
