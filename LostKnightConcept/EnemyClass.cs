using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class EnemyClass : GameCharacter
    {
        // fields
        private const int startPosX = 5;
        private const int startPosY = 2;

        public char enemyGraphic;

        public int damage;
        public EnemyClass()
        {
            // instatiation
            x = startPosX;
            y = startPosY;

            rng = new Random(0);
            rng2 = new Random(1);
            rng3 = new Random(2);

            hit.SoundLocation = "Hit_Player.wav";
        }

        public void Update(Player player, Map map)
        {
            CheckIfDead();

            if (isAlive == true)
            {
                Draw();
                Move(map, player);
            }
            else
            {
                xData = map.map.GetLength(0) + 1;
                yData = map.map.GetLength(1) + 1;
            }
        }

        protected void Move(Map map, Player player)
        {
            int direction;
            int wait;
            bool canMove;

            canMove = false;

            direction = rng.Next(0, 4);
            wait = rng.Next(0, 2);

            if (wait == 1)
            {
                if (direction == 0)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsHit(player, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        y++;
                        if (IsHit(player, x, y) == true)
                        {
                            y++;
                        }
                    }
                }

                else if (direction == 1)
                {
                    x--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsHit(player, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        x++;
                        if (IsHit(player, x, y) == true)
                        {
                            x++;
                        }
                    }
                }

                else if (direction == 2)
                {
                    x++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsHit(player, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        x--;
                        if (IsHit(player, x, y) == true)
                        {
                            x--;
                        }
                    }
                }

                else if (direction == 3)
                {
                    y++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsHit(player, x, y) == false)
                        {
                            if (map.IsFloor(x, y))
                            {
                                canMove = true;
                            }
                        }
                    }

                    if (canMove == false)
                    {
                        y--;
                        if (IsHit(player, x, y) == true)
                        {
                            y--;
                        }
                    }
                }
            }
        }
        public bool IsHit(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (player.xData == xData && player.yData == yData)
            {
                PlaySoundHitPlayer();
                health -= player.playerDamage;
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
