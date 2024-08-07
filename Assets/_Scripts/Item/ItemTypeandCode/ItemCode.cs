using System;
using System.Collections.Generic;
using UnityEngine;


//Enum is sorted in alphabetical order: a b c d e f g h i j k l m n o p q r s t u v w x y z
public enum ItemCode{
    None = 0,
    Block_Stone,
    Block_BlueNanotech,
    Block_Steel,
    Block_Titan,
    Block_Wooden,
    Turret_Crossbow,
    Turret_Slingshot,
    Turret_Fireskull,
    Turret_1990sUltimateCannon,
    Turret_KevlarLaser,
    Turret_ToxicContainer,
    LoreItem_MemoryFragment,
    LoreItem_SpaceCrystal,
    Material_Cog,
    Material_Screw,
    Material_Wire, 
    Material_Ironbar,
    Material_Microchip,
    Material_Log,
    Material_Stone,
    Material_YellowInk,
    Material_BlueInk,
    Material_PurpleInk,
}
public static class ItemCodeParser {
    // Dictionary store ItemCode and ItemProfileSO
    public static Dictionary<ItemCode, ItemProfileSO> itemProfileDict = new Dictionary<ItemCode, ItemProfileSO>();

    static ItemCodeParser() {
        //Load all ItemProfileSO from folder "Item/ItemProfile"
        ItemProfileSO[] itemList = Resources.LoadAll<ItemProfileSO>("Item\\ItemProfile");
        for (int i = 0; i < itemList.Length; ++i) {
            itemProfileDict.Add(itemList[i].itemCode, itemList[i]);
        }
    }

    // String to Itemcode
    public static ItemCode FromString(string itemName) {
        try {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e) {
            Debug.LogError(e.ToString());
            return ItemCode.None;
        }
    }
}


