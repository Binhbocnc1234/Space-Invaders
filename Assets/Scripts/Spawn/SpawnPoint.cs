using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
  // [SerializeField] protected List<Transform> Points;
   


  //  protected virtual void Reset(){
  //    this.LoadPrefabs();
  //  } 
  
  //  protected virtual void LoadPrefabs(){

      
  //     Transform Obj = GameObject.Find("SpawnPoints").transform;
      

  //     foreach(Transform prefab in Obj){
  //       this.Points.Add(prefab);
  //     }
  //  }
  public virtual Vector3 GetRandom(){
    return new Vector3(Random.Range(-Camera.main.orthographicSize, +Camera.main.orthographicSize), -GameContr.instance.camHeight);
  }
}
