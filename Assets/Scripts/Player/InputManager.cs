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
   private void Awake(){
     InputManager.instance = this;
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
}
