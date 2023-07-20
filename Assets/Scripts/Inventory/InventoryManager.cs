using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Help slot render item's texture, item's name, number of items you have
public class InventoryManager : MonoBehaviour
{ 
    protected static InventoryManager instance;
    public static InventoryManager Instance{get => instance;}
    public ItemProfileUI itemProfileUI;
    [SerializeField] protected InventorySlot slotPrefab;
    [SerializeField] protected int maxSlot = 20;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected List<InventorySlot> inventorySlots;
    void Awake(){
        if (instance != null){instance = this;}
        else{MyDebug.LogSingleton();}
    }
    void Start(){
        inventory =  Inventory.Instance;
        InitializeInventoryManager(); 
    }
    void Update(){
        foreach(InventorySlot slot in inventorySlots){
            if(slot.item.itemCount == 0){
                slot.Disable();
            }
        }
    }
    void InitializeInventoryManager(){
        foreach(Transform child in transform){Destroy(child.gameObject);}
        for(int i = 0; i < maxSlot; i++){
            InventorySlot newSlot = Instantiate(slotPrefab, transform);
            if (i < inventory.items.Count){
                newSlot.item = inventory.items[i];
            }
            newSlot.itemProfileUI = itemProfileUI;
            inventorySlots.Add(newSlot);
        }   
    }
}
