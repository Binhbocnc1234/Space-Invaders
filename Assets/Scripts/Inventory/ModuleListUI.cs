using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


///<summary>
/// Filter from Inventory to get MotherShip-related items, then pass them for UI
///</summary>
public class ModuleListUI : MonoBehaviour
{
    public GridLayoutGroup blockContent;
    public GridLayoutGroup turretContent;
    public GridLayoutGroup engineContent;
    public Inventory inventory;
    public InventorySlot inventorySlotPrefab;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadFromInventory(){
        foreach(ItemInventory itemInventory in inventory.items){
            
            ItemProfileSO profile = itemInventory.itemProfile;
            if (profile.GetType() == typeof(BlockSO)){
                InventorySlot slot = Instantiate(inventorySlotPrefab, blockContent.transform);
                slot.SetItem(itemInventory);
            }   
            else if (profile.GetType() == typeof(EngineSO)){
                InventorySlot slot = Instantiate(inventorySlotPrefab, engineContent.transform);
                slot.SetItem(itemInventory);
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ModuleListUI))]
public class BuildingItemListEditor: Editor{
    ModuleListUI moduleList;
    public override void OnInspectorGUI()
    {
        moduleList = (ModuleListUI)target;
        base.OnInspectorGUI();
        if (GUILayout.Button("Retrive List")){
            moduleList.LoadFromInventory();
        }
    }
}
#endif