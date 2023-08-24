using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use to send damage
public class DamageSender : MonoBehaviour
{

    [SerializeField] protected float damage = 120; //  base HyperGun damage;

    protected virtual void OnTriggerEnter2D(Collider2D collider){
      
        DamageReceive damageReceive = collider.GetComponent<DamageReceive>();
        if(damageReceive == null){return;}
        this.Send(damageReceive);

    }

    public virtual void Send(DamageReceive damageReceive){
        damageReceive.Detuct(this.damage);
    }

}
