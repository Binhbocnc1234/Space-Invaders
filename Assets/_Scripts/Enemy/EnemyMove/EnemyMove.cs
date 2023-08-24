using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class EnemyMove : CurvyMove, ITemp
{

  protected override void ResetValue(){
    this.MoveSpeed = 3f;
    // this.TypeMove = dd.enemy.typeMove;
    // this.TypeMove = Wave.Instance.Orbit[Wave.Instance.wave].GetComponent<SplineComputer>();
  }  

  protected override void Move(){
    SplineFollower follower = GetComponent<SplineFollower>();
    follower.followSpeed = MoveSpeed;
    follower.spline = TypeMove;
  }
}
