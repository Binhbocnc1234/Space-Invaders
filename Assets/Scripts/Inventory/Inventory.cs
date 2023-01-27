using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Inventory : MonoBehaviour
{
  [SerializeField] protected int maxSlot = 70;
  public List<ItemInventory> items;

  protected static Inventory instance;

   public static Inventory Instance {get => instance;}

   private void Awake(){
     CheckRepeat();

     items = PlayerPrefsExtra.GetList<ItemInventory> ("items", new List<ItemInventory>());

     DontDestroyOnLoad(gameObject);
   }


   private void CheckRepeat(){
     if(Inventory.instance == null){
       Inventory.instance = this;
     }
     else if(Inventory.instance != this){
      Destroy(gameObject);
     }
   }

   private void Update(){

     PlayerPrefsExtra.SetList("items", items);
   }


   

  
  
  public virtual bool AddItem(ItemCode itemCode, int addCount){
    ItemInventory itemInventory = this.GetItemByCode(itemCode);

    int newCount = itemInventory.itemCount + addCount;
    // if(newCount > itemInventory.maxStack){
    //     return false;
    // }

    itemInventory.itemCount = newCount;
    return true;
  }

  public virtual ItemInventory GetItemByCode(ItemCode itemCode){
    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    if(itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
    return itemInventory;
  }

  protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode){
    var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));

    foreach(ItemProfileSO profile in profiles){
        if(profile.itemCode != itemCode) continue;
        ItemInventory itemInventory = new ItemInventory{
            itemProfile = profile,
            // maxStack = profile.defaultMaxStack

        };
        this.items.Add(itemInventory);
        return itemInventory;
    }

    return null;
  }


}
