using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LostKnightConcept 
{
	class Inventory
	{
		public List<Collectable> InventoryList;
		public Inventory()
		{
			InventoryList = new List<Collectable>();
		}

		public void addToInventory(Collectable toBeAdded)
        {
			InventoryList.Add(toBeAdded);
        }

		public void removeFromInventory(Collectable toBeRemoved)
        {
			InventoryList.Remove(toBeRemoved);
        }

		public void useItem(Collectable toBeUsed)
        {
			
        }
	}
}


