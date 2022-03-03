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

        private SoundPlayer hitWall = new SoundPlayer();      
        
        public char playerGraphic;

        public bool showTarget;
        public Player()
        {
            // instatiation
            health = 2;

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

        public void Update(EnemyClass enemy, Map map)
        {
            CheckIfDead();
            
            if(isAlive)
            {
                Draw();           
                Move(map, enemy);
            }               
        }
        

        
        private void Draw()
        {
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            DrawChar(charGraphic, backColor, foreColor);           
            Console.CursorVisible = false;
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

        private void Move(Map map, EnemyClass enemy)
        {
            // moves player with button input          
            bool inputLoop;
            bool canMove;
            inputLoop = true;
            canMove = false;
  
            while (inputLoop == true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.W)
                {
                    y--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
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
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            PlaySoundHitWall();
                        }

                        else if (IsOnEnemy(enemy, x, y) == true)
                        {
                            y++;
                        }                        
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.A)
                {
                    x--;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
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
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            PlaySoundHitWall();
                        }
                        else if (IsOnEnemy(enemy, x, y) == true)
                        {
                            x++;
                        }                        
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.D)
                {
                    x++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
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
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            PlaySoundHitWall();
                        }

                        else if (IsOnEnemy(enemy, x, y) == true)
                        {
                            x--;
                        }                       
                        break;
                    }
                    break;
                }

                else if (input.Key == ConsoleKey.S)
                {
                    y++;
                    if (map.IsMapBounds(x, y) == false)
                    {
                        if (IsOnEnemy(enemy, x, y) == false)
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
                        if (IsOnEnemy(enemy, x, y) == false)
                        {
                            PlaySoundHitWall();
                        }

                        else if (IsOnEnemy(enemy, x, y) == true)
                        {
                            y--;
                        }                      
                        break;
                    }
                    break;
                }
            }               
        }        
        private bool IsOnEnemy(EnemyClass enemy, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == enemy.xData && yData == enemy.yData)
            {
                PlaySoundHitEnemy();
                enemy.health -= 1;
                showTarget = true;
                return true;        
            }
            return false;
        }         
    }  
}
