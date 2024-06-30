using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour, ITemp
{
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;



    protected virtual void LoadComponents(){
        this.LoadDespawn();
        this.LoadItemInventory();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();   
    }
    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        
        this.itemInventory.itemProfile = itemProfile; 
    }
}
