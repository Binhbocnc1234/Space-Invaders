using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    TextMeshPro tmp;
    void Start(){
        tmp = GetComponent<TextMeshPro>();
        gameObject.SetActive(false);
    }
    public void SetMessage(string text, Vector3 pos){
        tmp.text = text;
        transform.position = pos;
        gameObject.SetActive(true);
    }
    public void EndAnim(){
        gameObject.SetActive(false);
    }
}
