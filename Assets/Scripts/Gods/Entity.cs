using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all lives in game, they have a property called "health", they can die. 
/// For instance, Players, Enemies, ShipModules
/// </summary>
public class Entity : MonoBehaviour{
    public string team;
    public string entityName;
    public int mainHealth;[HideInInspector] public int health;
    [HideInInspector] public int armor;
    //References to other components
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    new protected Rigidbody2D rigidbody;
    new protected Collider2D collider2D;
    protected virtual void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        health = mainHealth;
    }
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update(){
        
    }
    /// <summary>
    /// Entity's health is deducted by amount. Armor can help Entity takes less damage than theoretical damage
    /// </summary>
    /// <returns> True if Entity'health is equal to zero after receive damage </returns>
    public virtual bool GetDamage(int amount){
        health -= (int)(amount*(600.0f/(600.0f+armor)));
        if (health <= 0){
            health = 0;
            return true;
        }
        return false;
    }
    public virtual void GetHealth(int amount){
        health += amount;
        health = Mathf.Min(health, mainHealth);
    }
    public virtual void SwitchAnim(string name = "Idle"){
        animator.Play(name);
    }
    protected virtual void Reset(){
        health = mainHealth;
    }

}
