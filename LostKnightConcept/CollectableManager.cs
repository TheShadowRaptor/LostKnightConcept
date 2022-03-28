using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class CollectableManager
    {
        public Heart heart = new Heart();
        public DamageUp damageUp = new DamageUp();
        public Key key = new Key();

        public void DrawCollectables()
        {
            key.Draw();
            heart.Draw();
            damageUp.Draw();
        }

        public void UpdateCollectables(Player player)
        {
            key.Update(player);
            heart.Update(player);
            damageUp.Update(player);
        }
    }
}
