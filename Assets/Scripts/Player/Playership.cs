using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playership : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> skinShip;
    public int usedSkinShip;
    public float health = 100;
    protected static Playership instance;
    public static Playership Instance{get => instance;}
    [HideInInspector] int usedGun = 1;
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){

    }
}
