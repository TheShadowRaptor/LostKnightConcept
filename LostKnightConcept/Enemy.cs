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
        public virtual void Move(Map map, Player player, Render render, Enemy[] enemy, int maxEnemies, int currentEnemy, Global global)
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
                if (DetectPlayer(player, x, y) == false)
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

                else
                {
                    Console.Beep();
                }

                // Checks of enemy can move
                if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                        && map.IsFloor(preMoveX, preMoveY)
                        && CollideWithPlayer(player, preMoveX, preMoveY) == false
                        && CollideWithEnemy(enemy, preMoveX, preMoveY, currentEnemy) == false
                        && player.targetEnemy == false)
                {
                    x = preMoveX;
                    y = preMoveY;
                }
            }               
            
            // Updates enemies position
            xData = x;
            yData = y;
        }
        public bool CollideWithPlayer(Player player, int x, int y)
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

        public bool DetectPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (player.xData == xData + 1 && player.yData == yData
                || x - 1 == player.xData && yData == player.yData
                || x == player.x && y + 1 == player.y
                || x == player.x && y - 1 == player.y)
            {
                return true;
            }
            return false;
        }

        public bool CollideWithEnemy(Enemy[] enemy, int x, int y, int currentEnemy)
        {
            xData = x;
            yData = y;

            if (xData == enemy[currentEnemy].xData && yData == enemy[currentEnemy].yData && enemy[currentEnemy] != this)
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
        protected void CheckIfDamaged(Player player, Enemy[] enemy, int currentEnemy)
        {
            if (player.targetEnemy == true)
            {
                /*enemy[currentEnemy].health = enemy[currentEnemy].health - player.damage;*/
                /*health -= player.damage;*/
            }
        }
        public void Update(Player player, Map map, Render render, Enemy[] enemy, int maxEnemies, int currentEnemy, Global global)
        {
            if (IsAlive())
            {
                CheckIfDamaged(player, enemy, currentEnemy);
                Move(map, player, render, enemy, maxEnemies, currentEnemy, global);
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
