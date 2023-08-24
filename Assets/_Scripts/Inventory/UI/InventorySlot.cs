using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary> Class used for render item's texture, item's name, number of items you have </summary>
public class InventorySlot : MonoBehaviour , IRecycleableSlot{
  [HideInInspector] public ItemProfileUI itemProfileUI;
  public Image icon;
  public TextMeshProUGUI labelText;
  public TextMeshProUGUI stackSizeText;
  public ItemInventory item;
  // public void Update(){
  //   if (icon != null){icon.sprite = item.itemProfile.sprite;}
  //   if(labelText != null){labelText.text = item.itemProfile.itemName;}
  //   if(stackSizeText != null){stackSizeText.text = item.itemCount.ToString();}
  // }
  public void Disable(){
    this.gameObject.SetActive(false);
    
  }
  public void SetItem(ItemInventory item = null){
    this.item = item;
    if (icon != null){icon.sprite = item.itemProfile.sprite;}
    if(labelText != null){labelText.text = item.itemProfile.itemName;}
    if(stackSizeText != null){stackSizeText.text = item.itemCount.ToString();}
  }
  
  public void SetItemForProfile(){
    itemProfileUI.LoadNewItem(item.itemProfile);
  }
  public void SetItem(object obj){
    ItemInventory item = (ItemInventory)obj;
    if (item == null){Debug.LogError("Null paramenter : item in InventorySlot.SetItem");}
    SetItem(item);
  }
}
