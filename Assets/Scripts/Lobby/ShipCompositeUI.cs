using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCompositeUI : MonoBehaviour
{
    private ShipComposite shipComposite;
    public Transform moduleList;
    public Transform slot;
    
    void Awake(){
        shipComposite = ShipComposite.Instance;

    }
    void Start(){
        int index = 0;
        foreach(Transform child in moduleList){
            Destroy(child);
        }
        for (int i = 0; i < shipComposite.hei; ++i){
            for(int j = 0; j < shipComposite.wid; ++j){
                ShipModuleUI moduleUI = Instantiate(slot, moduleList).GetComponent<ShipModuleUI>();
                moduleUI.shipModule = shipComposite.modules[i, j];
                ++index;
            }
        }
    }
}
