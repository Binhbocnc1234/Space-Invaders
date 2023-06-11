using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public abstract class ObjectMove : Temp
{
  
     [SerializeField] protected float MoveSpeed = 4;

    [SerializeField] protected Vector3 direction = Vector3.up;
    [SerializeField] protected SplineComputer TypeMove;


    // for zigzac only
     
     [SerializeField] protected float frequency = 5f; // Speed of sine movement
     [SerializeField] protected float magnitude = 5f; //  Size of sine movement



    // Update is called once per frame
    void Update()
    {
      // transform.parent.Translate(this.direction * this.MoveSpeed * Time.deltaTime);  
      Move();
    }


    protected abstract void Move();

    
}
