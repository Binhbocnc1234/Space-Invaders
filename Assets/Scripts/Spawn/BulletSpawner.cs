using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{

  [SerializeField] protected static BulletSpawner instance;
  public static BulletSpawner Instance {get => instance;}
  
  private void Awake(){
    BulletSpawner.instance = this;
  }

  protected override void Reset(){
    base.Reset();
  } 
   
  protected override void LoadComponents(){
    base.LoadComponents();
  }


   protected override void LoadPrefabs(){
      this.List = "BulletType";
      this.Type = new List<Transform>();
      base.LoadPrefabs();
      
   }


   public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation){
      Transform prefab = this.Type[0];
      Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
      newPrefab.gameObject.SetActive(true);
      return newPrefab;

    }
}
