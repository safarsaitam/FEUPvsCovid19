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
    public string item;
    public Image checkIcon;

    void Start()
    {
        
    }

    void Update()
    {
        if (isItemQuest)
        {
            if(manager.itemCollected == item)
            {
                manager.itemCollected = null;
                EndQuest();
                checkIcon.enabled = true;
            }
        }
    }

    public void StartQuest()
    {
        manager.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        manager.ShowQuestText(endText);
        manager.questCompleted[number] = true;
        gameObject.SetActive(false);

    }
}
