using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    protected static ItemDropSpawner instance;
   public ItemDropSpawner Instance {get => instance;}

   private void Awake(){
     ItemDropSpawner.instance = this;
   }

   protected override void LoadComponents(){
     base.LoadComponents();
   }


   protected override void LoadPrefabs(){
      this.List = "Prefabs";
      this.Type = new List<Transform>();
      base.LoadPrefabs(); 
   }

}
