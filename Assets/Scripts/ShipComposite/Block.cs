using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockSO blockSO;
    [HideInInspector] public Entity entity;
    protected void Start(){
        entity = GetComponent<Entity>();
        Reset();
    }
    public void Reset(){
        entity.mainHealth = entity.health = blockSO.mainHealth;
        entity.armor = blockSO.armor;
        GetComponent<SpriteRenderer>().sprite = blockSO.texture;
    }

}
