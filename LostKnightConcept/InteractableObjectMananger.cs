using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class InteractableObjectMananger
    {
        public InteractableObject[] interactablebObject;

        public int maxObjects;

        int doorCount;

        int doorNum;

        public InteractableObjectMananger(Global global, Map map, Player player)
        {
            maxObjects = 3;

            doorNum = 1;
            doorCount = 2;

            int maxNumber = maxObjects - 1;
            interactablebObject = new InteractableObject[maxObjects];

            for (int currentObject = 0; currentObject < maxObjects; currentObject++)
            {
                if (currentObject < doorCount) interactablebObject[currentObject] = new Door();
                else interactablebObject[currentObject] = new Teleporter();

                //Checks if there are any obsticals in the way of spawning
                bool canSpawn = false;

                while (canSpawn == false)
                {
                    interactablebObject[currentObject].x = global.rng.Next(1, map.colume);
                    interactablebObject[currentObject].y = global.rng.Next(1, map.row);

                    // Manualy spawn objects
                    if (interactablebObject[currentObject].GetType() == typeof(Door))
                    {
                        if (doorNum == 1)
                        {
                            interactablebObject[currentObject].x = 21;
                            interactablebObject[currentObject].y = 8;
                        }
                        else if (doorNum == 2)
                        {
                            interactablebObject[currentObject].x = 64;
                            interactablebObject[currentObject].y = 4;
                        }
                        doorNum = doorNum + 1;
                    }

                    if (interactablebObject[currentObject].GetType() == typeof(Teleporter))
                    {
                        interactablebObject[currentObject].x = 24;
                        interactablebObject[currentObject].y = 8;
                    }

                    if ((map.IsMapBounds(interactablebObject[currentObject].x, interactablebObject[currentObject].y) == false)
                    && map.IsFloor(interactablebObject[currentObject].x, interactablebObject[currentObject].y)
                    && interactablebObject[currentObject].CollideWithPlayer(player, interactablebObject[currentObject].x, interactablebObject[currentObject].y) == false
                    && interactablebObject[currentObject].CollideWithEnemy(interactablebObject, interactablebObject[currentObject].x, interactablebObject[currentObject].y, currentObject) == false)
                    {
                        canSpawn = true;
                        break;
                    }
                }
            }
        }

        public void Draw(Render render)
        {
            for (int currentObject = 0; currentObject < maxObjects; currentObject++)
            {
                interactablebObject[currentObject].Draw(interactablebObject[currentObject].name, render);
            }
        }

        public void Update(Player player, Map map)
        {
            for (int currentCollectable = 0; currentCollectable < maxObjects; currentCollectable++)
            {
                interactablebObject[currentCollectable].Update(player);
            }
        }
    }
}
