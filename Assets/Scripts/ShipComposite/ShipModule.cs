using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour
{
    public Block chamber;
    public ShipComponent shipComponent;
    [HideInInspector] public ShipComposite shipComposite;
    [HideInInspector] public int i, j;
    protected void Start(){
    }
    protected void Update(){
        if (chamber.entity.health == 0){
            Destroy();
        }
    }
    protected void Destroy(){
        Destroy(this.gameObject);
        shipComposite.DestroyDisjointed();
    }
}
