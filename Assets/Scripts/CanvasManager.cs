using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    
    private static bool canvasExists;

    void Start()
    {

        int numCanvas = FindObjectsOfType<Canvas>().Length;
        if (numCanvas > 1)
        {
            Destroy(this.gameObject);
        }
        
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    
    void Update()
    {
        
    }
}
