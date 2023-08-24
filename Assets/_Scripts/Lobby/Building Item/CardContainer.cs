using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    protected static CardContainer instance;
    public static CardContainer Instance{get => instance;}
    void Awake(){
        if (instance != null){MyDebug.LogSingleton();}
        else{instance = this;}
    }
    public List<ItemProfileSO> choosenItemList;
    void Start(){
        for(int i = 0; i < transform.childCount; ++i){
            CardInBattle card = transform.GetChild(i).GetComponent<CardInBattle>();
            if (i < choosenItemList.Count){
                card.SetItem(choosenItemList[i]);
            }
            else{
                card.gameObject.SetActive(false);
            }
        }
    }
}
