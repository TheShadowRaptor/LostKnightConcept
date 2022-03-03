using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class Collectables : GameCharacter
    {
        protected bool PickedUp;

        public Collectables()
        {
            
        }

        protected void ItemPickedUp(Player player, int xData, int yData)
        {
            if (player.xData == xData && player.yData == yData)
            {
                PickedUp = true;
            }
        }
    }
}
