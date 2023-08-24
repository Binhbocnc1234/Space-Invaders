using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class CardFrame{
    public Sprite frame;
    public Sprite background;
}
public class FrameContainer : MonoBehaviour
{
    protected static FrameContainer instance;
    public static FrameContainer Instance{get => instance;}
    public Sprite[] raritySlot;
    public CardFrame[] rarityCardFrame;
    void Awake(){
        if (instance != null){MyDebug.LogSingleton(); Destroy(this.gameObject);}else{instance = this;}
        DontDestroyOnLoad(this.gameObject);
    }
}
