using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class EnemyRandom : Spawner
{
  public GameObject EnemyModel;
  protected virtual void Awake(){
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

      // Random EnemySO
      var lis = WaveManager.Instance.GetList();
      int rand = Random.Range(0, lis[WaveManager.Instance.wave].spawnList.Count);

      EnemySO randEnemy = lis[WaveManager.Instance.wave].spawnList[rand];

      Transform pos = WaveManager.Instance.GetRandPos();
      // pos.position = new Vector3(
      //   Mathf.Min(pos.position.x + Random.Range(-3f, 3f), limit),
      //   Mathf.Min(pos.position.y + Random.Range(-3f, 3f), limit),
      //   pos.position.z
      // );

      float x = Random.Range(0f, 10f);
      int check = Random.Range(0, 4);

      if(check == 0){
          pos.position = new Vector3(
            -x,
            -Mathf.Sqrt(100 - x*x),
            pos.position.z
          );
      }
      else if(check == 1){
          pos.position = new Vector3(
            x,
            Mathf.Sqrt(100 - x*x),
            pos.position.z
          );
      }
      else if(check == 2){
          pos.position = new Vector3(
            -x,
            Mathf.Sqrt(100 - x*x),
            pos.position.z
          );
      }
      else if(check == 3){
          pos.position = new Vector3(
            x,
            -Mathf.Sqrt(100 - x*x),
            pos.position.z
          );
      }

      
      EnemyModel.transform.Find("DamageReceive").GetComponent<Enemy>().enemy = randEnemy;
      EnemyModel.transform.Find("Model").gameObject.GetComponent<SpriteRenderer>().sprite = randEnemy.sprite;
      

      Transform obj = Spawn(EnemyModel.GetComponent<Transform>(), pos.position, Quaternion.identity);
      obj.gameObject.SetActive(true);
    
      lis[WaveManager.Instance.wave] = WaveManager.Instance.Decrease(lis[WaveManager.Instance.wave]);
    
  }



  // protected virtual void ChangeModel(GameObject model, EnemySO e){
  //   SplineFollower follower = model.GetComponent<SplineFollower>();
  //   follower.followSpeed = e.speed;
  //   follower.spline = e.typeMove;

  // }

  

  protected virtual void EnemyBossSpawning(){

    Transform obj = Spawn(WaveManager.Instance.boss, new Vector3(0f, -16f, 0f), Quaternion.identity);
    obj.gameObject.SetActive(true);
     
  }

  protected virtual void Spawning(List<WaveManager.EnemyWave> lis, int rand){
   
  }
  
  protected void GetSpawnPoint(int num){
    
  }
  
     
}
