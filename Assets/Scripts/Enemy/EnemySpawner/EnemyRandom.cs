using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : Spawner
{
  //  [SerializeField] protected EnemyCtrl enemyCtrl;
   [SerializeField] protected Wave wave;


     
  // protected override void LoadComponents(){
  //    base.LoadComponents();
  //    this.LoadEnemyCtrl();
  //  }

  //  protected virtual void LoadEnemyCtrl(){
  //   if(this.enemyCtrl != null){return;}

  //   this.enemyCtrl = GetComponent<EnemyCtrl>();

  //   this.wave = FindObjectOfType<Wave>();
  //  }

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
    //  Vector3 pos = this.enemyCtrl.SpawnPoint.GetRandom();

    //  List<Transform> Enemy = this.enemyCtrl.EnemySpawner.type;
    //  int rand = Random.Range(0, Enemy.Count);
    //  Transform obj = this.enemyCtrl.EnemySpawner.Spawn(Enemy[rand] , pos, Quaternion.Euler(0,0,0));
    
    //  int k = Wave.Instance.wave;
    //  Debug.Log(Wave.Instance.enemyWave[0].Item1[0].name);
    //  int rand = Random.Range(0, Wave.Instance.enemyWave[k].Item1.Count);
    //  Debug.Log(rand);
    //  Transform obj = this.enemyCtrl.EnemySpawner.Spawn(Wave.Instance.enemyWave[k].Item1[rand].GetComponent<Transform>(), pos, Quaternion.Euler(0,0,0));
    //  obj.gameObject.SetActive(true);

    
    var lis = wave.GetList();
    int rand = Random.Range(0, lis[this.wave.wave].Item1.Count);
    Transform obj = Spawn(lis[this.wave.wave].Item1[rand].GetComponent<Transform>(), Vector3.zero, Quaternion.identity);
    obj.gameObject.SetActive(true);

  }
  protected void GetSpawnPoint(int num){
    
  }
  
     
}
