using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Represent Tower in battles. If you want to build a Tower, using Instantiate() to create a copy of that tower 
/// </summary>
public class Tower : ShipComponent
{
    protected TowerSO towerSO;
    public Bullet bullet;
    protected Transform enemyLst;
    protected Entity target;
    protected Timer shotDelay = new Timer(0);
    void Start(){
        towerSO = (TowerSO)shipComponentSO;
        // if (towerSO == null){Debug.LogError("You need to assign TowerSO variable");}
        // StartCoroutine(SetTarget());
    }
    void Update(){
        if (shotDelay.Count(false) && target != null){
            Shoot(target);
        }
    }

    public virtual IEnumerator SetTarget(){
        while(true){
            if (target == null){
                foreach(Transform child in enemyLst){
                    if (Vector2.Distance(child.position, this.transform.position) <= towerSO.range){
                        target = child.GetComponent<Entity>();
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public virtual void Shoot(Entity target){
        Bullet newBullet = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation, transform);
        newBullet.damage = towerSO.damage;
        newBullet.GetComponent<BulletLockMove>().target = target.transform;
        newBullet.gameObject.SetActive(true);
    }

}
