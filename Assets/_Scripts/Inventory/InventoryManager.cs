using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    protected static InventoryManager instance;
    public static InventoryManager Instance{get => instance;}
    public List<Inventory> inventories;
    [HideInInspector] public int choosenOne;
    void Awake(){
        if (instance != null){MyDebug.LogSingleton();}
        else{instance = this;}
    }
    void Start(){
        SwitchInventory(0);
    }
    public void SwitchInventory(int ind){
        choosenOne = ind;
        for(int i = 0; i < inventories.Count; ++i){
            if (i == ind){inventories[i].OnActive.Invoke();}
            else{inventories[i].OnDeactive.Invoke();}
        }
        MyDebug.Log($"Switch to Inventory named : {inventories[ind].name}");
    }
    public void SwitchInventory(Inventory inventory){
        for(int i = 0; i < inventories.Count; ++i){
            if (inventories[i] == inventory){inventories[i].OnActive?.Invoke(); choosenOne = i;}
            else{inventories[i].OnDeactive?.Invoke();}
        }
        MyDebug.Log($"Switch to Inventory named : {inventory.name}");
    }
    public virtual bool AddItem(ItemCode itemCode, int amount){
        ItemType type = ItemCodeParser.itemProfileDict[itemCode].itemType;
        foreach(Inventory inv in inventories){
            foreach(ItemType itemType in inv.itemTypeLst){
                if (type == itemType){
                    inv.AddItem(itemCode, amount);
                    return true;
                }
            }
        }
        return false;
    }
    public Inventory GetInventoryByType(ItemType type){
        foreach(Inventory inv in inventories){
            if (inv.itemTypeLst.Contains(type)){
                return inv;
            }
        }
        Debug.Log($"Not found inventory with ItemType : {type.ToString()}");
        return null;
    }

}
