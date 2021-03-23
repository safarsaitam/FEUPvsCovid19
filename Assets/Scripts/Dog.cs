using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public QuestManager manager;
    public GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.questCompleted[1] == true)
        {
            if (gameObject.name == "Dog")
            {
                gameObject.SetActive(false);
                dog.SetActive(true);
            }

            if (gameObject.name == "Dog 2")
            {
                gameObject.SetActive(true);
            }
        }
    }
}
