
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
  // Một số t.tin liên quan tới item

  public ItemCode itemCode = ItemCode.NoItem;
  public ItemType itemType = ItemType.NoType;




  public string itemName = "Sth-name";
//   public int defaultMaxStack = 7;




public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

}
