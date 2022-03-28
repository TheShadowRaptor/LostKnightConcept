using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostKnightConcept
{
    class Win
    {

        public int row;
        public int column;
       
        public string[] winWords;

        public Win()
        {
            Global global = new Global();
            
            winWords = File.ReadAllLines(global.winFile);

            row = winWords.Length;
            column = winWords[0].Length;
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
                    Console.Write(winWords[x][y]);

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
            Console.ReadKey(true);
            gameManager.isGameActive = false;
        }
    }
}
