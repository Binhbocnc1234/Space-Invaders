using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference : MonoBehaviour
{
    protected static Reference instance;
    public static Reference Instance{get => instance;}
    [Header("References to GameObjects")]
    public Transform towerContainer;
    void Awake(){
        if (instance != null){MyDebug.LogSingleton();}
        else{instance = this;}
    }

}
