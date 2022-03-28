using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostKnightConcept
{
    class Gameover
    {

        public int row;
        public int column;

        public string gameoverFile = "Gameover.txt";
        public string[] gameoverWords;

        public Gameover()
        {
            gameoverWords = File.ReadAllLines(gameoverFile);

            row = gameoverWords.Length;
            column = gameoverWords[0].Length;
        }

        public void Draw()
        {
            // Erase everything before gameover screen
            Console.Clear();

            // Draws gameover
            for (int x = 0; x < row; x++)
            {
                Console.Write("");

                for (int y = 0; y < column; y++)
                {
                    // Draws gameover
                    Console.Write(gameoverWords[x][y]);

                }
                Console.WriteLine("");
            }

        }

        public void Update(GameManager gameManager)
        {
            Input(gameManager);
        }

        private void Input(GameManager gameManager)
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            while (true)
            {
                if (input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Spacebar)
                {
                    gameManager.isGameActive = false;
                    break;
                }
            }
        }
    }
}
