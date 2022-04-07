using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Camera
    {
        public int x;
        public int y;

        public int xstart = 12;
        public int Ystart = 12;

        public void Update(Player player)
        {
            y = player.OffsetX;
            x = player.OffsetY;
        }
    }
}
