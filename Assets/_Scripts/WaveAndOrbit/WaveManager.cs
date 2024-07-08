using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform boss;
    
    protected static WaveManager instance;

    public static WaveManager Instance {get => instance;}

    private void Awake(){
        WaveManager.instance = this;
    }

    public string MapName = "Map1";

    [SerializeField] protected WaveData waveData;
    [HideInInspector] public int wave = 0;
    [HideInInspector] public int endWave = 2;

    [System.Serializable]
    public struct EnemyWave
    {
        public List<EnemySO> spawnList; // List enemy you can call to spawn
        public int num; // number of enemy spawn in one wave
    }

    private List<EnemyWave> enemyWaves = new List<EnemyWave>();



    public List<EnemyWave> GetList(){
        return enemyWaves;
    }

    public void Reset(){
        this.LoadComponents();
    }

    protected void LoadComponents(){
        LoadMap();
        LoadEnemy();
    }

    protected void LoadEnemy(){
        // Clear existing enemyWaves list
        enemyWaves.Clear();

        for (int i = 0; i < endWave; i++)
        {
            string path = $"Enemy/Enemy&Map/{MapName}/Wave{i + 1}";
            EnemySO[] enemySOArray = Resources.LoadAll<EnemySO>(path);

            if (enemySOArray != null && enemySOArray.Length > 0)
            {
                EnemyWave wave = new EnemyWave
                {
                    spawnList = new List<EnemySO>(enemySOArray),
                    num = 20,
                };

                enemyWaves.Add(wave);
            }
            else
            {
                Debug.LogWarning($"No EnemySO found at path: {path}");
            }
        }
    }

    protected void LoadMap(){
        waveData = Resources.Load<WaveData>("Wave/" + MapName);
        if (waveData == null)
        {
            Debug.LogError($"WaveData not found for map: {MapName}");
        }
    }

    public EnemyWave Decrease(EnemyWave e){
        e.num -= 1;
        if(e.num <= 0){
            ++wave;
        }
        return e;
    }

    void Start(){
        Reset();
    }

    public Transform GetRandPos(){
      return transform.GetChild(Random.Range(0, 4));
    }

}