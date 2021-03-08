using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrigger : MonoBehaviour
{

    public bool isColliding;
    public Image[] icons;

    private static bool initialized;

    void Start()
    {
        if (!initialized)
        {
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].enabled = false;
            }

            initialized = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isColliding)
        {

            Debug.Log("activating");
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].enabled = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            isColliding = false;
        }
    }
}
