using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
  protected static InventorySlot  InventorySlots;

  public static InventorySlot  inventorySlot {get => InventorySlots;}

  RectTransform rt;

   private void Awake(){
     InventorySlot.InventorySlots = this;

     rt = GetComponent<RectTransform> ();
     
     
   }

   void Update(){
    if(rt.localScale.x != 1){
      rt.localScale = new Vector3 (1,1,1);
    }
   }



  public Image icon;
  public Text labelText;
  public Text stackSizeText;



  public void ClearSlot(){
    icon.enabled = false;
    labelText.enabled = false;
    stackSizeText.enabled = false;
  }

  public void DrawSlot(ItemInventory item){

    if(item == null){
        ClearSlot();
        return;
    }

    icon.enabled = true;
    labelText.enabled = true;
    stackSizeText.enabled = true;

    icon.sprite = item.itemProfile.icon;
    labelText.text = item.itemProfile.itemName;
    stackSizeText.text = item.itemCount.ToString();
  }
}
