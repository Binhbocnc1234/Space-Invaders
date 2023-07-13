using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShipModule : MonoBehaviour
{
    [Header("References")]
    public Block block;
    public ShipComponent shipComponent;
    public GameObject cellUI;
    public SortingGroup sortingGroup;
    [HideInInspector] public bool haveBaseIn = false;
    [HideInInspector] public ShipComposite shipComposite;
    [HideInInspector] public int i{get; private set;}
    [HideInInspector] public int j{get; private set;}
    protected void Awake(){
        shipComposite = ShipComposite.Instance;
    }
    protected void Start(){
        
    }
    protected void Update(){
        if (block.gameObject.activeSelf && block.blockSO != null && block.entity.health == 0){
            Destroy();
        }
    }
    protected void Destroy(){
        gameObject.SetActive(false);
        block.gameObject.SetActive(false);
        shipComponent.gameObject.SetActive(false);
        shipComposite.DestroyDisjointed();
    }
    public void SetPosition(int i, int j){
        this.i = i;
        this.j = j;
        sortingGroup.sortingOrder = shipComposite.hei - i;
        gameObject.name = $"Module ({i}, {j})";
    }

}
