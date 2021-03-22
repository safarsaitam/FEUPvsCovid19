using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    
    private static bool canvasExists;

    void Start()
    {
        // Debug.Log("Canvas start");
        // if (!canvasExists)
        // {
        //     canvasExists = true;
             DontDestroyOnLoad(this.gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }

    
    void Update()
    {
        
    }
}
