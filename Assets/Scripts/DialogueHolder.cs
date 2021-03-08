using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dialogueManager;
    private bool isColliding;

    public string[] dialogueLines;

    public string[] dialogueOptions;

    private BinaryTree dialogueChain;

    private PlayerController player;

    void Start()
    {
        // criar binary tree com arrays dialogueLines e dialogueOptions
        dialogueChain = new BinaryTree(dialogueLines, dialogueOptions);

        // Debug.Log("Dialogue chain has been created");
        // Debug.Log("First dialogue line: " + dialogueChain.Root.Line);

        dialogueManager = FindObjectOfType<DialogueManager>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isColliding)
        {

            player.canMove = false;

            if (!dialogueManager.dialogActive)
            {
                //dialogueManager.dialogueLines = dialogueLines; // passar binarytree em vez de array
                dialogueManager.dialogueChain = dialogueChain;
                //dialogueManager.currentLine = 0;
                dialogueManager.currentNode = dialogueChain.Root;
                dialogueManager.ShowBox();
            }

            // if (transform.parent.GetComponent<StandardNPCMovement>() != null)
            // {
            //     transform.parent.GetComponent<StandardNPCMovement>().canMove = false;
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
