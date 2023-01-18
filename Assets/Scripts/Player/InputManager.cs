using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   // singleton
   protected static InputManager instance;

   public static InputManager Instance {get => instance;}

   private void Awake(){
     InputManager.instance = this;
   }


   // GetMousePos
   [SerializeField] protected Vector3 MousePos;
   public Vector3 MousePosition{get => MousePos;}


   [SerializeField] protected float onShoot;
   public float OnShoot{get => onShoot;}
   

  

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
}
