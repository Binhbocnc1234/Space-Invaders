using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathnote : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int level;
    float damage;
    Timer firerate = new Timer(1.5f);
    int chance = 0;
    Timer extrabulletTimer = new Timer(0.25f);
    bool isExtraBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }
    void switchLevel(int level){
        this.level = level;
        
    }
    void Shooting(){
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        if (isExtraBullet && extrabulletTimer.Count()){
            BulletSpawner.Instance.Spawn(spawnPos, rotation);
            isExtraBullet = false;
        }
        if (firerate.Count(false) && InputManager.Instance.OnShoot == 1){
            firerate.Reset();
            BulletSpawner.Instance.Spawn(spawnPos, rotation);
            if (Random.Range(1, 100) <= chance){
                isExtraBullet = true;
            }
        }
        
    }
}
