using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    private bool check = false;
    private bool han = false;


    public GameObject player;
    public float TargetDistance;
    public float AllowedDistance = 0.6f;
    public GameObject TheNPC;
    public GameObject player2;
    public float followSpeed;


    // 
    public GameObject RayOb;
    [SerializeField] float obstacleRayDistance;

    //
    public GameObject RayOb2;
    // public float radius = 10f;
    // public float startAngle = -45f;
    // public float endAngle = 45f;
    // public int segments = 30;



    

    public Vector2 Get(){
       float a = (player.transform.position - TheNPC.transform.position).sqrMagnitude;
       float b = (player2.transform.position - TheNPC.transform.position).sqrMagnitude;
       if(a > b){
         return (player2.transform.position - TheNPC.transform.position);
       }
       else{
        return (player.transform.position - TheNPC.transform.position);
       }
    }

    void Update(){
       
        // float step = (endAngle - startAngle) / segments;
        // for (int i = 0; i <= segments; i++)
        // {
        //     float angle = startAngle + step * i;
        //     Vector2 dir = Quaternion.Euler(0, 0, angle) * RayOb2.transform.up;
        //     RaycastHit2D hit = Physics2D.Raycast(RayOb2.transform.position, dir, radius);

        //     if (hit.collider != null && hit.collider.GetComponent<Entity>().team == "Enemy")
        //     {
        //        Debug.Log("NOOO");
        //        Vector2 di = hit.collider.transform.position - RayOb2.transform.position;
        //        RayOb2.transform.rotation = Quaternion.FromToRotation(Vector3.up, di);
               
        //        check = true;
        //        followSpeed = 0.5f;
        //        if((transform.position - hit.collider.transform.position).sqrMagnitude <= 12f){
        //          followSpeed = 0;
        //        }
        //        transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position,followSpeed * Time.deltaTime); 
        //     }

        //     else if(hit.collider != null && hit.collider.GetComponent<Entity>().team == "Ship" && check == false){
        //        followSpeed = 9f;
        //        transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position,followSpeed * Time.deltaTime); 
        //     }

        //     else if(hit.collider == null){
        //         Debug.Log("OK");
        //         check = false;
        //     } 

        // }


       
    //    if(!check){
    //     Vector2 direction = Get();
    //     if(!han){
    //         TheNPC.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    //     }
    //     TargetDistance = Vector2.Distance(TheNPC.transform.position, direction + (Vector2)TheNPC.transform.position);
        
    //     int layerMask = ~(1 << LayerMask.NameToLayer("NPC"));
    //     RaycastHit2D hitObstacle =  Physics2D.Raycast(RayOb.transform.position, direction , obstacleRayDistance, layerMask);
    //     if (hitObstacle.collider != null && check == false  && hitObstacle.collider.GetComponent<Entity>().team == "Ship"){
    //         if(TargetDistance >= AllowedDistance){
    //             han = false;
    //             TheNPC.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    //             followSpeed = 9f;
    //             transform.position = Vector2.MoveTowards(transform.position, hitObstacle.collider.transform.position,followSpeed * Time.deltaTime);
    //             Debug.DrawRay(RayOb.transform.position, direction * hitObstacle.distance, Color.red);   
    //         }
    //         else{
    //             Debug.Log("KAKA");
    //             han = true;
    //             followSpeed = 0;
    //             transform.rotation = Quaternion.identity;
    //         }
    //     }
    //    }

        if(!check){
           Vector2 direction = Get(); 
           if(!han){
            
           }
           TargetDistance = Vector2.Distance(TheNPC.transform.position, direction + (Vector2)TheNPC.transform.position);
            if(TargetDistance >= AllowedDistance){
                transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
                followSpeed = 9f;
                transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, followSpeed * Time.deltaTime);
                han = false;
            }
            else{
                Debug.Log("KAKA");
                han = true;
                followSpeed = 0;
                transform.rotation = Quaternion.identity;
            }

            

        }
    }

    void OnTriggerStay2D(Collider2D other){
        
        if(other.GetComponent<Entity>().team == Team.Enemy){
            han = false;
            Vector2 dir = (other.transform.position - transform.position ).normalized;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            check = true;
               followSpeed = 5f;
               if((transform.position - other.transform.position).sqrMagnitude <= 8f){
                 followSpeed = 0;
               }
               transform.position = Vector2.MoveTowards(transform.position, other.transform.position,followSpeed * Time.deltaTime);
        }
        
    }

     void OnTriggerExit2D(Collider2D other){
         check = false;
    }



    
    // #if UNITY_EDITOR
    // private void OnDrawGizmos()
    // {
    // //     float startAngleRad = startAngle * Mathf.Deg2Rad;
    // //     float endAngleRad = endAngle * Mathf.Deg2Rad;

    // //     Vector3 startDir = Quaternion.Euler(0, 0, startAngle) * RayOb2.transform.up;
    // //     Vector3 endDir = Quaternion.Euler(0, 0, endAngle) * RayOb2.transform.up;

    // //     Handles.color = Color.red;
    // //     Handles.DrawWireArc(RayOb2.transform.position, Vector3.forward, startDir, endAngle - startAngle, radius);

    // //     Handles.color = Color.white;
    // //     Handles.DrawLine(RayOb2.transform.position, RayOb2.transform.position + startDir * radius);
    // //     Handles.DrawLine(RayOb2.transform.position, RayOb2.transform.position + endDir * radius);
    // }
    // #endif


}
