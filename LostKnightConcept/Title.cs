using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostKnightConcept
{
    class Title
    {
        private int choice;

        public int row;
        public int column;

        private const int choiceOne = 0;
        private const int choiceTwo = 1;

        public string titleFile = "Title.txt";
        public string[] title;

        public bool isActive = true;

        public Title()
        {
            title = File.ReadAllLines(titleFile);

            row = title.Length;
            column = title[0].Length;
        }

        public void Draw(Player player)
        {
            Console.WriteLine(player.IsAlive());
            // Draws Title
            for (int x = 0; x < row; x++)
            {
                Console.Write("");

                for (int y = 0; y < column; y++)
                {
                    // draws title
                    Console.Write(title[x][y]);

                }
                Console.WriteLine("");
            }
            
            if (choice == 0)
            {
                Console.WriteLine("->Start");
            }
            else Console.WriteLine("Start  ");

            if (choice == 1)
            {
                Console.WriteLine("->Exit");
            }
            else Console.WriteLine("Exit  ");

            Console.WriteLine("");
            Console.WriteLine("Controls");
            Console.WriteLine("W/▲ = Up");
            Console.WriteLine("S/▼ = Down");
            Console.WriteLine("A/◄ = Left");
            Console.WriteLine("D/► = Right");
            Console.WriteLine("Enter/Space = Select");

            Console.CursorVisible = false;
        }
        // ===========================================

        public void Update(GameManager gameManager)
        {
            Input(gameManager);
        }

        private void Input(GameManager gameManager)
        {
            while (isActive == true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
                {
                    choice -= 1;
                }

                else if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
                {
                    choice += 1;
                }

                if (input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Spacebar)
                {
                    //Start Game
                    if (choice == choiceOne)
                    {
                        gameManager.isGameActive = true;
                        isActive = false;
                        Console.Clear();
                        break;
                    }

                    //Exit Game
                    if (choice == choiceTwo)
                    {
                        gameManager.isGameActive = false;
                        isActive = false;
                        Console.Clear();
                        break;
                    }
                }

                if (choice < choiceOne)
                {
                    choice = choiceOne;
                }

                if (choice > choiceTwo)
                {
                    choice = choiceTwo;
                }

                // resets cursor
                Console.SetCursorPosition(0, 0);

                break;
            }
        }
    }
}
