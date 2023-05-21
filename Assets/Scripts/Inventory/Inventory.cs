using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  public List<ItemInventory> items;
  protected static Inventory instance;
  public static Inventory Instance {get => instance;}

  private void Awake(){
    if(Inventory.instance == null){
      Inventory.instance = this;
    }
    else{
      Destroy(gameObject);
      Debug.LogWarning("You have created two instance of Inventory");
    }
    //Retrieve player data
    items = PlayerPrefsExtra.GetList<ItemInventory>("items", new List<ItemInventory>());
    DontDestroyOnLoad(gameObject);
  }
  private void Update(){
    PlayerPrefsExtra.SetList("items", items);
  }
  public virtual bool AddItem(ItemCode itemCode, int addCount){
    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    if (itemInventory == null){
      itemInventory = AddNewItem(itemCode);
    }
    if (itemInventory.itemCount + addCount < 0){
      Debug.LogWarning("Insuffient items");
      return false;
    }
    else{
      itemInventory.itemCount += addCount;
      return true;
    }
  }

  public virtual ItemInventory GetItemByCode(ItemCode itemCode){
    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    return itemInventory;
  }
  protected virtual ItemInventory AddNewItem(ItemCode itemCode){
    var profiles = Resources.LoadAll("Items/ItemProfiles", typeof(ItemProfileSO));
    foreach(ItemProfileSO profile in profiles){
        if(profile.itemCode != itemCode) continue;
        ItemInventory itemInventory = new ItemInventory{
            itemProfile = profile
        };
        this.items.Add(itemInventory);
        return itemInventory;
    }
    Debug.LogError($"You haven't created ItemProfileSO with itemCode \"{itemCode}\"");
    return null;
  }


}
