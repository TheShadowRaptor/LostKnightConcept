using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class QuestEnemy : Enemy
    {
        int enemyType;
        bool moveTwice;
        string output;
        public QuestEnemy(Random random)
        {
            name = GenerateName(random);
            graphic = "B";
            health = 5;
            damage = 2;
            foreColor = ConsoleColor.Red;
            backColor = ConsoleColor.DarkRed;
            maxHealth = health;

            enemyType = random.Next(0, 2);
        }

        public override void Move(Map map, Player player, Render render, Enemy[] enemy, InteractableObject[] interactableObject, int maxEnemies, int maxObjects, Global global)
        {

            if (enemyType == 0)
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
                    && map.GhostBounds(preMoveX, preMoveY) == false
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
            else if (enemyType == 1)
            {
                // moves enemy with randomizer
                int direction;
                int wait;
                bool passedTwice = false;

                moveTwice = true;
                while (moveTwice)
                {
                    // checks if enemy can move
                    preMoveX = x;
                    preMoveY = y;

                    direction = global.rng.Next(0, 4);
                    wait = global.rng.Next(0, 2);


                    if (wait == 1)
                    {
                        if (direction == 0)
                        {
                            preMoveX--;
                        }

                        else if (direction == 1)
                        {
                            preMoveX++;
                        }

                        else if (direction == 2)
                        {
                            preMoveY--;
                        }

                        else if (direction == 3)
                        {
                            preMoveY++;
                        }
                    }

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

                    if (passedTwice)
                    {
                        moveTwice = false;
                    }

                    passedTwice = true;
                }

                // Updates enemies position
                xData = x;
                yData = y;
            }
            else if (enemyType == 2)
            {
                // checks if enemy can move
                preMoveY = y;
                preMoveX = x;

                // moves enemy with randomizer
                int direction;
                int wait;

                direction = global.rng.Next(0, 2);
                wait = global.rng.Next(0, 2);

                if (wait == 1)
                {
                    if (direction == 0)
                    {
                        preMoveX--;
                    }

                    else if (direction == 1)
                    {
                        preMoveX++;
                    }
                }

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

                // Updates enemies position
                xData = x;
                yData = y;
            }
        }

        private string GenerateName(Random random)
        {
            switch (random.Next(0, 4)) 
            {
                case 0:
                    output = "El Flexador";
                    break;

                case 1:
                    output = "Barry... just Barry";
                    break;

                case 2:
                    output = "Turboevil Malevolator";
                    break;

                case 3:
                    output = "The Lord of Slightly Pointy Things";
                    break;

                case 4:
                    output = "F. J. Glittersparkles";
                    break;
            }
            return output;
        }
    }
}

