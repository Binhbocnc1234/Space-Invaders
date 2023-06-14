using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ComponentType{
    Engine,
    Firearm,
    Energy,
}
public class ShipComponentSO : ScriptableObject
{   
    [Header("ShipComponent fields")]
    public string componentName;
    public ComponentType componentType;
    public int cost;
    public Sprite sprite;
    public string description;
    public int energyConsumption;
}
