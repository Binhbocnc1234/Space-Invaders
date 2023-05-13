using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [Header("Spawner")]

   [SerializeField] protected string List = "Type";
   [SerializeField] protected List<Transform> Type;

   public List<Transform> type {get => Type;}

   
   [SerializeField] protected Transform holder;
   [SerializeField] protected int spawnedCount = 0;
   public int SpawnedCount => spawnedCount;
   [SerializeField] protected List<Transform> poolObjs;
   [SerializeField] protected List<Transform> prefabs;



   
   protected virtual void Reset(){
     this.LoadComponents();
   } 
   protected virtual void LoadComponents(){
     this.LoadPrefabs();
   }


   protected virtual void LoadPrefabs(){
      Transform Obj = transform.Find(List);
      foreach(Transform prefab in Obj){
        this.Type.Add(prefab);
      }
      this.HidePrefabs();
   }

   protected virtual void HidePrefabs(){
     foreach(Transform prefab in this.Type){
        prefab.gameObject.SetActive(false);
     }
   }

   public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation){
     Transform newPrefab = this.GetObjectFromPool(prefab);
     
     newPrefab.SetPositionAndRotation(spawnPos, rotation);

     newPrefab.parent = this.holder;
     this.spawnedCount++;
     return newPrefab;
   }

   public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation){
     Transform prefab = this.GetPrefabByName(prefabName);
     if(prefab == null){
      return null;
     }

     return this.Spawn(prefab, spawnPos, rotation);

   }

   protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        for(int i = 0; i < poolObjs.Count; i++)
        {
            if (poolObjs[i] == null){
              this.poolObjs.Remove(poolObjs[i]);
            }

            if (poolObjs[i].name == prefab.name){
                Transform a = poolObjs[i]; 
                this.poolObjs.Remove(poolObjs[i]);
                return a; // 
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }


   public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName){return prefab;}
        }

        return null;
    }

     public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        
        obj.GetChild(0).gameObject.SetActive(false); 

        this.spawnedCount--;
    }

   

}
