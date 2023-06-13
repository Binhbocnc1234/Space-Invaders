using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour, IMove
{
    public float moveSpeed;
    void Start(){

    }
    void Update(){
        Move();
    }
    public void Move(){
        transform.Translate(Vector3.up*moveSpeed*Time.deltaTime); 
    }
    
}
