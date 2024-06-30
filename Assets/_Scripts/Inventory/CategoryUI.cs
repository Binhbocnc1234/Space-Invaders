using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// [RequireComponent(typeof(VerticalLayoutGroup))]

/// <summary> ShipBuilding support </summary>
public class CategoryUI : MonoBehaviour
{
    public int choosenOne = 0;
    public float minWidth;
    public float maxWidth;
    public Transform contentList;

    public void SwitchTo(int ind){
        choosenOne = ind;
        foreach(Transform content in contentList){
            content.gameObject.SetActive(false);
        }
        contentList.GetChild(ind).gameObject.SetActive(true);
        MyDebug.Log($"Switch to content named : {contentList.GetChild(ind).name}");
    }
}
