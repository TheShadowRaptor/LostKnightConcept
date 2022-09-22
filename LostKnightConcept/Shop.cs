using System;

namespace LostKnightConcept 
{
	class Shop:InteractableObject
	{
		public Inventory inventory;
		private int maxItems;
		private int item;
		private Random itemRNG;




		public Shop()
		{
			inventory = new Inventory();
			maxItems = 4;
			itemRNG = new Random();

			backColor = ConsoleColor.Black;
			foreColor = ConsoleColor.Yellow;

			name = "Shop";
			graphic = "?";
		}

		public void PopulateInventory()
        {
			for (int i = 0; i < maxItems; i++)
            {
				item = itemRNG.Next(0, 3);
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
        }
	}
}


