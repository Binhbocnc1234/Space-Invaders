using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner

{
   protected static EnemySpawner instance;
   public EnemySpawner Instance {get => instance;}

   private void Awake(){
     EnemySpawner.instance = this;
     
   }

   



  //  protected override void Reset(){
  //    base.Reset();
  //  } 
   

   protected override void LoadComponents(){
     base.LoadComponents();
   }
   
   

  
   protected override void LoadPrefabs(){
      this.List = "EnemyType";
      this.Type = new List<Transform>();
      base.LoadPrefabs(); 
   }

    
  
   
   
   public List<Transform> type {get => Type;}

}


