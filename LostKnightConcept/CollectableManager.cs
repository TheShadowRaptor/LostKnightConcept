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

        int heartCount = 2;

        public Collectable[] collectable;

        public Heart heart = new Heart();
        public DamageUp damageUp = new DamageUp();
        public Key key = new Key();

        public CollectableManager(Map map, Player player, Global global)
        {
            int maxNumber = maxCollectables - 1;
            collectable = new Collectable[maxCollectables];

            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                if (currentCollectable < heartCount) collectable[currentCollectable] = new Heart();
                else if (currentCollectable == maxNumber) collectable[currentCollectable] = new Key();
                else collectable[currentCollectable] = new DamageUp();

                //Checks if there are any obsticals in the way of spawning
                bool canSpawn = false;

                while (canSpawn == false)
                {
                    collectable[currentCollectable].x = global.rng.Next(1, /*map.colume*/ 10);
                    collectable[currentCollectable].y = global.rng.Next(1, /*map.row*/ 10);

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

    

