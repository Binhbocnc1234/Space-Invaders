using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLockMove : BulletMove
{
    public Transform target;
    protected override void Update(){
        transform.LookAt(target.position);
        base.Update();
    }
    
}
