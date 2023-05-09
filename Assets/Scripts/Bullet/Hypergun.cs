using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypergun : Temp
{
    // Start is called before the first frame update
    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner { get => bulletSpawner; }

    [SerializeField] protected BulletMove bulletMove;
    public BulletMove BulletMove { get => bulletMove; }


    


    [SerializeField] protected int level = 1;
    protected float damage = 120;//base damage;
    Timer firerate = new Timer(0.5f);
    protected int bulletNum = 1;
    


    protected virtual void LoadBulletSpawner(){
    if(this.bulletSpawner != null){return;}
    this.bulletSpawner = Transform.FindObjectOfType<BulletSpawner>();
    }

    protected virtual void LoadBulletMove(){
     if(this.bulletMove != null){return;}
     this.bulletMove = Transform.FindObjectOfType<BulletMove>();
    }


   protected override void LoadComponents(){
     base.LoadComponents();
     this.LoadBulletSpawner();
     this.LoadBulletMove();
     
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
        if (firerate.Count(false) && InputManager.Instance.OnShoot == 1 && ShipMov.Instance.isResetting == true){
            
            firerate.Reset();
            // offset : distance between new and previous bullet 
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
                List<Transform> LBulletType = BulletSpawner.BulletType;
                Transform newBullet = BulletSpawner.Spawn(BulletSpawner.BulletType[0], spawnPos, rotation);
                newBullet.GetChild(0).gameObject.SetActive(true);
                
            }
        }
    }
}
