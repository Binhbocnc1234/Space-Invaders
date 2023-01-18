using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMov : MonoBehaviour
{
  [SerializeField] protected Vector3 worldPos;
  [SerializeField] protected float speed = 5.0f;

  void Start(){
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  
  void Update(){
    Cursor.lockState = CursorLockMode.Confined;
    this.worldPos = InputManager.Instance.MousePosition;
    this.worldPos.z = 0;
    this.Moving();
   

  }

  protected virtual void Moving(){
    Vector3 newPos = Vector3.Lerp(transform.position, worldPos, this.speed);
    transform.position = newPos;
  }
}
