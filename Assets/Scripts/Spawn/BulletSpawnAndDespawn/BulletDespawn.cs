using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
        transform.parent.GetChild(0).position = Playership.Instance.transform.position;
    }
}
