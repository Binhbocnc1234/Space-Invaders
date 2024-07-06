using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary> Help slot render item's texture, item's name, number of items you have </summary>
public class InventoryUI : MonoBehaviour
{ 
    // protected static InventoryUI instance;
    // public static InventoryUI Instance{get => instance;}
    public ItemProfileUI itemProfileUI;
    [SerializeField] protected InventorySlot slotPrefab;
    [SerializeField] protected Inventory inventory;
    protected List<InventorySlot> inventorySlots = new List<InventorySlot>();
    void Awake(){
        inventory.OnActive += Active;
        inventory.OnDeactive += DeActive;
        Initialize(); 
    }
    void Start(){
        
    }
    void Update(){
        foreach(InventorySlot slot in inventorySlots){
            if(slot.item.itemCount == 0){
                slot.Disable();
            }
        }
    }
    void Initialize(){
        foreach(Transform child in transform){Destroy(child.gameObject);}
        for(int i = 0; i < inventory.items.Count; i++){
            InventorySlot newSlot = Instantiate(slotPrefab, transform);
            if (i < inventory.items.Count){
                newSlot.item = inventory.items[i];
            }
            newSlot.itemProfileUI = itemProfileUI;
            newSlot.SetItem(inventory.items[i]);
            inventorySlots.Add(newSlot);
        }   
    }
    void Active(){
        gameObject.SetActive(true);
    }
    void DeActive(){
        gameObject.SetActive(false);
    }
}
