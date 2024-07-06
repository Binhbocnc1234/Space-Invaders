using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Experimental.GraphView;
#endif

//Items need help
[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject{
  [SearchWindow]
  public ItemCode itemCode = ItemCode.None;
  public ItemType itemType = ItemType.None;
  public Rarity rarity = Rarity.Common;
  public string itemName;
  public string description;
  public Sprite sprite;
  public int dropChance;
  public Dictionary<ItemStat, Func<object>> stats = new Dictionary<ItemStat, Func<object>>();
  public virtual void OnEnable(){}
  public static ItemProfileSO FindByItemCode(ItemCode itemCode){
      var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
      foreach (ItemProfileSO profile in profiles){
          if (profile.itemCode != itemCode) continue;
          return profile;
      }
      MyDebug.LogError($"You haven't created ItemProfileSO with itemCode \"{itemCode}\"");
      return null;
  }
}
