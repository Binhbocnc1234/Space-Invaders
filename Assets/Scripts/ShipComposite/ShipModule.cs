using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour
{
    public Block chamber;

    [HideInInspector] public ShipComposite shipComposite;
    [HideInInspector] public int i, j;
    protected void Start(){
        
    }
    protected void Update(){

    }
    protected void Destroy(){
        Destroy(this.gameObject);
        shipComposite.DestroyDisjointed();
    }
    
}
