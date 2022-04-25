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

        public void Update(Player player, Map map, Render render, Enemy[] enemy, InteractableObject[] interactableObject, int maxEnemies, int maxObjects, int currentTarget, Global global)
        {
            CheckIfDamaged(player, enemy, currentTarget);

            if (IsAlive())
            {
                Move(map, player, render, enemy, interactableObject, maxEnemies, maxObjects, global);
            }

            if (IsAlive() == false)
            {
                xData = map.row + 1;
                yData = map.colume + 1;

                x = xData;
                y = yData;
            }
        }

        public virtual void Move(Map map, Player player, Render render, Enemy[] enemy, InteractableObject[] interactableObject, int maxEnemies, int maxObjects, Global global)
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
                    preMoveX = player.xData;
                    preMoveY = player.yData;
                }

                // Checks of enemy can move
                if ((map.IsMapBounds(preMoveX, preMoveY) == false)
                        && map.IsFloor(preMoveX, preMoveY)
                        && CollideWithPlayer(player, preMoveX, preMoveY) == false
                        && CollideWithEnemy(enemy, preMoveX, preMoveY, maxEnemies) == false
                        && CollideWithDoor(interactableObject, preMoveX, preMoveY, maxObjects) == false
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
            || xData - 1 == player.xData && yData == player.yData
            || xData == player.xData && yData + 1 == player.yData
            || xData == player.xData && yData - 1 == player.yData)
            {
                Console.Beep();
                return true;
            }
            
            return false;
        }

        public bool CollideWithEnemy(Enemy[] enemy, int x, int y, int maxEnemies)
        {
            xData = x;
            yData = y;

            for (int currentTarget = 0; currentTarget < maxEnemies; currentTarget++)
            {
                if (enemy[currentTarget].xData == xData && enemy[currentTarget].yData == yData && enemy[currentTarget] != this)
                {                  
                    return true;
                }
            }
            return false;
        }

        protected void PlaySoundHitPlayer()
        {
            hit.Load();
            hit.Play();
        }
        protected void CheckIfDamaged(Player player, Enemy[] enemy, int currentTarget)
        {
            if (player.targetEnemy == true)
            {
                enemy[currentTarget].health = enemy[currentTarget].health - player.damage;
            }
        }
        protected bool CollideWithDoor(InteractableObject[] interactableObject, int x, int y, int maxObjects)
        {
            for (int currentTarget = 0; currentTarget < maxObjects; currentTarget++)
            {
                if (xData == interactableObject[currentTarget].xData && yData == interactableObject[currentTarget].yData && interactableObject[currentTarget].isActive == true)
                {
                    if (interactableObject[currentTarget].GetType() == typeof(Door)) return true;
                }
            }
            return false;
        }
    }
}
