using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public QuestObject[] quests;
    public bool[] questCompleted;
    private DialogueManager dialogueManager;

    public string itemCollected;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        questCompleted = new bool[quests.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestText(string questText)
    {
        Node message = new Node();
        message.Line = questText;
        dialogueManager.currentNode = message;
        dialogueManager.ShowBox();

    }
}
