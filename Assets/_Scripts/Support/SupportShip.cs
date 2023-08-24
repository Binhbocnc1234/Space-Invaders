using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SupportShip : MonoBehaviour {
    //
    private bool check = false;

    // for RayCast type line follow followPoint
    public GameObject followPoint1, followPoint2;
    public GameObject supportShip;
    public GameObject RayOb; // start raycast point

    // about Distance : TargetDistance ( distance between spS and MS ), AllowedDistance ( finally distance )
    [HideInInspector] public float TargetDistance;
    public float AllowedDistance = 0.2f;
    [HideInInspector] public float followSpeed;

    // length of raycast lazer
    [SerializeField] float obstacleRayDistance;



    // for RayCast type arc attack enemy
    public GameObject RayOb2;
    [HideInInspector] public float radius = 5f;
    [HideInInspector] public float startAngle = -45f;      // arc degree
    [HideInInspector] public float endAngle = 45f;         // arc degree
    [HideInInspector] public int segments = 30;


    public Vector2 Get(){
       float a = (followPoint1.transform.position - supportShip.transform.position).sqrMagnitude;
       float b = (followPoint2.transform.position - supportShip.transform.position).sqrMagnitude;
       if(a > b){
         return (followPoint2.transform.position - supportShip.transform.position);
       }
       else{
        return (followPoint1.transform.position - supportShip.transform.position);
       }
    }


    void Update(){
       // Line raycast
        Vector2 direction = Get();
        supportShip.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        TargetDistance = Vector2.Distance(supportShip.transform.position, direction + (Vector2)supportShip.transform.position);
    
        RaycastHit2D hitObstacle =  Physics2D.Raycast(RayOb.transform.position, direction , obstacleRayDistance);
        if (hitObstacle.collider != null && check == false){
            if(TargetDistance >= AllowedDistance){
                followSpeed = 0.09f;
                transform.position = Vector2.MoveTowards(transform.position, hitObstacle.collider.transform.position,followSpeed);
                Debug.DrawRay(RayOb.transform.position, direction * hitObstacle.distance, Color.red);   
            }
            else{
                followSpeed = 0;
            }
        }
        
        // arc RayCast
        float step = (endAngle - startAngle) / segments;
        for (int i = 0; i <= segments; i++)
        {
            float angle = startAngle + step * i;
            Vector2 dir = Quaternion.Euler(0, 0, angle) * RayOb2.transform.up;
            RaycastHit2D hit = Physics2D.Raycast(RayOb2.transform.position, dir, radius);

            if (hit.collider != null && hit.collider.GetComponent<Entity>().team == Team.Enemy)
            {
               check = true;
               followSpeed = 0.02f;
               if((transform.position - hit.collider.transform.position).sqrMagnitude >= 0.3f){
                 followSpeed = 0;
               }
               transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position,followSpeed); 
            }

            if(hit.collider != null && hit.collider.GetComponent<Entity>().team == Team.Player && check == false){
               followSpeed = 0.09f;
               transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position,followSpeed); 
            } 
        }       

    }


    // Draw
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float startAngleRad = startAngle * Mathf.Deg2Rad;
        float endAngleRad = endAngle * Mathf.Deg2Rad;

        Vector3 startDir = Quaternion.Euler(0, 0, startAngle) * RayOb2.transform.up;
        Vector3 endDir = Quaternion.Euler(0, 0, endAngle) * RayOb2.transform.up;

        Handles.color = Color.red;
        Handles.DrawWireArc(RayOb2.transform.position, Vector3.forward, startDir, endAngle - startAngle, radius);

        Handles.color = Color.white;
        Handles.DrawLine(RayOb2.transform.position, RayOb2.transform.position + startDir * radius);
        Handles.DrawLine(RayOb2.transform.position, RayOb2.transform.position + endDir * radius);
    }
    #endif









    
}
