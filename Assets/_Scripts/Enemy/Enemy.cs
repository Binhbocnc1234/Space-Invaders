using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Link EnemySO
    public EnemySO enemy;
    

    private Entity entity;
    private EnemyDespawn enemyDespawn;
    void Start(){
        entity = GetComponent<Entity>();
        enemyDespawn = GetComponent<EnemyDespawn>();
    }
    
    // Destroy GetItem
    ItemProfileSO GetDroppedItem(){
        int rand = Random.Range(1,101);
       
        List<ItemProfileSO> p = new List<ItemProfileSO>();
        foreach(ItemProfileSO item in enemy.itemContain){
            if(rand <= item.dropChance){
                p.Add(item);
            }
        }
        if(p.Count > 0){
            ItemProfileSO droppedItem = p[Random.Range(0, p.Count)];
            return droppedItem;
        }
        return null;
    }

    public virtual void GetItem(){
        ItemProfileSO droppedItem = GetDroppedItem();
        if(droppedItem != null){
            string s = droppedItem.itemName;
            
            GameObject dp = Resources.Load("Items/ItemPrefab/" + s) as GameObject;
            
            Vector3 dropPos = transform.position;
            Quaternion dropRot = Quaternion.identity;
            Instantiate(dp, dropPos, dropRot);
            
        }  
    }

}
