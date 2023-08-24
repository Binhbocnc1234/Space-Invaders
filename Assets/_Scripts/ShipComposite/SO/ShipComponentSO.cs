using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipComponentSO : ItemProfileSO
{   
    [Header("ShipComponent fields")]
    public ComponentType componentType = ComponentType.Energy;
    int w, h;
    public int cost;
    public override void OnEnable(){
        base.OnEnable();
        stats.TryAdd(ItemStat.EnergyConsumption, () => cost);
    }

}
public enum ComponentType{
    None,
    Energy,
    Firearm,
    Other,
}