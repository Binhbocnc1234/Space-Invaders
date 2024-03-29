using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public abstract class CurvyMove : MonoBehaviour, ITemp
{
  
     [SerializeField] protected float MoveSpeed = 4;

    protected Vector3 direction = Vector3.up;
    [SerializeField] protected SplineComputer TypeMove;


    // for zigzac only
    
    [HideInInspector]
     protected float frequency = 5f; // Speed of sine movement
    [HideInInspector]
     protected float magnitude = 5f; //  Size of sine movement


    // Update is called once per frame
    void Update()
    {
      // transform.parent.Translate(this.direction * this.MoveSpeed * Time.deltaTime);  
      Move();
    }


    protected abstract void Move();

    protected abstract void ResetValue();
}
