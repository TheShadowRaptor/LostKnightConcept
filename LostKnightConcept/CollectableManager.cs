using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class CollectableManager
    {
        public int maxCollectables;

        bool canSpawn;

        int heartCount;
        int keyCount;
        int moneyCount;
        int questItemCount;

        int keyNum;

        public Collectable[] collectable;

        public Money money = new Money();
        public Heart heart = new Heart();
        public DamageUp damageUp = new DamageUp();
        public Key key = new Key();

        public CollectableManager(Map map, Player player, Global global)
        {
            maxCollectables = 27;
            heartCount = 2;
            keyCount = heartCount + 2;
            questItemCount = moneyCount + 1;
            moneyCount = keyCount + 20;


            keyNum = 1;

            int maxNumber = maxCollectables - 1;
            collectable = new Collectable[maxCollectables];

            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                if (currentCollectable < heartCount) collectable[currentCollectable] = new Heart();
                else if (currentCollectable < keyCount) collectable[currentCollectable] = new Key();
                else if (currentCollectable < moneyCount) collectable[currentCollectable] = new Money();
                else if (currentCollectable == 26) collectable[currentCollectable] = new QuestItem(global.rng);
                else collectable[currentCollectable] = new DamageUp();

                //Checks if there are any obsticals in the way of spawning
                canSpawn = false;

                while (canSpawn == false)
                {
                    collectable[currentCollectable].x = global.rng.Next(1, map.colume);
                    collectable[currentCollectable].y = global.rng.Next(1, map.row);

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
                            collectable[currentCollectable].x = 67;
                            collectable[currentCollectable].y = 9;
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

        public void Draw(Render render, bool questStarted, int questType)
        {

            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                if (collectable[currentCollectable].GetType() == typeof(QuestItem))
                {
                    if (questStarted && questType == 1) collectable[currentCollectable].Draw(collectable[currentCollectable].name, render);
                }
                else
                {
                    collectable[currentCollectable].Draw(collectable[currentCollectable].name, render);
                } 
            }
        }

        public void Update(Player player, Map map, Inventory inventory, bool questStarted, int questType)
        {
            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                if (collectable[currentCollectable].GetType() == typeof(QuestItem))
                {
                    if (questStarted && questType == 1) collectable[currentCollectable].Update(player, map);
                }
                else
                {
                    collectable[currentCollectable].Update(player, map);
                }
            }

            for (int currentCollectable = 0; currentCollectable < maxCollectables; currentCollectable++)
            {
                if (collectable[currentCollectable].isActive == false && collectable[currentCollectable].PickedUp == false)
                {
                    if (collectable[currentCollectable].GetType() == typeof(Key) || collectable[currentCollectable].GetType() == typeof(Money)) continue;
                    inventory.addToInventory(collectable[currentCollectable]);
                    collectable[currentCollectable].PickedUp = true;
                }
            }
        }
    }
}

    

