using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour
{

    public int number;
    public QuestManager manager;
    public string startText;
    public string endText;

    public bool isItemQuest;
    public List<string> items = new List<string>();
    public bool isActive;

    private int counter = 0;

    void Start()
    {
    }

    void Update()
    {
        if (isItemQuest && isActive)
        {
            foreach (string item in items)
            {
                if (!manager.itemCollected.Contains(item))
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                EndQuest();
            }
        }
        counter = 0;
    }

    public void StartQuest()
    {
        isActive = true;
        gameObject.SetActive(true);
        manager.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        manager.ShowQuestText(endText);
        manager.questCompleted[number] = true;
        isActive = false;
        gameObject.SetActive(false);

    }
}
