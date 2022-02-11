using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Player : Character
    {
        // fields
        private const int startPositionX = 1;
        private const int startPositionY = 1;

        public Player()
        {
            // instatiation
            health = 1;

            x = startPositionX;
            y = startPositionY;

            name = "Guille";
        }

        public void Update(Enemy enemy, Map map)
        {
            CheckIfDead();
            
            if(isAlive)
            {
                Draw();
                checkIfOnEnemy(enemy);
                MovePlayer(map, enemy);
            }
                           
                
        }

        public void Draw()
        {          
            // draws player position
            Console.SetCursorPosition(x + 1, y + 1);

            xData = x;
            yData = y;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('+');
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void MovePlayer(Map map, Enemy enemy)
        {
            attackUp = false;
            attackDown = false;
            attackRight = false;
            attackLeft = false;
            onEnemy = false;           

            // moves player with button input
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.W)
            {
                // move up
                y--;
                attackUp = true;

                if(map.IsWall(x, y) == true)
                {
                    y++;
                    
                    map.boundsHit = false;
                }               
            }

            if (input.Key == ConsoleKey.A)
            {
                //move left
                x--;
                attackLeft = true;
                if(map.IsWall(x, y) == true)
                {
                    x++;
                    map.boundsHit = false;
                }
            }

            if (input.Key == ConsoleKey.D)
            {
                //move right
                x++;
                attackRight = true;
                if(map.IsWall(x, y) == true)
                {
                    x--;
                    map.boundsHit = false;
                }             
            }

            if (input.Key == ConsoleKey.S)
            {
                //move down
                y++;
                attackDown = true;
                if (map.IsWall(x, y) == true)
                {
                    y--;
                    map.boundsHit = false;
                }
            }          
        }
        public void checkIfOnEnemy(Enemy enemy)
        {           
            if (xData == enemy.xData && yData == enemy.yData && attackUp)
            {           
                y--;
                Console.Beep();
                enemy.health -= 1;
                onEnemy = false;           
            }

            if (xData == enemy.xData && yData == enemy.yData && attackDown)
            {
                y++;
                Console.Beep();
                enemy.health -= 1;
                onEnemy = false;
            }

            if (xData == enemy.xData && yData == enemy.yData && attackLeft)
            {
                x--;
                Console.Beep();
                enemy.health -= 1;
                onEnemy = false;
            }

            if (xData == enemy.xData && yData == enemy.yData && attackRight)
            {
                x++;
                Console.Beep();
                enemy.health -= 1;
                onEnemy = false;
            }
        }
        private void CheckIfDead()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
            }
        }
    }  
}
