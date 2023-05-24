using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZMove : ObjectMove
{

   [SerializeField] protected Vector3 pos;
   [SerializeField] protected Vector3 axis;


   protected override void ResetValue(){
    base.ResetValue();
    this.MoveSpeed = 1f;
    this.direction = Vector3.down;
    this.frequency = 2f;
    this.magnitude = 5f;
  }  

     
 
   private void Awake()
     {
         this.pos = transform.position;
         this.axis = transform.right;
 
     }
 
  
   protected override void Move(){
    pos += Vector3.down * Time.deltaTime * MoveSpeed;
    transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
  }
}
