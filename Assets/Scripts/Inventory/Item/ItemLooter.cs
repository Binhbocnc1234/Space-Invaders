using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemLooter : Temp
{
//    [SerializeField] protected Inventory inventory;
   protected CircleCollider2D _collider;
   protected Rigidbody2D _rigidbody;

//    protected override void LoadComponents(){
//     base.LoadComponents();
//     this.LoadInventory();
//    }

//    protected virtual void LoadInventory(){
//     if(this.inventory != null){
//         return;
//     }
//     this.inventory = transform.parent.GetComponent<Inventory>();

//    }

   void Start(){
      _collider = GetComponent<CircleCollider2D>(); _rigidbody = GetComponent<Rigidbody2D>();
   }
   protected virtual void OnTriggerEnter2D(Collider2D collider){
    //  Debug.Log("SuongWA");
      ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();

      if(itemPickupable == null) return;
      

      ItemCode itemCode = itemPickupable.GetItemCode();
         if(Inventory.Instance.AddItem(itemCode,1)){
               itemPickupable.Picked();
         }
   }

}
