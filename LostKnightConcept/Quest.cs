using LostKnightConcept;
using System;
using System.Threading;

class Quest
{
	public bool questRecieved;
	private bool questCompleted;
	private bool objectiveCompleted;
    private bool rewardCollected;
    private bool givenReward;

    private int questEnemyIndex;
    private int questItemIndex;
    private int questInteractableIndex;
    private int questNPCIndex;

	public int questType;
	//public string questName;
    public string enemyName;
    public string itemName;

	public string[] dialogue0;
	public string[] dialogue1;
	public string[] dialogue2;

	public Quest(Random random)
	{
		this.questRecieved = false;
		this.questCompleted = false;
		this.objectiveCompleted = false;
        this.rewardCollected = false;
        this.givenReward = false;



        questType = random.Next(0, 2);
	}

	private void DisplayDialogue(MenuManager menuManager)
	{
		switch (questType) 
		{
			case 0:
                if (!questRecieved)
                {
                    if (dialogue0.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue0[0]);
                    }
                    questRecieved = true;
                }
                else if (!objectiveCompleted)
                {
                    if (dialogue0.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue0[1]);
                    }
                }
                else if (objectiveCompleted && !questCompleted)
                {
                    if (dialogue0.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue0[2]);
                        
                    }
                    givenReward = true;
                    questCompleted = true;
                }
                else if (questCompleted)
                {
                    if (dialogue0.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue0[3]);
                    }
                }
                else
                {
                    if (dialogue0.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue0[4]);
                    }
                }
                break;

            case 1:
                if (!questRecieved)
                {
                    if (dialogue1.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue1[0]);
                    }
                    questRecieved = true;
                }
                else if (!objectiveCompleted)
                {
                    if (dialogue1.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue1[1]);
                    }
                }
                else if (objectiveCompleted && !questCompleted)
                {
                    if (dialogue1.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue1[2]);
                    }
                    givenReward = true;
                    questCompleted = true;
                }
                else if (questCompleted)
                {
                    if (dialogue1.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue1[3]);
                    }
                }
                else
                {
                    if (dialogue1.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue1[4]);
                    }
                }
                break;

            case 2:
                if (!questRecieved)
                {
                    if (dialogue2.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue2[0]);
                    }
                    questRecieved = true;
                }
                else if (!objectiveCompleted)
                {
                    if (dialogue2.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue2[1]);
                    }
                }
                else if (objectiveCompleted && !questCompleted)
                {
                    if (dialogue2.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue2[2]);
                    }
                    givenReward = true;
                    questCompleted = true;
                }
                else if (questCompleted)
                {
                    if (dialogue2.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue2[3]);
                    }
                }
                else
                {
                    if (dialogue2.Length != 0)
                    {
                        menuManager.AddToGameLog(dialogue2[4]);
                    }
                }
                break;
		}
	}

    private void UpdateDialogueVariables()
    {
        dialogue0 = new string[] {
        "Hey I've got a job I need done. There's this guy: " + enemyName + ", he needs to die. Why? I don't like him.",
        "Did you kill " + enemyName + " yet? No? Well get to it!",
        "I heard you killed " + enemyName + ". Well done, here's your reward.",
        "Thanks again for offing " + enemyName + "!",
        "You shouldn't be seeing this dialogue."
        };

        dialogue1 = new string[] {
        "Would you mind doing me a favour? I lost something dear to me, it's " + itemName + " Please find it for me.",
        "You haven't found " + itemName + " yet? Would you kindly keep looking for it?",
        "My goodness! You found " + itemName + "! Thank you so very much, please accept this reward!",
        "Thank you friend, I can rest easy now that I have " + itemName,
        "How did you find this dialogue?"
        };

        dialogue2 = new string[] {
        "I've got a request for you stranger. Would you mind opening the door to the shop nearby? It's locked and I really need supplies.",
        "Door's still locked? Shame.",
        "You got that door open? Cheers, thanks friend. Take this for your troubles.",
        "I really needed those supplies, thanks again mate.",
        "This is a secret, not to be seen"
        };
    }

    private void CheckObjectiveCondition(Enemy questEnemy, Collectable questItem, InteractableObject interactableObject, InteractableObject npc)
    {
        switch (questType) 
        {
            case 0:
                if (!questEnemy.IsAlive())
                {
                    objectiveCompleted = true;
                }
                break;

            case 1:
                if (questItem.PickedUp)
                {
                    objectiveCompleted = true;
                }
                break;

            case 2:
                if (!interactableObject.isActive)
                {
                    objectiveCompleted = true;
                }
                break;
        }

    }

    public void Update(Player player, EnemyMananger enemyManager, CollectableManager collectableManager, InteractableObjectMananger interactableObjectManager, MenuManager menuManager, Random questRewardRng)
    {
        GetQuestObjectIndex(enemyManager, collectableManager, interactableObjectManager);
        CheckObjectiveCondition((QuestEnemy)enemyManager.enemy[questEnemyIndex], (QuestItem)collectableManager.collectable[questItemIndex], interactableObjectManager.interactableObject[questInteractableIndex], (NPC)interactableObjectManager.interactableObject[questNPCIndex]);
        interactableObjectManager.interactableObject[questNPCIndex].onInteract(player);
        if (interactableObjectManager.interactableObject[questNPCIndex].interacted)
        {
            DisplayDialogue(menuManager);
        }

        if (!rewardCollected && givenReward)
        {
            player.moneyHeld += questRewardRng.Next(3, 5);
            rewardCollected = true;
        }
    }

    public void GetQuestObjectIndex(EnemyMananger enemyManager, CollectableManager collectableManager, InteractableObjectMananger interactableObjectManager)
    {
        for (int i = 0; i < enemyManager.enemy.Length; i++)
        {
            if (enemyManager.enemy[i].GetType() == typeof(QuestEnemy))
            {
                questEnemyIndex = i;
            }
        }

        for (int i = 0; i < collectableManager.collectable.Length; i++)
        {
            if (collectableManager.collectable[i].GetType() == typeof(QuestItem))
            {
                questItemIndex = i;
            }
        }

        for (int i = 0; i < interactableObjectManager.interactableObject.Length; i++)
        {
            if (interactableObjectManager.interactableObject[i].GetType() == typeof(Door))
            {
                questInteractableIndex = i;
            }

            if (interactableObjectManager.interactableObject[i].GetType() == typeof(NPC))
            {
                questNPCIndex = i;
            }
        }
        //Console.WriteLine("Enemy:" + questEnemyIndex + " Interactable:" + questInteractableIndex + " Item:" + questItemIndex + " NPC:" + questNPCIndex + " Type:" + questType);

        AssignQuestObjectDetails(enemyManager.enemy[questEnemyIndex], (QuestItem)collectableManager.collectable[questItemIndex]);
    }

    private void AssignQuestObjectDetails(Enemy enemy, QuestItem questItem)
    {
        enemyName = enemy.name;
        itemName = questItem.dialoguePrompt;
        UpdateDialogueVariables();
    }


}
