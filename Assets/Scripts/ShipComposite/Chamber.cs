using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockSO chamberSO;
    protected void Start(){
        GetComponent<SpriteRenderer>().sprite = chamberSO.texture;

    }
    protected void Update(){
        
    }
    protected void Destroy()
    {
        
    }

}
