using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
  // Singleton
  [SerializeField] protected static BulletSpawner instance;
  public static BulletSpawner Instance {get => instance;}

  public static string hyperGun = "hyperGun";
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
   public List<Transform> BulletType {get => Type;}


  //  public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation){
  //    Transform Bullet = BulletType[0];
  //    Transform newPrefab = Instantiate(Bullet, spawnPos, rotation);
  //    return newPrefab;
  //   }


    
}