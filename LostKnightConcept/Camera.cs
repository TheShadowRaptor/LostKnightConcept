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

        public void Update(Player player)
        {
            y = player.x;
            x = player.y;
        }
    }
}
