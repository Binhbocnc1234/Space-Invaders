using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ShipModule : MonoBehaviour
{
    [Header("References")]
    public Block block;
    protected ShipComponent shipComponent;
    public GameObject cellUI;
    public SortingGroup sortingGroup;
    public Transform towerContainer;
    protected MotherShip motherShip;
    [HideInInspector] public bool haveBaseIn = false;
    [HideInInspector] public int i{get; private set;}
    [HideInInspector] public int j{get; private set;}
    protected void Awake(){
        motherShip = MotherShip.Instance;
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
        motherShip.DestroyDisjointed();
    }
    public void SetPosition(int i, int j){
        this.i = i;
        this.j = j;
        sortingGroup.sortingOrder = motherShip.hei - i;
        gameObject.name = $"Module ({i}, {j})";
        GetComponent<HarmonicOscillation>().original = this.transform.position;
    }
    public void SetComponent(ShipComponentSO so){
        foreach(Transform child in towerContainer){
            ShipComponent com = child.GetComponent<ShipComponent>();
            if (com.shipComponentSO.itemCode == so.itemCode){
                ShipComponent newCom = Instantiate(com, this.transform.position, this.transform.rotation, transform);
                newCom.gameObject.SetActive(true);
                shipComponent = newCom;

            }
        }
    }
    public void SetBlock(BlockSO so){
        block.SetBlock(so);
    }

}
