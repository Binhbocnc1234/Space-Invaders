using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] protected GameObject slotPrefab;
    
    public List<ItemInventory> inventory;

    


    void Start(){
      inventory =  Inventory.Invent.items;
      
      DrawInventory(inventory); 
    }

    void DrawInventory(List<ItemInventory> inventory){
        for(int i = 0; i < inventory.Count; i++){
            var NewSlot = Instantiate(slotPrefab);

            NewSlot.transform.SetParent(transform, true);
            


            

            InventorySlot.inventorySlot.DrawSlot(inventory[i]);
                    
        }   
    }


    // void ResetInventory(){
    //     foreach(Transform childTransform in transform){
    //         Destroy(childTransform.gameObject);
    //     }

    //     inventorySlots = new List<InventorySlot>(30);
    // }


    // void CreateInventorySlot(){
        
    //     newSlot.transform.SetParent(transform, false);

    //     InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
    //     newSlotComponent.ClearSlot();

    //     inventorySlots.Add(newSlotComponent);
    // }
    

}
