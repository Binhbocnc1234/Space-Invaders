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
    // this.EnemySpawning();
    StartCoroutine(EnemyTimer());
   }

   IEnumerator EnemyTimer(){
    while(true){
      

      yield return new WaitForSeconds(3.0f);
      EnemySpawning();
    }
   }

   protected virtual void EnemySpawning(){
     Vector3 pos = this.enemyCtrl.SpawnPoint.GetRandom();

     List<Transform> Enemy = this.enemyCtrl.EnemySpawner.type;
     int rand = Random.Range(0, Enemy.Count);
     Transform obj = this.enemyCtrl.EnemySpawner.Spawn(Enemy[rand], pos, Quaternion.Euler(0,0,0));
     obj.gameObject.SetActive(true);

  }
  protected void GetSpawnPoint(int num){
    
  }
     
}
