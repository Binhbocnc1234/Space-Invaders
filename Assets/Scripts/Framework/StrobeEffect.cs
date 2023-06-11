using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StrobeEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Target")]
    public TextMeshProUGUI textMesh;
    private float alpha = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (textMesh != null){
            Color copy = textMesh.color;
            // copy.a = 
        }
    }
}
