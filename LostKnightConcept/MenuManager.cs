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
        private bool clearedScreen;
        private string[] pausedMenu;
        
        public MenuManager(string pausedMenuPath)
        {
            focusMenu = false;
            inventoryOpen = false;
            paused = false;
            clearedScreen = true;
            pausedMenu = File.ReadAllLines(pausedMenuPath);
        }

        public void Update(ConsoleKey input, Inventory inventory)
        {
            CheckInputs(input);
            CheckBoolStates(inventory);
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

        void CheckBoolStates(Inventory inventory)
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
                DrawInventory(inventory);
                clearedScreen = false;
            }
            else if (paused == false && inventoryOpen == false)
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
                    Console.SetCursorPosition(0, 10 + i);
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
                Console.SetCursorPosition(30, i + 1);
                Console.Write(item.name);
            }
        }
    }
}
