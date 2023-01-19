using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    protected virtual void Reset(){
     this.ResetValue();
     this.LoadComponents();
   }


   protected virtual void ResetValue(){
     // For override
   }

   

   
   protected virtual void LoadComponents(){
     // For override
   }
}
