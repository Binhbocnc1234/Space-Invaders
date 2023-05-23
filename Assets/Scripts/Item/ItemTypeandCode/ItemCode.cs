
using System;
using UnityEngine;

public enum ItemCode
{
    None = 0,
    Cog = 1,
    Screw = 2,
    Wire = 3, 

}

public class ItemCodeParser{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.None;
        }
    }
}