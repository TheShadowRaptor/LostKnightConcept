using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class EnemyClass : GameCharacters
    {
        // fields
        private const int startPosX = 5;
        private const int startPosY = 2;

        protected int preMoveX;
        protected int preMoveY;

        protected Random rng;

        public char enemyGraphic;

        public int damage;

        public bool targetPlayer;
        public EnemyClass()
        {
            // instatiation
            x = startPosX;
            y = startPosY;

            rng = new Random(0);

            hit.SoundLocation = "Hit_Player.wav";
        }

        protected void Move(Map map, Player player)
        {
            // checks if enemy can move
            preMoveY = y;
            preMoveX = x;

            // moves enemy with randomizer
            int direction;
            int wait;

            direction = rng.Next(0, 4);
            wait = rng.Next(0, 2);

            if (wait == 1)
            {
                if (direction == 0)
                {
                    preMoveY--;                   
                }

                else if (direction == 1)
                {
                    preMoveY++;                   
                }

                else if (direction == 2)
                {
                    preMoveX--;                  
                }

                else if (direction == 3)
                {
                    preMoveX++;                                   
                }
            }

            if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                && map.IsFloor(preMoveX, preMoveY)
                && CollideWithPlayer(player, preMoveX, preMoveY) == false
                && player.targetSkeleton == false)
            {
                x = preMoveX;
                y = preMoveY;
            }
            // Updates enemies position
            xData = x;
            yData = y;
        }
        public bool CollideWithPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;           

            if (player.xData == xData && player.yData == yData)
            {
                PlaySoundHitPlayer();
                targetPlayer = true;
                return true;
            }
            return false;
        }
        private void PlaySoundHitPlayer()
        {
            hit.Load();
            hit.Play();
        }     
    }
}
