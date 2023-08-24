using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float moveSpeed;
    protected virtual void Update(){
        transform.Translate(Vector3.up*moveSpeed*Time.deltaTime); 
    }

    
}
