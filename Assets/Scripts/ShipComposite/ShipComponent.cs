using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{
    public ShipComponentSO shipComponentSO;
    public SpriteRenderer spriteRenderer; 
    ComponentType componentType;
    int energyConsumption;
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void SetComponent(ShipComponentSO so){
        this.gameObject.SetActive(true);
        energyConsumption = so.energyConsumption;
        spriteRenderer.sprite = so.sprite;

    }
}
