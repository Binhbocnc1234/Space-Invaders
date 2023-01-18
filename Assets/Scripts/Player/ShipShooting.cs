using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting;
    [SerializeField] protected Transform bulletPrefab;

    // Shoot timer and Shoot delay
    [SerializeField] protected float shootDelay = 0.8f;
    [SerializeField] protected float shootTimer = 0f;
    // Update is called once per frame
    void LateUpdate()
    {
      this.IsShooting();
      this.Shooting();
    }
    protected virtual void Shooting(){

        this.shootTimer += Time.fixedDeltaTime;
        if(this.shootTimer < this.shootDelay && !this.isShooting){return;}
        this.shootTimer = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform newBullet = BulletSpawner.Instance.Spawn(spawnPos, rotation);
        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting(){
        this.isShooting = InputManager.Instance.OnShoot == 1;
        return this.isShooting;
    }
}
