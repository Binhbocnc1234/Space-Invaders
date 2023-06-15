using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModule : MonoBehaviour
{
    public Block block;
    public ShipComponent shipComponent;
    [HideInInspector] public ShipComposite shipComposite;
    [HideInInspector] public int i, j;
    protected void Start(){
    }
    protected void Update(){
        if (block.entity.health == 0){
            Destroy();
        }
    }
    protected void Destroy(){
        gameObject.SetActive(false);
        block.gameObject.SetActive(false);
        shipComponent.gameObject.SetActive(false);
        shipComposite.DestroyDisjointed();
    }
    public void SetBlock(){
        
    }

}
