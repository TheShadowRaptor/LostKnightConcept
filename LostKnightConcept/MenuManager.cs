using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;

namespace LostKnightConcept
{
    class MenuManager
    {
        public bool focusMenu;
        public bool inventoryOpen;
        public bool paused;
        public bool shopMenuOpen;
        public bool interactableMenuOpen;
        //public bool affirmAction;
        private int previousSelection;
        private bool clearedScreen;
        private int selection;
        private int activeShop;
        private int itemCost;

        private int inventoryCursorX = 29;
        private int inventoryHeaderX = 30;
        private int inventoryHeaderY = 0;
        private int pauseMenuX = 0;
        private int pauseMenuY = 5;
        private int shopCursorX = 59;
        private int shopItemsX = 60;
        private int shopItemsY = 0;
        private int logHeaderX = 0;
        private int logHeaderY = 29;



        private string[] pausedMenu;
        public List<string> gameLog;
        
        public MenuManager(string pausedMenuPath)
        {
            focusMenu = false;
            inventoryOpen = false;
            shopMenuOpen = false;
            interactableMenuOpen = false;
            paused = false;
            clearedScreen = true;
            pausedMenu = File.ReadAllLines(pausedMenuPath);
            gameLog = new List<string>();
            selection = 0;
        }

        public void Update(ConsoleKey input, Inventory inventory, Player player, InteractableObject[] interactableObjects)
        {
            CheckForOpenShops(interactableObjects);
            CheckInputs(input);
            CallMenus(inventory, player, input, interactableObjects);
            UpdateLog();
        }

        void CheckInputs(ConsoleKey input)
        {
            if (input == ConsoleKey.Escape)
            {
                if (shopMenuOpen == true)
                {
                    shopMenuOpen = false;

                }
                else if (inventoryOpen == true)
                {
                    inventoryOpen = false;
                }
                else
                {
                    paused = !paused;
                }
                
            }
            else if (paused == false && input == ConsoleKey.Tab)
            {
                inventoryOpen = !inventoryOpen;
            }
        }

        void CallMenus(Inventory playerInventory, Player player, ConsoleKey input, InteractableObject[] interactableObjects)
        {
            if (paused == true || inventoryOpen == true || shopMenuOpen == true)
            {
                focusMenu = true;
            }
            else if (paused == false && inventoryOpen == false && shopMenuOpen == false)
            {
                focusMenu = false;
            }

            if (paused == true)
            {
                DrawPause();
                clearedScreen = false;
            }
            else if (inventoryOpen == true)
            {
                NavigateInventory(playerInventory, input, player);
                DrawInventory(playerInventory);
                clearedScreen = false;
            }
            else if (shopMenuOpen == true)
            {
                NavigateShopMenu((Shop)interactableObjects[activeShop], playerInventory, input, player);
                DrawShopMenu((Shop)interactableObjects[activeShop]);
                clearedScreen = false;
            }
            else if (clearedScreen == false)
            {
                if (clearedScreen == false)
                {
                    Console.Clear();
                    clearedScreen = true;
                }
            }
        }

        public void CheckForOpenShops(InteractableObject[] interactableObjects)
        {
            if (focusMenu) return;
            for (int i = 0; i < interactableObjects.Length; i++)
            {
                if (interactableObjects[i].GetType() == typeof(Shop))
                {
                    CheckIfOpen((Shop)interactableObjects[i], i);
                }
            }
        }

        public void DrawPause()
        {
                for (int i = 0; i < (pausedMenu.Length); i++)
                {
                    Console.SetCursorPosition(pauseMenuX, pauseMenuY + i);
                    for (int j = 0; j < (pausedMenu[0].Length); j++)
                    {
                        Console.Write(pausedMenu[i][j]);
                    }
                }
        }

        public void DrawShopMenu(Shop shop)
        {
            int i = 0;
            Console.SetCursorPosition(shopItemsX, shopItemsY);
            Console.Write("========Shop========");
            foreach (Collectable item in shop.inventory.InventoryList)
            {
                Console.SetCursorPosition(shopItemsX, i += 1);
                if (item.GetType() == typeof(DamageUp))
                {
                    itemCost = 3;
                }
                else if (item.GetType() == typeof(Heart))
                {
                    itemCost = 6;
                }
                else if (item.GetType() == typeof(Key))
                {
                    itemCost = 12;
                }

                Console.Write(item.name + " || Cost: " + itemCost.ToString());
            }
        }

