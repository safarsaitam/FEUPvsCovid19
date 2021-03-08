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
    public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isItemQuest)
        {
            if(manager.itemCollected == item)
            {
                manager.itemCollected = null;
                EndQuest();
                icon.enabled = false;
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
