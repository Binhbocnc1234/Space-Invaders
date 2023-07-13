using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int armorPenetration;
    private Entity entity;
    private BulletDespawn bulletDespawn;
    void Start(){
        entity = GetComponent<Entity>();
        bulletDespawn = GetComponent<BulletDespawn>();
    }
    void OnTriggerEnter2D(Collider2D other){
        Entity otherEntity = other.GetComponent<Entity>();
        if (otherEntity != null && otherEntity.team != entity.team){
            if(otherEntity.GetDamage(damage)){
                otherEntity.OnDead?.Invoke();
            }
            bulletDespawn.DespawnObject();
        }
    }
}
