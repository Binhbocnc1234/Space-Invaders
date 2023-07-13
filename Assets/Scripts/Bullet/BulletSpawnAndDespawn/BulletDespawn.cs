using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    
    public override void DespawnObject()
    {
        // this.transform.position = Playership.Instance.transform.position; // cay vc :)))
        BulletSpawner.Instance.Despawn(transform);    
    }
    
}
