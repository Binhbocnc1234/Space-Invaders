using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ComparisionUI : MonoBehaviour
{
    public ItemProfileUI first, second;
    public Image firstImg, secondImg;
    public Transform firstStats, secondStats;
    public void LoadComparision(ItemProfileSO firstProfile, ItemProfileSO secondProfile){
        this.first.LoadNewItem(firstProfile);
        this.second.LoadNewItem(secondProfile);
        SetGreenAndRed();
        MyDebug.Log("Load new item successfully");
    }
    void SetGreenAndRed(){
        for(int i = 0; i < first.transform.childCount; ++i){
            StatUI fiStat = first.transform.GetChild(i).GetComponent<StatUI>();
            StatUI seStat = second.transform.GetChild(i).GetComponent<StatUI>();
            if (fiStat.gameObject.activeSelf == false || seStat.gameObject.activeSelf == false || fiStat.value == seStat.value){
                seStat.tmp.color = Color.cyan;
                fiStat.tmp.color = Color.cyan;
            }
            else if (fiStat.value > seStat.value){
                fiStat.tmp.color = Color.green;
                seStat.tmp.color = Color.red;
            }
            else if (fiStat.value < seStat.value){
                seStat.tmp.color = Color.green;
                fiStat.tmp.color = Color.red;
            }
        }
    }

}
