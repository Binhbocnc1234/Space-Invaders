using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipComponentSO : Marketable
{   
    [Header("ShipComponent fields")]
    public ComponentCode componentCode;
    public ComponentType componentType;
    public string componentName;
    public Sprite sprite;
    public string description;
    public int energyConsumption;
}
public enum ComponentType{
    None,
    Energy,
    Engine,
    Firearm,
    Other,
}
public enum ComponentCode{
    None,
    BlackList,
    Reactor,
    SmallFan,
    WoodenToilet,
}
