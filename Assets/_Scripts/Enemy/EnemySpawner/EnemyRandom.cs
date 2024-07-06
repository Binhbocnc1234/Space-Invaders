using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class EnemyRandom : Spawner
{
  public GameObject EnemyModel;
  protected virtual void Start(){
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

      if(WaveManager.Instance.wave == WaveManager.Instance.endWave){
        StopCoroutine(EnemyTimer());
        EnemyBossSpawning();
        WaveManager.Instance.wave += 1;
        return;
      }

      else if(WaveManager.Instance.wave > WaveManager.Instance.endWave){
        return;
      }
      var lis = WaveManager.Instance.GetList();
      int rand = Random.Range(0, lis[WaveManager.Instance.wave].spawnList.Count);

      EnemySO randEnemy = lis[WaveManager.Instance.wave].spawnList[rand];

      ChangeModel(EnemyModel, randEnemy);


      Transform obj = Spawn(EnemyModel.GetComponent<Transform>(), Vector3.zero, Quaternion.identity);
      obj.gameObject.SetActive(true);
    
      lis[WaveManager.Instance.wave] = WaveManager.Instance.Decrease(lis[WaveManager.Instance.wave]);
    
  }

  protected virtual void ChangeModel(GameObject model, EnemySO e){
    SplineFollower follower = model.GetComponent<SplineFollower>();
    follower.followSpeed = e.speed;
    follower.spline = e.typeMove;

  }

  protected virtual void EnemyBossSpawning(){

    Transform obj = Spawn(WaveManager.Instance.boss, new Vector3(0f, -16f, 0f), Quaternion.identity);
    obj.gameObject.SetActive(true);
     
  }

  protected virtual void Spawning(List<WaveManager.EnemyWave> lis, int rand){
   
  }
  
  protected void GetSpawnPoint(int num){
    
  }
  
     
}
