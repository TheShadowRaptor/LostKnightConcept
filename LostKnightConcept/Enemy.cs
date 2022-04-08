using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class Enemy : GameCharacters
    {
        // fields
        private const int startPosX = 5;
        private const int startPosY = 2;

        protected int preMoveX;
        protected int preMoveY;

        protected Random rng;

        public string graphic;

        public int enemyDamage;
        public string enemyName;

        public bool targetPlayer;
        public Enemy()
        {
            // instatiation
            x = startPosX;
            y = startPosY;

            rng = new Random(0);

            hit.SoundLocation = "Hit_Player.wav";
        }
<<<<<<< HEAD
<<<<<<< HEAD
        public void Draw(int x, int y, string name, Render render, Map map)
=======
        public void SetEnemy(int x, int y, string name, Render render)
>>>>>>> parent of 061f1dc ([FIXED] Camera Guard Clause)
=======
        public void SetEnemy(int x, int y, string name, Render render)
>>>>>>> parent of 061f1dc ([FIXED] Camera Guard Clause)
        {
            enemyName = name;
            this.x = x;
            this.y = y;
            render.Draw(x, y, graphic, foreColor, backColor, map);           
        }
        public void Move(Map map, Player player, Render render)
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
        private void TakeDamage(Player player)
        {
            if (player.targetSkeleton == true)
            {
                health -= player.playerDamage;
            }
        }
        public void Update(Player player, Map map, Render render)
        {
            if (IsAlive())
            {
                Move(map, player, render);
            }

            if (IsAlive() == false)
            {
                xData = map.row + 1;
                yData = map.colume + 1;
            }
        }
    }
}
