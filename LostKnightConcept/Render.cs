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
            Console.SetCursorPosition(x - camera.offsetY + 1, y - camera.offsetX + 1);
            Console.ForegroundColor = foreGroundColor;
            Console.BackgroundColor = backGroundColor;
            Console.Write(character);
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        public void MapDraw(int worldX, int worldY, char character)
        {            

            // scroll camera
            int screenX = worldX;
            int screenY = worldY;

            // range checking for on-screen coords
            /*if (screenX > Console.WindowWidth) return;
            if (screenY > Console.WindowHeight) return;
            if (screenX < 0) return;
            if (screenY < 0) return;
*/
            Console.SetCursorPosition(screenX + 1, screenY + 1);
            Console.Write(character);
        }

        public void CheckCameraScroll(Map map, Global global)
        {
            if ((map.CheckCameraBoundX(camera.preOffSetX, global) == false))
            {
                camera.offsetX = camera.preOffSetX;
            }

            if ((map.CheckCameraBoundY(camera.preOffSetY, global) == false))
            {
                camera.offsetY = camera.preOffSetY;

            }
        }
    }
}
