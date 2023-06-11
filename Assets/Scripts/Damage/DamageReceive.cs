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

    
    

    protected virtual void Start(){
        if(this.GetComponent<EnemyDD>()){
           maxHealth = this.GetComponent<EnemyDD>().enemy.health;
        }
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
        if(this.GetComponent<EnemyDD>()){
           this.GetComponent<EnemyDD>().GetItem();
        }
        this.Despawn.DespawnObject();
    }

}
