using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttack : MonoBehaviour{

    Transform moduleHolder;

    void Awake(){
        moduleHolder = GameObject.Find("ModuleHolder").transform;
    }
    // ind define as number represent EnemyType
    public IEnumerator Approach(int ind, float speed, int Dmg)
    {
        yield return new WaitForSeconds(0.5f);

        if (ind == 1){  

            Transform target = FindNearTarget();

            while (Vector3.Distance(transform.parent.position, target.position) > 1.25f){
                Vector3 direction = (target.position - transform.parent.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));


                transform.parent.position = Vector3.MoveTowards(transform.parent.position, target.position, speed * Time.deltaTime);

                yield return null;
            }

            StartCoroutine(Attack(ind, speed, Dmg, target));

        }
        else if (ind == 2)
        {
            // Code for action ind == 2
        }
    }

    public IEnumerator Attack(int ind, float speed, int Dmg, Transform target){
        bool check = true;
        while(check){
            // Wait to change action
            yield return new WaitForSeconds(0.5f);

            // Play your idle animation here

            // Wait for next attack action (thời gian chờ 3 giây)
            yield return new WaitForSeconds(1f);

            // Play attack animation here
            // Example:
            // anim.Play("Attack");

        
            Entity targetEntity = target.GetComponent<Entity>();
            if (targetEntity != null){
                targetEntity.GetDamage(Dmg);
            }

            if(targetEntity.health <= 0){
                check = false;
                StartCoroutine(Approach(ind, speed, Dmg));
            }
        }
        
    }


    public Transform FindNearTarget(){
        float minDistance = Mathf.Infinity; 
        Transform nearestTarget = null;
    
    
        for(int i = 0; i < moduleHolder.childCount; i++){
            Transform child = moduleHolder.GetChild(i); 
            Transform target = child.Find("Block");

            if (target != null){
                float distance = Vector3.Distance(transform.parent.position, target.position);

                if (distance < minDistance && target.gameObject.activeSelf){
                    minDistance = distance; 
                    nearestTarget = target; 
                }
            }
        }

        return nearestTarget; 
    }

}


