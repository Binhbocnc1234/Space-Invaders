using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : Spawner
{
  //  [SerializeField] protected EnemyCtrl enemyCtrl;
  //  [SerializeField] protected Wave wave;


  protected virtual void Start(){
    // this.EnemySpawning();
    StartCoroutine(EnemyTimer());
  }

  IEnumerator EnemyTimer(){
    while(true){
      yield return new WaitForSeconds(3.0f);
      for(int i = 0; i < 3; i++){
         yield return new WaitForSeconds(0.2f);
         EnemySpawning();
      }
    }
  }
   
   
  protected virtual void EnemySpawning(){
    if(Wave.Instance.wave == Wave.Instance.endWave){
      StopCoroutine(EnemyTimer());
      EnemyBossSpawning();
      Wave.Instance.wave += 1;
      return;
    }

    else if(Wave.Instance.wave > Wave.Instance.endWave){
      return;
    }
    var lis = Wave.Instance.GetList();
    int rand = Random.Range(0, lis[Wave.Instance.wave].Item1.Count);
    
    Transform obj = Spawn(lis[Wave.Instance.wave].Item1[rand].GetComponent<Transform>(), Vector3.zero, Quaternion.identity);
    obj.gameObject.SetActive(true);
    
    lis[Wave.Instance.wave] = Wave.Instance.Decrease(lis[Wave.Instance.wave]);
    
  }

  protected virtual void EnemyBossSpawning(){
     Transform obj = Spawn(Wave.Instance.boss, new Vector3(0f, -16f, 0f), Quaternion.identity);
     obj.gameObject.SetActive(true);
     
  }

  protected virtual void Spawning(List<Wave.EnemyWave> lis, int rand){
   
  }
  
  protected void GetSpawnPoint(int num){
    
  }
  
     
}
