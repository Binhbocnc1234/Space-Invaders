using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   // singleton
  protected static InputManager instance;
  public static InputManager Instance {get => instance;}
   // GetMousePos
   [HideInInspector] protected Vector3 MousePos;
   [HideInInspector] public Vector3 MousePosition{get => MousePos;}

   [SerializeField] protected float onShoot;
   [HideInInspector] public float OnShoot{get => onShoot;}

   public float startTime = 0f, endTime = 0f;
   private void Awake(){
      if (InputManager.instance != null){
        MyDebug.LogSingleton();
      }
      else{
        InputManager.instance = this;
      }
  }


   void Update(){
     this.GetMouseDown();
     this.GetMousePos();
   }


   protected virtual void GetMouseDown(){
     this.onShoot = Input.GetAxis("Fire1");
   }

   protected virtual void GetMousePos(){
     this.MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   }

   public virtual bool CheckMouse(){
     if(Input.GetMouseButtonDown(0)){
      startTime = Time.time;  
     }
     if(Input.GetMouseButtonUp(0)){
       endTime = Time.time;
     }

     if(endTime - startTime > 0.5f){
        return true;
     }
     return false;
   }
}
