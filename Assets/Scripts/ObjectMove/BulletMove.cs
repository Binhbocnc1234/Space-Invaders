   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : ObjectMove
{
   protected override void ResetValue(){
    base.ResetValue();
    this.MoveSpeed = 7f;
  }

  protected override void Move(){
    transform.Translate(this.direction * this.MoveSpeed * Time.deltaTime); 
  }
}
