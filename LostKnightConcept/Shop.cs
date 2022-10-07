using System;
using System.Text;

namespace LostKnightConcept 
{
	class Shop:InteractableObject
	{
		public Inventory inventory;
		private int maxItems;
		private int item;
		public bool shopOpen;




		public Shop(Random random)
		{
			inventory = new Inventory();
			maxItems = 4;
			shopOpen = false;

			backColor = ConsoleColor.Black;
			foreColor = ConsoleColor.Yellow;

			name = "Shop";
			graphic = "?";

			PopulateInventory(random);
		}

        public override void Update(Player player)
        {
            if (isActive)
            {
                onInteract(player);
				OpenShop();
            }
        }

		public void OpenShop()
		{
			if (interacted)
			{
				shopOpen = true;
            }
			else
			{
                shopOpen = false;
			}
		}

        public void PopulateInventory(Random random)
        {
			for (int i = 0; i < maxItems; i++)
            {
				item = random.Next(0, 3);
				if (item == 0)
                {
					inventory.addToInventory(new Heart());
                }
				else if (item == 1)
                {
					inventory.addToInventory(new Heart());
                }
				else if (item == 2)
                {
					inventory.addToInventory(new DamageUp());
                }
				else if (item == 3)
                {
					inventory.addToInventory(new Key());
                }

            }

			//Console.SetCursorPosition(0, 55);

			//int k = 0;
			//foreach (Collectable item in inventory.InventoryList)
   //         {
			//	Console.SetCursorPosition(0, 55 +k);
			//	Console.Write(item.name);
			//	k++;
   //         }
			//Console.ReadKey(true);
        }
	}
}


