using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockSO chamberSO;
    [HideInInspector] public Entity entity;
    protected void Start(){
        GetComponent<SpriteRenderer>().sprite = chamberSO.texture;
        entity = GetComponent<Entity>();
    }

}
