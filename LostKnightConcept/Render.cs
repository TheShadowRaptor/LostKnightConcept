using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Render
    {
        public Camera camera;
        public Render(Camera camera)
        {
            this.camera = camera;
        }
        public void Draw(int x, int y, string character, ConsoleColor foreGroundColor, ConsoleColor backGroundColor)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.ForegroundColor = foreGroundColor;
            Console.BackgroundColor = backGroundColor;
            Console.Write(character);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        public void MapDraw(int worldX, int worldY, char character)
        {            

            // scroll camera
            int screenX = worldX + 1;
            int screenY = worldY + 1;

            // range checking for on-screen coords
            /*if (screenX > Console.WindowWidth / 2) return;
            if (screenY > Console.WindowHeight / 2) return;*/
            if (screenX < 0) return;
            if (screenY < 0) return;

            Console.SetCursorPosition(worldX + 1, worldY + 1);
            Console.Write(character);
        }
    }
}
