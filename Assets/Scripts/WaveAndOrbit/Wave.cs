using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

  // singleton 
  // protected static Wave instance;

  // public static Wave Instance {get => instance;}

  // private void Awake(){
  //    Wave.instance = this;
  // }

    


    public int wave; // 0 can be understanded as wave begin
    // each way has one orbit corresponding
    int t;

    // Format : Orbit 
    public List <GameObject> Orbit = new List<GameObject>();
    
    // int : number of enemy
    public List<(List<GameObject>, int)> enemyWave = new List<(List<GameObject>, int)>();

    public List<(List<GameObject>, int)> GetList(){
      return enemyWave;
    }
    
     public void Start(){
      t = Orbit.Count;
      Object[] objs =  Resources.LoadAll("Enemy/EnemyModel", typeof(GameObject));
      for(int i = 0; i < t; i++){
        List<GameObject> a = new List<GameObject>();
        enemyWave.Add((a,5));
        for(int j = 0; j < objs.Length; j++){
            GameObject o = (GameObject) objs[j];
            if(o.name.EndsWith("-" + (i+1).ToString())){
              enemyWave[i].Item1.Add(o);
            }
        }

      }
      // foreach(GameObject x in enemyWave[0].Item1){
      //     Debug.Log(x.name);
      // }
    }
    
    // After adding new Orbit or enemyinwave n please reset WaveManager first !!! ( very important ) 
    public void Reset(){
        this.LoadComponents();
        
    }
    protected void LoadComponents(){
        this.LoadOrbits();
        this.LoadEnemyWave();
    }
    
    protected void LoadOrbits(){
       Object[] subListObjects = Resources.LoadAll("Enemy/MoveType/Level1", typeof(GameObject));
       foreach(GameObject obj in subListObjects){
            GameObject o = (GameObject) obj;
            Orbit.Add(o);
       }
       
    }

    protected void LoadEnemyWave(){
      
    }

   
    
    // Enemy kill progress
    
}



