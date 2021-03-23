using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    
    private static bool canvasExists;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        
    }
}
