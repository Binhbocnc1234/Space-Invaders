using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Transform mainCam;

    protected virtual void FixedUpdate(){
        this.Despawning();
    }
   

    protected virtual void Despawning(){
        if(!this.CanDespawn()){return;}
        Destroy(transform.gameObject);
    }


    
    protected virtual bool CanDespawn(){
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if(this.distance > this.disLimit) return true;
        return false;
    }


    
}