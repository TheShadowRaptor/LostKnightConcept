using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace LostKnightConcept
{
    class MenuManager
    {
        public bool menuOpen;
        public bool paused;
        private bool clearedScreen;
        private string[] pausedMenu;
        
        public MenuManager(string pausedMenuPath)
        {
            menuOpen = false;
            paused = false;
            clearedScreen = true;
            pausedMenu = File.ReadAllLines(pausedMenuPath);
        }

        public void Update(ConsoleKey input)
        {
            CheckInputs(input);
            //CheckBoolStates();
        }

        void CheckInputs(ConsoleKey input)
        {
            if (input == ConsoleKey.Escape)
            {
                if (paused == true)
                {
                    paused = false;
                }
                else
                {
                    paused = true;
                }
            }
            
            if (paused == false && input == ConsoleKey.Tab)
            {
                if (menuOpen == true)
                {
                    menuOpen = false;
                }
                else
                {
                    menuOpen = true;
                }
            }
        }

        void CheckBoolStates()
        {
            if (paused == true)
            {
                if (clearedScreen == true)
                {
                    Console.SetCursorPosition(30, 0);
                    Debug.Write("Screen cleared: " + clearedScreen + "Paused: " + paused + "MenuOpen: " + menuOpen);
                    DrawPause();
                    clearedScreen = false;
                } 
                

            }
            else if (paused == false && menuOpen == false)
            {
                if (clearedScreen == false)
                {
                    Console.Clear();
                    clearedScreen = true;
                    Console.SetCursorPosition(30, 0);
                    Debug.Write(" Screen cleared: " + clearedScreen + " Paused: " + paused + " MenuOpen: " + menuOpen);
                }
            }
        }

        public void DrawPause()
        {
                for (int i = 0; i < (pausedMenu.Length); i++)
                {
                    Console.SetCursorPosition(0, 10 + i);
                    for (int j = 0; j < (pausedMenu[0].Length); j++)
                    {
                        Console.Write(pausedMenu[i][j]);
                    }
                }
            
        }
    }
}
