using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dialogueManager;
    private bool isColliding;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isColliding)
        {
            if (!dialogueManager.dialogActive)
            {
                // dMan.dialogueLines = dialogueLines;
                // dMan.currentLine = 0;
                // dMan.ShowDialogue();
                dialogueManager.ShowBox(dialogue);
            }

            // if (transform.parent.GetComponent<VillagerMovement>() != null)
            // {
            //     transform.parent.GetComponent<VillagerMovement>().canMove = false;
            // }
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
