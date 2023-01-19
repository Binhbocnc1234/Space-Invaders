using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : ObjectMove
{
  protected override void ResetValue(){
    base.ResetValue();
    this.MoveSpeed = 3f;
    this.direction = Vector3.down;
  }  

  protected override void Move(){
    transform.Translate(this.direction * this.MoveSpeed * Time.deltaTime); 
  }
}
