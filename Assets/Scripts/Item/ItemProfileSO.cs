
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
  public ItemCode itemCode = ItemCode.None;
  public ItemType itemType = ItemType.None;
  public string itemName = "Sth-name";
  public string description = "An useful item";
  public Sprite icon;
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
