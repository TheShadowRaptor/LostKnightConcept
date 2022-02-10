using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Enemy : Character
    {
        // fields
        private const int startPositionX = 5;
        private const int startPositionY = 2;

      
        public Enemy()
        {
            // instatiation
            health = 1;

            x = startPositionX;
            y = startPositionY;

            rng = new Random();

            name = "Skeleton";
        }

        public void Update(Player player, Map map)
        {
                Draw();
                MoveEnemy(map);
                hitPlayer(player);
                CheckIfAlive();                  
        }

        public void Draw()
        {
            // draws enemy position
            Console.SetCursorPosition(x + 1, y + 1);

            xData = x;
            yData = y;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('#');
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void MoveEnemy(Map map)
        {
            attackUp = false;
            attackDown = false;
            attackRight = false;
            attackLeft = false;
            attacked = false;

            int choice;

            choice = rng.Next(1, 5);

            if(choice == 1)
            {
                // moves up
                y--;
                attackUp = true;
                if (map.IsWall(x, y) == true)
                {
                    y++;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    y++;
                    attacked = false;
                }
            }
            
            else if(choice == 2)
            {
                // moves left
                x--;
                attackLeft = true;
                if (map.IsWall(x, y) == true)
                {
                    x++;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    x++;
                    attacked = false;
                }
            }

            else if (choice == 3)
            {
                // moves right
                x++;
                attackRight = true;
                if (map.IsWall(x, y) == true)
                {
                    x--;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    x--;
                    attacked = false;
                }
            }

            else if (choice == 4)
            {
                // moves down
                y++;
                attackDown = true;
                if (map.IsWall(x, y) == true)
                {
                    y--;
                    map.boundsHit = false;
                }

                else if (attacked == true)
                {
                    y--;
                    attacked = false;
                }
            }
        }

        public void hitPlayer(Player player)
        {
            if (yData + 1 == player.yData && xData == player.xData && attackDown == true)
            {
                attacked = true;
                Console.Beep();
                player.health -= 1;
            }

            if (yData - 1 == player.yData && xData == player.xData && attackUp == true)
            {
                attacked = true;
                Console.Beep();
                player.health -= 1;
            }

            if (xData + 1 == player.xData && yData == player.yData && attackRight == true)
            {
                attacked = true;
                Console.Beep();
                player.health -= 1;
            }

            if (xData - 1 == player.xData && yData == player.yData && attackLeft == true)
            {
                attacked = true;
                Console.Beep();
                player.health -= 1;
            }
        }
        private void CheckIfAlive()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }
    }
}
