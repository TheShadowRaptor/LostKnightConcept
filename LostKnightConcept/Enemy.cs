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

            checkIfDead();
            if (isAlive == true)
            {
                Draw();
                checkIfOnPlayer(player);
                MoveEnemy(map, player);              
            }
                            
                                
        }

        public void Draw()
        {
            // draws enemy position
            if (isAlive)
            {
                Console.SetCursorPosition(x + 1, y + 1);
            }

            else Console.SetCursorPosition(300, 300);


            xData = x;
            yData = y;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('#');
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void MoveEnemy(Map map, Player player)
        {
            attackUp = false;
            attackDown = false;
            attackRight = false;
            attackLeft = false;
            onEnemy = false;

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
            }
        }

        public void checkIfOnPlayer(Player player)
        {
            if (xData == player.xData && yData == player.yData && attackUp)
            {
                y--;
                Console.Beep();
                player.health -= 1;
                onEnemy = false;
            }

            if (xData == player.xData && yData == player.yData && attackDown)
            {
                y++;
                Console.Beep();
                player.health -= 1;
                onEnemy = false;
            }

            if (xData == player.xData && yData == player.yData && attackLeft)
            {
                x--;
                Console.Beep();
                player.health -= 1;
                onEnemy = false;
            }

            if (xData == player.xData && yData == player.yData && attackRight)
            {
                x++;
                Console.Beep();
                player.health -= 1;
                onEnemy = false;
            }
        }
        private void checkIfDead()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
                xData = 30;
                yData = 30;
            }
        }
    }
}
