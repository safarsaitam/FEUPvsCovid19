using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrigger : MonoBehaviour
{

    public bool isColliding;
    public Image[] icons;
    public Image[] checks;

    private static bool initialized;

    void Start()
    {
        if (!initialized)
        {
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].enabled = false;
            }
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].enabled = false;
            }

            initialized = true;
        }
    }

    void Update()
    {
        
    }

    public void activateIcons()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].enabled = true;
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
