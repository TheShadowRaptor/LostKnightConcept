using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class InteractableObject
    {
        protected string graphic;

        protected ConsoleColor backColor;
        protected ConsoleColor foreColor;

        public bool interacted;

        public string name;

        public int x;
        public int y;

        public int xData;
        public int yData;

        public bool isActive;   
        
        //for teleporter
        public int destinationX;
        public int destinationY;

        public InteractableObject()
        {
            isActive = true;
            interacted = false;
        }
        public virtual void Update(Player player)
        {
            if (isActive)
            {
                onInteract(player);
            }
        }

        public void Draw(string name, Render render)
        {
            if (isActive)
            {
                render.Draw(x, y, graphic, foreColor, backColor);
            }
        }

        public void onInteract(Player player)
        {
            xData = x;
            yData = y;

            // Looks for interaction
            if (player.xData == xData && player.yData == yData)
            {
                interacted = true;
            }

            else
            {
                interacted = false;
            }
        }

        public bool CollideWithPlayer(Player player, int x, int y)
        {
            xData = x;
            yData = y;

            if (xData == player.xData && yData == player.yData)
            {
                return true;
            }
            return false;
        }

        public bool CollideWithEnemy(InteractableObject[] interactableObject, int x, int y, int currentObject)
        {
            xData = x;
            yData = y;

            if (xData == interactableObject[currentObject].xData && yData == interactableObject[currentObject].yData && interactableObject[currentObject] != this)
            {
                return true;
            }

            return false;
        }
    }
}
