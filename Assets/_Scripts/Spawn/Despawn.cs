using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

    protected float disLimit = 20f;
    protected float distance = 0;
    protected Transform mainCam;
    
    protected virtual void FixedUpdate(){
        this.Despawning();
    }
   

    protected virtual void Despawning(){
        if(!this.CanDespawn()){return;}
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    {
        if(gameObject == null){
            MyDebug.Log("NOO");
        }
        Destroy(gameObject);
    }
    
    protected virtual bool CanDespawn(){
        // this.distance = Vector2.Distance(transform.position, this.mainCam.position);
        // if(this.distance > this.disLimit){
        //     return true;
        // }
        return false;
    }


    
}