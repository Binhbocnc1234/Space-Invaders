using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
  [SerializeField] protected List<Transform> Points;
   


   protected virtual void Reset(){
     this.LoadPrefabs();
   } 
  
   protected virtual void LoadPrefabs(){

      
      Transform Obj = GameObject.Find("SpawnPoints").transform;
      

      foreach(Transform prefab in Obj){
        this.Points.Add(prefab);
      }
   }

   public virtual Transform GetRandom(){
    int rand = Random.Range(0,this.Points.Count);

    return this.Points[rand];
   }
}
