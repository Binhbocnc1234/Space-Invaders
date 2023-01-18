using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypergun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int level = 1;
    protected float damage;
    Timer firerate = new Timer(0.5f);
    protected int bulletNum = 1;
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
        bulletNum = level / 4 + 1;
        damage = (120 + 20*(level - 1))/ bulletNum;
    }
    void Shooting(){
        if (firerate.Count(false) && InputManager.Instance.OnShoot == 1){
            firerate.Reset();
            Vector3 spawnPos, offset; Quaternion rotation;
            for (int i = 1; i <= bulletNum; ++i){
                if (bulletNum % 2 == 0){
                    offset = new Vector3(0.01f*bulletNum/2, -0.01f*bulletNum/2, 0);
                    if (i % 2 == 1){offset.x *= -1;}
                }
                else{
                    offset = new Vector3(0.01f*(bulletNum + 1)/2, -0.01f*(bulletNum - 1)/2, 0);
                    if (i % 2 == 1){offset.x *= -1;}
                }
                spawnPos = Playership.Instance.transform.position + offset;
                rotation = Playership.Instance.transform.rotation;
                Transform newBullet = BulletSpawner.Instance.Spawn(spawnPos, rotation);
            }
        }
    }
}
