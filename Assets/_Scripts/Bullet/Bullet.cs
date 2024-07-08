using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Entity)), RequireComponent(typeof(BulletDespawn))]
public class Bullet : MonoBehaviour
{
    public float damage;
    public int armorPenetration;
    //
    public Entity ally;
    public BulletDespawn bulletDespawn;
    void Start(){
        ally = GetComponent<Entity>();
        bulletDespawn = GetComponent<BulletDespawn>();
    }
    void OnTriggerEnter2D(Collider2D other){
        Entity otherEntity = other.GetComponent<Entity>();
        if (otherEntity != null && otherEntity.team != ally.team){
            if(otherEntity.GetDamage(damage)){
                otherEntity.OnDead?.Invoke();
            }
            bulletDespawn.DespawnObject();
        }
    }
    void OutOfScreen(){

    }
    public void Despawn(){
        
    }

}
