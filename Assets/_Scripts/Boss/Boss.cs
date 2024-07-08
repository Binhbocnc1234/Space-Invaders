using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class Boss : MonoBehaviour, IBossActions 
{

    [SerializeField] protected GameObject Main_Target;
    private Vector3 targetPosition;

    [SerializeField] protected float attackCooldownTime = 2f; 
    protected float lastAttackTime;

    bool check = false;

    
    void OnEnable(){
        targetPosition = transform.position;
    }
    void Update(){
        Move();
        if(check && Time.time >= lastAttackTime + attackCooldownTime){
            Attack();
        }

    }
    public virtual void Move(){
        if (Main_Target != null){
            float distance = Vector3.Distance(transform.position, Main_Target.transform.position);
            if (distance > 50f){   
                targetPosition = Vector3.MoveTowards(transform.position, Main_Target.transform.position, 10f * Time.deltaTime);
            }


            targetPosition.y = Mathf.Sin(Time.time); // between (-1,1)  Mathf.Sim(t * Speed) * Amplitude

            transform.position = targetPosition;

            if(distance <= 50f){
                check = true;
            }

        }
    } 

    public virtual void Attack(){
        Debug.Log("Attack");
    }

}
