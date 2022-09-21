using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostKnightConcept
{
    class MenuManager
    {
        public bool focusMenu;
        public bool inventoryOpen;
        public bool paused;
        //public bool affirmAction;
        private int previousSelection;
        private bool clearedScreen;
        private int selection;
        private string[] pausedMenu;
        
        public MenuManager(string pausedMenuPath)
        {
            focusMenu = false;
            inventoryOpen = false;
            paused = false;
            clearedScreen = true;
            pausedMenu = File.ReadAllLines(pausedMenuPath);
            selection = 0;
        }

        public void Update(ConsoleKey input, Inventory inventory, Player player)
        {
            CheckInputs(input);
            CallMenus(inventory, player, input);
        }

        void CheckInputs(ConsoleKey input)
        {
            if (input == ConsoleKey.Escape)
            {
                paused = !paused;
            }
            else if (paused == false && input == ConsoleKey.Tab)
            {
                inventoryOpen = !inventoryOpen;
            }
        }

        void CallMenus(Inventory inventory, Player player, ConsoleKey input)
        {
            if (paused == true || inventoryOpen == true)
            {
                focusMenu = true;
            }
            else if (paused == false && inventoryOpen == false)
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
                NavigateInventory(inventory, input, player);
                DrawInventory(inventory);
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

        public void DrawPause()
        {
                for (int i = 0; i < (pausedMenu.Length); i++)
                {
                    // Values are going to be hard coded until I find a spot I like, then I'll move them to global
                    Console.SetCursorPosition(0, 5 + i);
                    for (int j = 0; j < (pausedMenu[0].Length); j++)
                    {
                        Console.Write(pausedMenu[i][j]);
                    }
                }
        }

        public void DrawInventory(Inventory inventory)
        {
            // Values are going to be hard coded until I find a spot I like, then I'll move them to global
            int i = 0;
            Console.SetCursorPosition(30, 0);
            Console.Write("++++++++Inventory++++++++");
            foreach (Collectable item in inventory.InventoryList)
            {
                Console.SetCursorPosition(30, i += 1);
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

                Console.SetCursorPosition(29, selection + 1);
                Console.Write(">");
                
            }
        }
    }
}
