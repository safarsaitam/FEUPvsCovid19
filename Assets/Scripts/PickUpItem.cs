using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour

{
    public int questNumber;
    private QuestManager manager;
    public string itemName;
    private bool inRange;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            manager.AddItem(itemName);
        }
        // Debug.Log("There are " + manager.questCompleted.Length + " and " + manager.quests.Length + " quests.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("There are " + manager.questCompleted.Length + " and " + manager.quests.Length + " quests.");
        if (other.gameObject.name == "Player")
        {
            Debug.Log(manager.quests[questNumber]);
            if (!manager.questCompleted[questNumber] && manager.quests[questNumber].isActive == true)
            {
                inRange = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inRange = false;
        }
    }

    void PickUp()
    {
        gameObject.SetActive(false);
    }


}
