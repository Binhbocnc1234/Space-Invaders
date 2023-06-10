using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class EnemyMove : ObjectMove
{
  protected DamageReceive damageReceive;
  

  protected override void ResetValue(){
    base.ResetValue();
    this.damageReceive = GetComponentInChildren<DamageReceive>();
    this.MoveSpeed = 3f;
    this.TypeMove = damageReceive.enemy.typeMove;
    // this.TypeMove = wave.Orbit[this.wave.wave].GetComponent<SplineComputer>();
  }  

  protected override void Move(){
    SplineFollower follower = GetComponent<SplineFollower>();
    follower.followSpeed = MoveSpeed;
    follower.spline = TypeMove;
    
  }
}
