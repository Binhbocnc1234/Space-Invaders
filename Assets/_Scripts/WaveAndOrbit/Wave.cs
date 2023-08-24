using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

  // singleton 
  protected static Wave instance;

  public static Wave Instance {get => instance;}

  private void Awake(){
     Wave.instance = this;
  }

    
  // temp boss system
  public Transform boss;


  [HideInInspector] public int wave = 0; // 0 can be understanded as wave begin

  public int endWave = 2; // Last Wave 
  // each way has one orbit corresponding
  int t;

    // Format : Orbit 
  public List <GameObject> Orbit = new List<GameObject>();
    
  // int : total number of enemy in one wave
  public struct EnemyWave{
    public List<GameObject> Item1;

    public int Item2;
  }

  public List<EnemyWave> enemyWave = new List<EnemyWave>();

  public List<EnemyWave> GetList(){
      return enemyWave;
  }
    // Chắc t p làm cái loading đầu game :)))))
  public void Start(){
      t = Orbit.Count;
      // Load enemyWave
      Object[] objs =  Resources.LoadAll("Enemy/EnemyModel", typeof(GameObject));
      for(int i = 0; i < t; i++){
        EnemyWave a = new EnemyWave();
        a.Item1 = new List<GameObject>();
        a.Item2 = 1;
        enemyWave.Add(a);
        for(int j = 0; j < objs.Length; j++){
            GameObject o = (GameObject) objs[j];
            if(o.name.EndsWith("-" + (i+1).ToString())){
              enemyWave[i].Item1.Add(o);
              EnemyWave element = enemyWave[i];
              element.Item2 = FirstNum(o.name);
              enemyWave[i] = element;
            }
        }
      }
  }

  static int FirstNum(string input){
       string number = "";
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                number += c;
            }
            else
            {
                break;
            }
        }
        return int.Parse(number);

  }

    
    // After adding new Orbit or enemyinwave n please reset WaveManager first !!! ( very important ) 
    public void Reset(){
        this.LoadComponents();
        
    }
    protected void LoadComponents(){
        this.LoadOrbits();
    }
    
    protected void LoadOrbits(){
       Object[] subListObjects = Resources.LoadAll("Enemy/MoveType/Level1", typeof(GameObject));
       foreach(GameObject obj in subListObjects){
            GameObject o = (GameObject) obj;
            Orbit.Add(o);
       }
       
    }

  
    // Enemy kill progress

    // Calculate remain number enemy in each wave
    public EnemyWave Decrease(EnemyWave e){
       e.Item2 -= 1;
       return e;
    }

    void Update(){
      if(enemyWave[wave].Item2 <= 0){
        wave += 1;
      }
    }
}



