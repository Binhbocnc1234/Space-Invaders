using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public TextMeshPro tmp;
    public Transform positionObject;
    void Start(){
        // tmp = GetComponent<TextMeshPro>();
        gameObject.SetActive(false);
    }
    public void SetMessage(string text, Vector3 pos){
        tmp.text = text;
        positionObject.position = pos;
        gameObject.SetActive(true);
    }
    public void EndAnim(){
        gameObject.SetActive(false);
    }
}
