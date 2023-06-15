using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypergun : Weapon, ITemp
{
    // Start is called before the first frame update
    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner { get => bulletSpawner; }

    [SerializeField] protected BulletMove bulletMove;
    public BulletMove BulletMove { get => bulletMove; }
    Timer firerate = new Timer(0.1f);
    protected int bulletNum = 1;
    public void Move(){

    }


    protected void LoadBulletSpawner(){
        if(this.bulletSpawner != null){return;}
        this.bulletSpawner = Transform.FindObjectOfType<BulletSpawner>();
    }

    protected virtual void LoadBulletMove(){
        if(this.bulletMove != null){return;}
        this.bulletMove = Transform.FindObjectOfType<BulletMove>();
    }


    protected virtual void LoadComponents(){
        this.LoadBulletSpawner();
        this.LoadBulletMove();
        
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }
    void Shooting(){
        if (InputManager.Instance.OnShoot == 1 && ShipMov.Instance.isResetting == true && firerate.Count(false)){
            
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
                Transform newBullet = BulletSpawner.Spawn(BulletSpawner.hyperGun, spawnPos, rotation);
                newBullet.gameObject.SetActive(true);
                
            }
        }
    }
}
