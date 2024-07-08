using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn
{
  private Enemy enemy;
  private Entity entity;


  public override void DespawnObject(){
    transform.parent.gameObject.SetActive(false);
    if(entity.health <= 0){
      enemy.GetItem();
    }
  }

  protected override bool CanDespawn(){
    if(entity.health <= 0){
      return true;
    }

    return false;
  }
   
  void Start(){
    enemy = GetComponent<Enemy>();
    entity = GetComponent<Entity>();

    entity.OnDead += DespawnObject;
  }


}
