using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : Temp
{
   [SerializeField] protected Inventory inventory;
   [SerializeField] protected SphereCollider _collider;
   [SerializeField] protected Rigidbody _rigidbody;

   protected override void LoadComponents(){
    base.LoadComponents();
    this.LoadInventory();
   }

   protected virtual void LoadInventory(){
    if(this.inventory != null){
        return;
    }
    this.inventory = transform.parent.GetComponent<Inventory>();

   }


   protected virtual void OnTriggerEnter(Collider collider){
     ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
     if(itemPickupable == null) return;
    

     ItemCode itemCode = itemPickupable.GetItemCode();
        if(this.inventory.AddItem(itemCode,1)){
            itemPickupable.Picked();
        }
   }

}
