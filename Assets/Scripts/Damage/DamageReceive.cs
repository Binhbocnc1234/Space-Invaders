using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class DamageReceive : MonoBehaviour
{
    [Header("Despawn")]
    [SerializeField] protected Despawn Despawn;

    [SerializeField] public float hp = 1;
    [SerializeField] public float maxHealth;

    
    // Link EnemySO
    public EnemySO enemy;

    protected virtual void Start(){
        maxHealth = enemy.health;
        this.Reset();
    }

    public virtual void Reset(){
      this.hp = maxHealth;
    }
    
    public virtual void Detuct(float detuct){
        this.hp -= detuct;
        if(this.hp < 0){ 
            this.hp = 0; 
        }
        this.CheckDead();
    }

    protected virtual bool Isdead(){
        return this.hp <= 0;
    }

    protected virtual void CheckDead(){
        if(!this.Isdead()){
            return;
        }
        GetItem();
        this.Despawn.DespawnObject();
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
