using System;

namespace LostKnightConcept
{
    class InteractableObjectMananger
    {
        public InteractableObject[] interactableObject;

        public int maxObjects;

        bool canSpawn;

        int doorCount;
        int teleporterCount;
        int shopCount;
        int npcCount;

        int doorNum;
        int teleporterNum;
        int npcNum;
        int shopNum;

        public InteractableObjectMananger(Global global, Map map, Player player)
        {
            maxObjects = 8;

            doorNum = 1;
            teleporterNum = 1;
            shopNum = 1;
            npcNum = 1;

            doorCount = 2;
            teleporterCount = doorCount + 2;
            shopCount = teleporterCount + 2;
            npcCount = shopCount + 1;

            int maxNumber = maxObjects - 1;
            interactableObject = new InteractableObject[maxObjects];

            for (int currentObject = 0; currentObject < maxObjects; currentObject++)
            {
                if (currentObject < doorCount) interactableObject[currentObject] = new Door();
                else if (currentObject < teleporterCount) interactableObject[currentObject] = new Teleporter();
                else if (currentObject < shopCount) interactableObject[currentObject] = new Shop(global.rng);
                else if (currentObject < npcCount) interactableObject[currentObject] = new NPC();
                else interactableObject[currentObject] = new TeleporterDestination();

                //Checks if there are any obsticals in the way of spawning
                canSpawn = false;

                while (canSpawn == false)
                {
                    interactableObject[currentObject].x = global.rng.Next(1, map.colume);
                    interactableObject[currentObject].y = global.rng.Next(1, map.row);

                    // Manualy spawn objects
                    if (interactableObject[currentObject].GetType() == typeof(Door))
                    {
                        if (doorNum == 1)
                        {
                            interactableObject[currentObject].x = 21;
                            interactableObject[currentObject].y = 8;
                        }
                        else if (doorNum == 2)
                        {
                            interactableObject[currentObject].x = 64;
                            interactableObject[currentObject].y = 4;
                        }
                        doorNum = doorNum + 1;
                    }

                    if (interactableObject[currentObject].GetType() == typeof(TeleporterDestination))
                    {
                        if (teleporterNum == 1)
                        {
                            interactableObject[currentObject].x = 29;
                            interactableObject[currentObject].y = 8;
                        }

                        else if (teleporterNum == 2)
                        {
                            interactableObject[currentObject].x = 57;
                            interactableObject[currentObject].y = 4;
                        }
                        teleporterNum = teleporterNum + 1;
                    }

                    if (interactableObject[currentObject].GetType() == typeof(Shop))
                    {
                        if (shopNum == 1)
                        {
                            interactableObject[currentObject].x = 23;
                            interactableObject[currentObject].y = 7;
                            shopNum++;
                        }
                    }

                    if (interactableObject[currentObject].GetType() == typeof(Teleporter))
                    {
                        if (teleporterNum == 1)
                        {
                            interactableObject[currentObject].x = 24;
                            interactableObject[currentObject].y = 8;
                        }
                        
                        else if (teleporterNum == 2)
                        {
                            interactableObject[currentObject].x = 59;
                            interactableObject[currentObject].y = 9;
                        }                        
                    }

                    if (interactableObject[currentObject].GetType() == typeof(NPC) || interactableObject[currentObject].GetType() == typeof(Shop))
                    {
                        if (interactableObject[currentObject].y == 9 ||
                            interactableObject[currentObject].y == 13 ||
                            interactableObject[currentObject].y == 15 ||
                            interactableObject[currentObject].y == 5)
                        {
                            interactableObject[currentObject].y++;
                        }

                        if (interactableObject[currentObject].x == 10 ||
                            interactableObject[currentObject].x == 67 ||
                            interactableObject[currentObject].y == 69)
                        {
                            interactableObject[currentObject].x++;
                        }
                    }

                    if ((map.IsMapBounds(interactableObject[currentObject].x, interactableObject[currentObject].y) == false)
                    && map.IsFloor(interactableObject[currentObject].x, interactableObject[currentObject].y)
                    && interactableObject[currentObject].CollideWithPlayer(player, interactableObject[currentObject].x, interactableObject[currentObject].y) == false
                    && interactableObject[currentObject].CollideWithEnemy(interactableObject, interactableObject[currentObject].x, interactableObject[currentObject].y, currentObject) == false)
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
                interactableObject[currentObject].Draw(interactableObject[currentObject].name, render);
            }
        }

        public void Update(Player player)
        {
            for (int currentCollectable = 0; currentCollectable < maxObjects; currentCollectable++)
            {
                interactableObject[currentCollectable].Update(player);
            }
        }
    }
}
