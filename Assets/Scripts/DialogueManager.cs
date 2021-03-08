using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public Text OptionOne;
    public Text OptionTwo;

    public Image pointer;
    public Image enter;

    public bool dialogActive;

    //public string[] dialogueLines;
    public BinaryTree dialogueChain;
    //public int currentLine;
    public Node currentNode;

    private bool onOptionOne;


    void Start()
    {
        onOptionOne = true;
    }

    void Update()
    {

        pointer.enabled = true;
        enter.enabled = false;

        if (currentNode != null && currentNode.RightNode != null)
        {// there are more children nodes aka dialogue lines



            if (dialogActive && (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)))
            {
                if (onOptionOne)
                {
                    pointer.rectTransform.anchoredPosition = new Vector2(5, pointer.rectTransform.anchoredPosition.y);
                    onOptionOne = false;
                }
                else
                {
                    pointer.rectTransform.anchoredPosition = new Vector2(-46, pointer.rectTransform.anchoredPosition.y);
                    onOptionOne = true;
                }
            }

            if (dialogActive && Input.GetKeyDown(KeyCode.Return))
            {

                // if yes move to left node
                // if no move to right node
                if (onOptionOne)
                {
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                }

            }

        }
        else
        {
            pointer.enabled = false;
            enter.enabled = true;

            if (currentNode != null && currentNode.LeftNode == null && dialogActive && Input.GetKeyDown(KeyCode.Return))
            {
                dBox.SetActive(false);
                dialogActive = false;
            }

        }

        /*if (currentLine >= dialogueLines.Length)
        {
            

            currentLine = 0;

            // thePlayer.canMove = true;
        }*/

        if (currentNode != null)
        {
            dText.text = currentNode.Line;
            OptionOne.text = currentNode.OptionOne;
            OptionTwo.text = currentNode.OptionTwo;
        }
    }

    public void ShowBox()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
