using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playership : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> skinShip;
    public int usedSkinShip;
    public float mainhealth = 1000, health = 1000;
    protected static Playership instance;
    public static Playership Instance{get => instance;}
    [HideInInspector] int usedGun = 1;

    // Ship position
    public Vector3 ship_pos;
    

    void Start()
    {
        instance = this;
        // ship_pos = this.transform.Find("The dawn").position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other){

    }
}
