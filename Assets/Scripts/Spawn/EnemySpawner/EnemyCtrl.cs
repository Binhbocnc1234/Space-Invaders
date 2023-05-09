using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//        |
//        |
//        |
// mũi tên chỉ xuống

// Use only to load component và load liên kết =)) méo bt liên kết TA là gì
public class EnemyCtrl : Temp
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint { get => spawnPoint; }


    protected override void LoadComponents(){
     base.LoadComponents();
     this.LoadEnemySpawner();
     this.LoadSpawnPoint();
   }

   protected virtual void LoadEnemySpawner(){
    if(this.enemySpawner != null){return;}

    this.enemySpawner = GetComponent<EnemySpawner>();
   }

   protected virtual void LoadSpawnPoint(){
    if(this.spawnPoint != null){return;}
    this.spawnPoint = Transform.FindObjectOfType<SpawnPoint>();
   }

}
