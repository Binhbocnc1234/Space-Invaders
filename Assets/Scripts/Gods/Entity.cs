using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{
    public string team;
    public string entityName;
    public int mainHealth;[HideInInspector] public int health;
    public int mainArmor; [HideInInspector] public int armor;
    [HideInInspector] public float immuneRate; //range from 0 to 1
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
        if (immuneRate == 1){
            spriteRenderer.material.color = Color.yellow;
        }
        else{
            spriteRenderer.material.color = Color.white;
        }
    }
    public virtual bool GetDamage(int amount){
        health -= (int)(amount*(600.0f/(600.0f+armor))*(1 - immuneRate));
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
    protected virtual void Destroy(){
        Destroy(this.gameObject);
    }
    protected virtual void Reset(){
        health = mainHealth;
        armor = 0;
    }

}
