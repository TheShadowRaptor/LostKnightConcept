namespace LostKnightConcept
{
    class InteractableObjectMananger
    {
        public InteractableObject[] interactableObject;

        public int maxObjects;

        int doorCount;

        int doorNum;

        public InteractableObjectMananger(Global global, Map map, Player player)
        {
            maxObjects = 3;

            doorNum = 1;
            doorCount = 2;

            int maxNumber = maxObjects - 1;
            interactableObject = new InteractableObject[maxObjects];

            for (int currentObject = 0; currentObject < maxObjects; currentObject++)
            {
                if (currentObject < doorCount) interactableObject[currentObject] = new Door();
                else interactableObject[currentObject] = new Teleporter();

                //Checks if there are any obsticals in the way of spawning
                bool canSpawn = false;

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

                    if (interactableObject[currentObject].GetType() == typeof(Teleporter))
                    {
                        interactableObject[currentObject].x = 24;
                        interactableObject[currentObject].y = 8;
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

        public void Update(Player player, Map map)
        {
            for (int currentCollectable = 0; currentCollectable < maxObjects; currentCollectable++)
            {
                interactableObject[currentCollectable].Update(player);
            }
        }
    }
}
