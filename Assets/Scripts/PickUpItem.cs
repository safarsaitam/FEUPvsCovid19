using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            manager.itemCollected = itemName;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!manager.questCompleted[questNumber] && manager.quests[questNumber].gameObject.activeSelf)
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
