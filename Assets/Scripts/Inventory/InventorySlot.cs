using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Help Slot render item's texture, item's name, number of items you have
public class InventorySlot : MonoBehaviour{
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
    if (item == null){return;}
    this.item = item;
    if (icon != null){icon.sprite = item.itemProfile.sprite;}
    if(labelText != null){labelText.text = item.itemProfile.itemName;}
    if(stackSizeText != null){stackSizeText.text = item.itemCount.ToString();}
  }
  public void SetItemForProfile(){
    itemProfileUI.LoadNewItem(item.itemProfile);
  }
}
