using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
  
    [SerializeField] protected int MoveSpeed = 4;

    [SerializeField] protected Vector3 direction = Vector3.up;
    // Update is called once per frame
    void Update()
    {
      transform.parent.Translate(this.direction * this.MoveSpeed * Time.deltaTime);  
    }
}
