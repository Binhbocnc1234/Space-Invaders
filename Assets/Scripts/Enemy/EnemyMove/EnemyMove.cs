using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class EnemyMove : CurvyMove, ITemp
{
  protected EnemyDD dd;
  

  protected override void ResetValue(){
    this.dd = GetComponentInChildren<EnemyDD>();
    this.MoveSpeed = 3f;
    this.TypeMove = dd.enemy.typeMove;
    // this.TypeMove = wave.Orbit[this.wave.wave].GetComponent<SplineComputer>();
  }  

  protected override void Move(){
    SplineFollower follower = GetComponent<SplineFollower>();
    follower.followSpeed = MoveSpeed;
    follower.spline = TypeMove;
    
  }
}
