using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class EliteComanderBoss : Boss
{

    public override void Move(){
        base.Move();

    } 

    public override void Attack(){
        base.Attack();
        lastAttackTime = Time.time;
        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
        }
    }

}
