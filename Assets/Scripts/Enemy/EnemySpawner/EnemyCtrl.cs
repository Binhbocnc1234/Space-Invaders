using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//        |
//        |
//        |
// mũi tên chỉ xuống

// Use only to load component và load linked
public class EnemyCtrl : MonoBehaviour, ITemp
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint { get => spawnPoint; }

 


    protected virtual void LoadComponents(){
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
