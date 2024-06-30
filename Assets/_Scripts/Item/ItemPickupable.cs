using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupable : ItemAbstract
{
  // Support getItemCode
  public static ItemCode StringToItemCode(string itemName){
    return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
  }
  
  public virtual ItemCode GetItemCode(){
    
    return ItemPickupable.StringToItemCode(transform.parent.name);

  }
  
  // Destroy -> add to pool obj
  public virtual void Picked(){
      this.itemCtrl.Despawn.DespawnObject();
  }


}
