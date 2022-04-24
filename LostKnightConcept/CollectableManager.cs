using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class CollectableManager
    {

        public int maxCollectables = 5;

        int heartCount;
        int keyCount;

        int keyNum = 1;

        public Collectable[] collectable;

        public Heart heart = new Heart();
        public DamageUp damageUp = new DamageUp();
        public Key key = new Key();

        public CollectableManager(Map map, Player player, Global global)
        {
            heartCount = 2;
            keyCount = heartCount + 2;

            int maxNumber = maxCollectables - 1;
            collectable = new Collectable[maxCollectables];

            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                if (currentCollectable < heartCount) collectable[currentCollectable] = new Heart();
                else if (currentCollectable < keyCount) collectable[currentCollectable] = new Key();
                else collectable[currentCollectable] = new DamageUp();

                //Checks if there are any obsticals in the way of spawning
                bool canSpawn = false;

                while (canSpawn == false)
                {
                    collectable[currentCollectable].x = global.rng.Next(1, /*map.colume*/ 10);
                    collectable[currentCollectable].y = global.rng.Next(1, /*map.row*/ 10);

                    // Manualy spawn items
                    if (collectable[currentCollectable].GetType() == typeof(Key))
                    {                       
                        if (keyNum == 1)
                        {
                            collectable[currentCollectable].x = 10;
                            collectable[currentCollectable].y = 15;
                        }
                        else if (keyNum == 2)
                        {
                            collectable[currentCollectable].x = 10;
                            collectable[currentCollectable].y = 14;
                        }
                        keyNum = keyNum + 1;
                    }

                    if ((map.IsMapBounds(collectable[currentCollectable].x, collectable[currentCollectable].y) == false)
                    && map.IsFloor(collectable[currentCollectable].x, collectable[currentCollectable].y)
                    && collectable[currentCollectable].CollideWithPlayer(player, collectable[currentCollectable].x, collectable[currentCollectable].y) == false
                    && collectable[currentCollectable].CollideWithEnemy(collectable, collectable[currentCollectable].x, collectable[currentCollectable].y, currentCollectable) == false)
                    {
                        canSpawn = true;
                        break;
                    }
                }
            }
        }

        public void Draw(Render render)
        {
            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                collectable[currentCollectable].Draw(collectable[currentCollectable].name, render);
            }
        }

        public void Update(Player player, Map map)
        {
            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                collectable[currentCollectable].Update(player, map);
            }
        }
    }
}

    

