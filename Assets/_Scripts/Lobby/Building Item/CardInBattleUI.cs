using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// A script attached to a Card. When being clicked, this script implements SelectModule() of ShipCompositeUI
/// </summary>
public class CardInBattle : MonoBehaviour{
    public ItemProfileSO item;
    public Image frame;
    public Image image;
    public void SelectCard(){
        MyDebug.Log($"You clicked {item.itemName} card");
        MotherShipUI.Instance.SelectModule(item);
    }
    public void SetItem(ItemProfileSO profile){
        if (profile == null){MyDebug.LogError("Item is null");}
        item = profile;
        frame.sprite = FrameContainer.Instance.raritySlot[(int)item.rarity];
        image.sprite = item.sprite;
    }
}
