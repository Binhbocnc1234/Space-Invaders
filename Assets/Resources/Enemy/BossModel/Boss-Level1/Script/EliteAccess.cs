using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteAccess : MonoBehaviour
{
    // for elite float point only
    public List<Transform> Target = new List<Transform>();
    public Transform motherShip;

    public GameObject bulletPrefab;

    public Transform Center;

    //
    private Vector3 startPosition;
    private Vector3 targetPosition;


    protected float moveTime = 0.5f;
    protected float timer = 0f;


    protected bool isMoving = true;

    
    protected void Moving(){

        if(isMoving){
            float t = timer/moveTime;
        
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if(timer >= 0.65f){
                startPosition = targetPosition;
                CalculateNewTargetPosition();
                timer = 0f;
            }


        }
    }

    protected IEnumerator Attack(){
        while(true){
            isMoving = false;

            foreach(Transform child in motherShip){
                GameObject c = child.Find("Block").gameObject;
                if(Target.Contains(c.transform)){
                    continue;
                }
                else if(c.activeSelf){
                    Target.Add(c.transform);
                }
            }

            if(Target.Count == 0){
                isMoving = true;
            }
            else{

                Transform closestTransform = null;
                float closestDistance = float.MaxValue;


                foreach(Transform obj in Target){
                    float distance = Vector3.Distance(transform.position, obj.position);
                    if (distance < closestDistance)
                    {   
                        closestDistance = distance;
                        closestTransform = obj;
                    }
                }


                // Shooting 

                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                 // Xác định hướng của đạn
                Vector3 direction = (closestTransform.position - transform.position).normalized;

                // Thêm lực để đạn bay đi theo hướng đã tính
                float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            

                Invoke("Change", 0.5f);
            }


            
            yield return new WaitForSeconds(2f);
        }

        
    }

    protected void Start(){
        motherShip = MotherShip.Instance.moduleHolder;
        startPosition = transform.position;
        CalculateNewTargetPosition();

        StartCoroutine(Attack());
    }

    private void Update(){
        Moving();
    }

    private void CalculateNewTargetPosition()
    {
        // Tính toán góc ngẫu nhiên trong đoạn từ 0 đến 2π
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        // Tính toán vị trí đích mới dựa trên góc ngẫu nhiên và khoảng cách di chuyển
        float x = Center.position.x + 4f * Mathf.Cos(randomAngle); // 4f : radius
        float y = Center.position.y + 4f * Mathf.Sin(randomAngle);
        float z = Center.position.z;

        targetPosition = new Vector3(x, y, z);
    }

    protected void Change(){
        isMoving = true;
    }



}
