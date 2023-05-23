using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Help Slot render item's texture, item's name, number of items you have
public class InventorySlot : MonoBehaviour{
  
  public Image icon;
  public TextMeshProUGUI labelText;
  public TextMeshProUGUI stackSizeText;
  public ItemInventory item;
  public void Update(){
    icon.sprite = item.itemProfile.icon;
    labelText.text = item.itemProfile.itemName;
    stackSizeText.text = item.itemCount.ToString();
  }
  public void Disable(){
    this.gameObject.SetActive(false);
    
  }
}
