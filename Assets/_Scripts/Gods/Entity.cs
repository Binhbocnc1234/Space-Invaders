using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Base class for all lives in game, they have a property called "health", they can die. 
/// For instance, Players, Enemies, ShipModules
/// </summary>

public enum Team{
    Player,
    Enemy,
}
public class Entity : MonoBehaviour{
    public Team team;
    public string entityName;
    public float mainHealth;[HideInInspector] public float health = -1;
    [HideInInspector] public int armor;
    //References to other components
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    new protected Rigidbody2D rigidbody;
    new protected Collider2D collider2D;


    // Action
    public Action OnDead;
    protected virtual void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    protected virtual void Start()
    {
        this.Reset();
    }

    // Update is called once per frame
    protected virtual void Update(){
        
    }
    /// <summary>
    /// Entity's health is deducted by amount. Armor can help Entity takes less damage than theoretical damage
    /// </summary>
    /// <returns> True if Entity'health is equal to zero after receive damage </returns>
    public virtual bool GetDamage(float amount){
        health -= (int)(amount*(600.0f/(600.0f+armor)));
        Debug.Log(health);
        return this.health <= 0;
    }

    public virtual void GetHealth(float amount){
        health += amount;
        health = Mathf.Min(health, mainHealth);
    }


    public virtual void SwitchAnim(string name = "Idle"){
        animator.Play(name);
    }
    public virtual void SetHealth(int amount){
        health = mainHealth = amount;
    }
    protected virtual void Reset(){
        health = mainHealth;
    }
    protected virtual bool IsDead(){
        return health == 0;
    }


}
