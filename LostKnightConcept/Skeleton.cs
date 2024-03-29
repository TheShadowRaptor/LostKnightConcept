﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Skeleton : Enemy
    {
        private Random rng = new Random();

        public Skeleton()
        {
            name = "Skeleton";
            graphic = "S";
            health = 2;
            damage = 1;
            foreColor = ConsoleColor.Gray;
            backColor = ConsoleColor.White;
        }

        public override void Move(Map map, Player player, Render render, Enemy[] enemy, InteractableObject[] interactableObject, int maxEnemies, int maxObjects, Global global)
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
}
