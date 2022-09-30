using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class QuestItem : Collectable
    {
        public string dialoguePrompt;
        public QuestItem(Random random)
        {
            GenerateNewQuestItem(random.Next(0, 4));
            
        }

        private void GenerateNewQuestItem(int outcome)
        {
            switch (outcome) 
            {
                case 0:
                    graphic = "°";
                    name = "Pearl Of Unknowable Power";
                    dialoguePrompt = " a small white pearl.";

                    foreColor = ConsoleColor.White;
                    backColor = ConsoleColor.DarkYellow;
                    break;

                case 1:
                    graphic = "¢";
                    name = "That Guy's Lucky Penny";
                    dialoguePrompt = " my lucky penny.";

                    foreColor = ConsoleColor.DarkRed;
                    backColor = ConsoleColor.DarkYellow;
                    break;

                case 2:
                    graphic = ".";
                    name = "A Small Green Bean";
                    dialoguePrompt = " a magic bean. (Please don't eat it.)";
                    foreColor = ConsoleColor.Green;
                    backColor = ConsoleColor.DarkYellow;
                    break;
            }

        }
    }
}
