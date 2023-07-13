using System;

[Serializable]
public class ItemInventory
{
  public ItemProfileSO itemProfile;
  public int itemCount = 0;  

  public ItemInventory(ItemCode itemCode, int itemCount = 0){
    itemProfile = ItemProfileSO.FindByItemCode(itemCode);
    this.itemCount = itemCount;
  }
  public bool AddItem(int amount){
    if (itemCount + amount < 0){
      MyDebug.Log("Insuffient items");
      return false;
    }
    itemCount += amount;
    return true;
  }
}
