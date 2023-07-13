using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Block : MonoBehaviour
{
    public BlockSO blockSO;
    public Entity entity;
    public SpriteRenderer spriteRenderer;
    void Awake(){
        entity = GetComponent<Entity>();
    }
    public virtual void SetBlock(BlockSO so){

        blockSO = so;
        MyDebug.Log(entity);
        entity.SetHealth(so.mainHealth);
        entity.mainHealth = entity.health = blockSO.mainHealth;
        entity.armor = blockSO.armor;
        spriteRenderer.sprite = blockSO.sprite;
        this.gameObject.SetActive(true);
    }
    // public virtual bool IsActive(){

    // }

}
