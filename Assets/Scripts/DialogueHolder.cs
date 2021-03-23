using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dialogueManager;
    public bool isColliding;

    public string[] dialogueLines;

    public string[] dialogueOptions;

    public string[] preQuestLines;

    public string[] postQuestLines;

    public string[] afterItemLines;

    private BinaryTree dialogueChain;
    private BinaryTree preDialogueChain;
    private BinaryTree postDialogueChain;
    private BinaryTree afterItemChain;

    public string item;

    private PlayerController player;

    private QuestTrigger triggerQuest;

    private QuestManager questManager;

    void Start()
    {
        // criar binary tree com arrays dialogueLines e dialogueOptions
        dialogueChain = new BinaryTree(dialogueLines, dialogueOptions);
        preDialogueChain = new BinaryTree(preQuestLines, true);
        postDialogueChain = new BinaryTree(postQuestLines, false);
        afterItemChain = new BinaryTree(afterItemLines, true);


        // Debug.Log("Dialogue chain has been created");
        // Debug.Log("First dialogue line: " + dialogueChain.Root.Line);

        dialogueManager = FindObjectOfType<DialogueManager>();
        player = FindObjectOfType<PlayerController>();
        questManager = FindObjectOfType<QuestManager>();

        //triggerQuest = GetComponent<QuestTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isColliding)
        {

            player.canMove = false;

            if (!dialogueManager.dialogActive)
            {
                //dialogueManager.dialogueLines = dialogueLines; // passar binarytree em vez de array

                //dialogueManager.questTrigger = triggerQuest;
                //dialogueManager.currentLine = 0;

                if (preQuestLines.Length == 0)
                {
                    //researcher

                    if (questManager.questCompleted[0])
                    {
                        dialogueManager.dialogueChain = postDialogueChain;

                        dialogueManager.currentNode = postDialogueChain.Root;
                        dialogueManager.ShowBox();
                    }
                    else
                    {
                        dialogueManager.dialogueChain = dialogueChain;

                        dialogueManager.currentNode = dialogueChain.Root;
                        dialogueManager.ShowBox();
                    }

                } //others
                else if (!questManager.quests[0].isActive && !questManager.questCompleted[0])
                {//prequest
                    dialogueManager.dialogueChain = preDialogueChain;

                    dialogueManager.currentNode = preDialogueChain.Root;
                    dialogueManager.ShowBox();
                }
                else if (questManager.quests[0].isActive && !questManager.questCompleted[0])
                {//during quest

                    if (questManager.itemCollected.Contains(item))
                    {//already gave out item
                        dialogueManager.dialogueChain = afterItemChain;

                        dialogueManager.currentNode = afterItemChain.Root;
                        dialogueManager.ShowBox();
                    }
                    else
                    {//hasnt given out item
                        dialogueManager.dialogueChain = dialogueChain;

                        dialogueManager.currentNode = dialogueChain.Root;
                        dialogueManager.ShowBox();
                    }

                }
                else if (!questManager.quests[0].isActive && questManager.questCompleted[0])
                {//after quest
                    dialogueManager.dialogueChain = postDialogueChain;

                    dialogueManager.currentNode = postDialogueChain.Root;
                    dialogueManager.ShowBox();
                }



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
