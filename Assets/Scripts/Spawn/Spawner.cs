using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

   [SerializeField] protected string List = "Type";
   [SerializeField] protected List<Transform> Type;


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

   

}
