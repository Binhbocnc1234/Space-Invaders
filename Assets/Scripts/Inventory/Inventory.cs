using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// Singleton class. A container for items Player earns from battles. Inventory is saved after closing game
/// </summary>
public class Inventory : MonoBehaviour
{
  protected static Inventory instance;
  public static Inventory Instance {get => instance;}
  enum SortOption{
    Name, Level, DPS, Star, 
  }
  public List<ItemInventory> items;
  public List<List<ItemInventory>> categoryList;

  private void Awake(){
    if(Inventory.instance == null){
      Inventory.instance = this;
    }
    else{
      Destroy(gameObject);
      Debug.LogWarning("You have created two instance of Inventory");
    }
    //You can choose not to load data when testing
    // LoadData();
    DontDestroyOnLoad(gameObject);
  }
  private void SaveData(){
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

}
