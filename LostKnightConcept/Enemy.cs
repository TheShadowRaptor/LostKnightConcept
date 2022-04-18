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
        protected int preMoveX;
        protected int preMoveY;

        public int currentTarget;

        public string graphic;


        public string enemyName;

        public bool targetPlayer;

        public Enemy()
        {
            // instatiation
            hit.SoundLocation = "Hit_Player.wav";
        }

        public void Draw(string name, Render render)
        {
            enemyName = name;
            render.Draw(x, y, graphic, foreColor, backColor);           
            
        }
        public virtual void Move(Map map, Player player, Render render, Enemy[] enemy, int maxEnemies, Global global)
        {
            // checks if enemy can move
            preMoveY = y;
            preMoveX = x;

            // moves enemy with randomizer
            int direction;
            int wait;

            direction = global.rng.Next(0, 4);
            wait = global.rng.Next(0, 2);

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
                && CollideWithEnemy(enemy, preMoveX, preMoveY, maxEnemies) == false
                && player.targetEnemy == false)
            {
                x = preMoveX;
                y = preMoveY;
            }
            // Updates enemies position
            xData = x;
            yData = y;
        }
        protected bool CollideWithPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;           

            if (xData == player.xData && yData == player.yData)
            {
                PlaySoundHitPlayer();
                targetPlayer = true;
                return true;
            }
            return false;
        }
        protected bool CollideWithEnemy(Enemy[] enemy, int x, int y, int maxEnemies)
        {
            xData = x;
            yData = y;


            if (xData == enemy[currentTarget].xData && yData == enemy[currentTarget].yData)
            {
                return true;
            }

            return false;
        }

        protected void PlaySoundHitPlayer()
        {
            hit.Load();
            hit.Play();
        }
        protected void CheckIfHit(Player player, Enemy[] enemy)
        {
            if (player.targetEnemy == true)
            {
                enemy[player.currentTarget].health -= player.damage;
                /*health -= player.damage;*/
            }
        }
        public void Update(Player player, Map map, Render render, Enemy[] enemy, int maxEnemies, Global global)
        {
            if (IsAlive())
            {
                CheckIfHit(player, enemy);
                Move(map, player, render, enemy, maxEnemies, global);
            }

            if (IsAlive() == false)
            {
                xData = map.row + 1;
                yData = map.colume + 1;

                x = xData;
                y = yData;
            }
        }
    }
}
