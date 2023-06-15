using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    
    public override void DespawnObject()
    {
        // this.transform.position = Playership.Instance.transform.position; // cay vc :)))
        BulletSpawner.Instance.Despawn(transform);    
    }
    

    // Don't use for guns can go through enemy's space ship
    protected virtual void OnTriggerEnter2D(Collider2D collider){
      
      DamageReceive damageReceive = collider.GetComponent<DamageReceive>();
      if(damageReceive == null){return;}
      
      DespawnObject();
   }
}
