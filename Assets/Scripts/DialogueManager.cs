﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    void Start()
    {
        
    }

    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Return))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}
