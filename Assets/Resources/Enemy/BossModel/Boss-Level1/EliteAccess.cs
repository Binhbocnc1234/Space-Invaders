using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteAccess : MonoBehaviour
{
    // for elite float point only
    private List<Transform> Target = new List<Transform>();
    public Transform motherShip;

    protected void Moving(){
        foreach(Transform child in motherShip){
            Target.Add(child);
        }

        

        


    }



}
