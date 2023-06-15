using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipModuleUI : MonoBehaviour
{
    [HideInInspector] public ShipModule shipModule;
    SpriteRenderer blockSprite, componentSprite;
    Image block;
    Image component;
    void Start(){
        blockSprite = shipModule.block.GetComponent<SpriteRenderer>();
        componentSprite = shipModule.shipComponent.GetComponent<SpriteRenderer>();
    }
    void Update(){
        block.sprite = blockSprite.sprite;
        component.sprite = componentSprite.sprite;
    }
    
}
