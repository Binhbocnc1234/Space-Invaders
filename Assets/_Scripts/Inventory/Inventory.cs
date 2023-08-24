using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public enum InventoryType{
  None, Item , Tower , Block 
}
/// <summary>
/// A container for items Player earns from battles. Inventory is saved after closing game
/// </summary>
public class Inventory : MonoBehaviour
{
  protected static Inventory instance;
  public static Inventory Instance{get => instance;}
  enum SortOption{
    Name, Level, DPS, Star, 
  }
  public List<ItemType> itemTypeLst;
  public List<ItemInventory> items;
  public Action OnDeactive;
  public Action OnActive;
  protected void Awake(){
    if (instance == null){instance = this;}
    OnDeactive += DeActive; OnActive += Active;
    //You can choose not to load data when testing
    // LoadData();
  }
  protected void SaveData(){
    PlayerPrefsExtra.SetList("items", items);
  }
  public void LoadData(){
    items = PlayerPrefsExtra.GetList<ItemInventory>("items", new List<ItemInventory>());
    
  }
  /// <summary>
  /// Add item by amount. You can remove some items from Inventory if you set amount smaller than zero
  /// </summary>
  /// <returns> False if the number of available items is smaller than the amount you want to remove. Otherwise, return True</returns>
  public virtual bool AddItem(ItemCode itemCode, int amount){
    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    if (itemInventory == null){
      items.Add(new ItemInventory(itemCode));
    }
    return itemInventory.AddItem(amount);
  }

  public virtual ItemInventory GetItemByCode(ItemCode itemCode){
    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    return itemInventory;
  }
  public virtual List<ItemInventory> GetItemByType(ItemType type){
    List<ItemInventory> newItemLst = new List<ItemInventory>();
    foreach(ItemInventory item in items){
      if (item.itemProfile.itemType == type){
        newItemLst.Add(item);
      }
    }
    return newItemLst;
  }
  public void Active(){gameObject.SetActive(true);}
  public void DeActive(){gameObject.SetActive(false);}
}
