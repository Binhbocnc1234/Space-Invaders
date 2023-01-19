using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : Temp
{
   [SerializeField] protected EnemyCtrl enemyCtrl;
    
    
    protected override void LoadComponents(){
     base.LoadComponents();
     this.LoadEnemyCtrl();
   }

   protected virtual void LoadEnemyCtrl(){
    if(this.enemyCtrl != null){return;}

    this.enemyCtrl = GetComponent<EnemyCtrl>();
   }

   


   protected virtual void Start(){
    this.EnemySpawning();
   }

   protected virtual void EnemySpawning(){
     Transform ranPoint = this.enemyCtrl.SpawnPoint.GetRandom();

     Vector3 pos = ranPoint.position;
     Quaternion rot = ranPoint.rotation;

     List<Transform> Enemy = this.enemyCtrl.EnemySpawner.type;
     int rand = Random.Range(0,100);

     if(rand <= 10){
       Transform obj = this.enemyCtrl.EnemySpawner.Spawn(Enemy[1], pos, rot);
       obj.gameObject.SetActive(true);
       Invoke(nameof(this.EnemySpawning) , 1f);
     }
     else{
       Transform obj = this.enemyCtrl.EnemySpawner.Spawn(Enemy[0], pos, rot);
       obj.gameObject.SetActive(true);
       Invoke(nameof(this.EnemySpawning) , 1f); 
     }
     
     
       
    
     
     }
     
}
