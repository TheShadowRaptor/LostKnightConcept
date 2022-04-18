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
        public Global global;

        int screenX;
        int screenY;

        public Render(Camera camera, Global global)
        {
            this.camera = camera;
            this.global = global;
        }
        public void Draw(int x, int y, string character, ConsoleColor foreGroundColor, ConsoleColor backGroundColor)
        {
            int posX = x - camera.offsetY + 1;
            int posY = y - camera.offsetX + 1;

            if(posX < screenX + 1 && posX > 0 && posY < screenY + 1 && posY > 0)
            {
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = foreGroundColor;
                Console.BackgroundColor = backGroundColor;
                Console.Write(character);
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
            }
        }

        public void MapDraw(int worldX, int worldY, char character)
        {            

            // scroll camera
            screenX = worldX;
            screenY = worldY;

            // range checking for on-screen coords
            /*if (screenX > Console.WindowWidth) return;
            if (screenY > Console.WindowHeight) return;
            if (screenX < 0) return;
            if (screenY < 0) return;
*/
            Console.SetCursorPosition(screenX + 1, screenY + 1);
            Console.Write(character);
        }

        public void CheckCameraScroll(Map map)
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
