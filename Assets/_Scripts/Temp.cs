using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITemp
{
  protected virtual void Reset(){
    this.ResetValue();
    this.LoadComponents();
   }


   protected virtual void ResetValue(){
   }

   

   
   protected virtual void LoadComponents(){
   }
}