        public void NavigateShopMenu(Shop shop, Inventory playerInventory, ConsoleKey input, Player player)
        {
            Console.Clear();
            previousSelection = selection;
            if (paused == false && shopMenuOpen == true)
            {
                if (input == ConsoleKey.W)
                {
                    selection--;
                }
                else if (input == ConsoleKey.S)
                {
                    selection++;
                }
                else if (input == ConsoleKey.Enter)
                {
                    if (shop.inventory.InventoryList.Count != 0)
                    {
                        BuyItem(player, playerInventory, shop);
                    }
                }

                if (selection >= shop.inventory.InventoryList.Count)
                {
                    selection = 0;
                }
                else if (selection < 0)
                {
                    selection = shop.inventory.InventoryList.Count - 1;
                }

                Console.SetCursorPosition(shopCursorX, selection + 1);
                Console.Write(">");
            }
        }

        private bool Affordable(int playerMoney, Collectable itemToBuy)
        {
            if (itemToBuy.GetType() == typeof(DamageUp))
            {
                itemCost = 3;
            }
            else if (itemToBuy.GetType() == typeof(Heart))
            {
                itemCost = 6;
            }
            else if (itemToBuy.GetType() == typeof(Key))
            {
                itemCost = 12;
            }

            if (playerMoney >= itemCost) return true;
            else return false;
        }


        private void CheckIfOpen(Shop shop, int indexInArray)
        {
            if (shop.shopOpen)
            {
                activeShop = indexInArray;
                shopMenuOpen = true;
            }
        }

        private void BuyItem(Player player, Inventory playerInventory, Shop shop)
        {
            if (Affordable(player.moneyHeld, shop.inventory.InventoryList[selection]))
            {
                playerInventory.addToInventory(shop.inventory.InventoryList[selection]);
                shop.inventory.removeFromInventory(shop.inventory.InventoryList[selection]);
                player.moneyHeld -= itemCost;
                Console.Beep(500, 200);
            }
        }

        public void AddToGameLog(string message)
        {
            gameLog.Insert(0,message);
            Console.Clear();
            UpdateLog();
        }
        
        public void UpdateLog()
        {
            int i = 0;
            Console.SetCursorPosition(logHeaderX, logHeaderY);
            Console.WriteLine("++++Log++++");
            foreach (string message in gameLog)
            {
                Console.SetCursorPosition(logHeaderX, logHeaderY + 1 + i);
                Console.WriteLine(message);
                Console.WriteLine();
                i++;
            }
        }

        public void DrawInventory(Inventory inventory)
        {
            int i = 0;
            Console.SetCursorPosition(inventoryHeaderX, inventoryHeaderY);
            Console.Write("++++++++Inventory++++++++");
            foreach (Collectable item in inventory.InventoryList)
            {
                Console.SetCursorPosition(inventoryHeaderX, i += 1);
                Console.Write(item.name);
            }
        }

        public void NavigateInventory(Inventory inventory, ConsoleKey input, Player player)
        {
            Console.Clear();
            previousSelection = selection;
            if (paused == false && inventoryOpen == true)
            {
                if (input == ConsoleKey.W)
                {
                    selection--;
                }
                else if (input == ConsoleKey.S)
                {
                    selection++;
                }
                else if (input == ConsoleKey.Enter)
                {
                    if (inventory.InventoryList.Count != 0)
                    {
                        if (inventory.InventoryList[selection].GetType() == typeof(QuestItem)) return;
                        player.ApplyItemEffect(inventory.InventoryList[selection]);
                        inventory.removeFromInventory(inventory.InventoryList[selection]);
                        Console.Beep(500,200);
                    }
                }

                if (selection >= inventory.InventoryList.Count)
                {
                    selection = 0;
                }
                else if (selection < 0)
                {
                    selection = inventory.InventoryList.Count - 1;
                }

                Console.SetCursorPosition(inventoryCursorX, selection + 1);
                Console.Write(">");
                
            }
        }
    }
}
