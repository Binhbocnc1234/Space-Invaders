using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{
    public ShipComponentSO shipComponentSO;
    public ComponentType componentType;
    public string componentName;
    public int energyConsumption;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Reset(){
        this.gameObject.SetActive(true);
        energyConsumption = shipComponentSO.energyConsumption;
    }
}
