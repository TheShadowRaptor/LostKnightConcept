using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LostKnightConcept
{
    class EnemyClass : GameCharacter
    {
        // fields
        private const int startPosX = 5;
        private const int startPosY = 2;

        public char enemyGraphic;
        public EnemyClass()
        {
            // instatiation
            x = startPosX;
            y = startPosY;

            rng = new Random();            

            hit.SoundLocation = "Hit_Player.wav";
        }

        public void Update(Player player, Map map)
        {
            CheckIfDead();

            if (isAlive == true)
            {
                Draw();
                Move(map, player);
            }
            else
            {
                xData = map.mapData.GetLength(0) + 1;
                yData = map.mapData.GetLength(1) + 1;
            }
        }

        private void Draw()
        {
            // draws enemy position
            if (isAlive)
            {
                Console.SetCursorPosition(x + 1, y + 1);
            }

            else Console.SetCursorPosition(300, 300);

            DrawChar(charGraphic, backColor, foreColor);

            Console.CursorVisible = false;
        }
        public bool IsOnPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == player.xData && yData == player.yData)
            {
                PlaySoundHitPlayer();
                player.health -= 1;
                return true;
            }
            return false;
        }
        private void PlaySoundHitPlayer()
        {
            hit.Load();
            hit.Play();
        }
        
    }
}
