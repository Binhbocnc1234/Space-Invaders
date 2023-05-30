using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContr : MonoBehaviour
{
    // Start is called before the first frame update
    protected static GameContr _instance;
    [HideInInspector] public static GameContr instance{get => _instance;}
    [HideInInspector] public float camHeight;
     
    
    
    void Awake()
    {
        _instance = this;
        camHeight = Camera.main.orthographicSize * Camera.main.aspect; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
