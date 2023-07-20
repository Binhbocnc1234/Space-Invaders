using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


///<summary>
/// <para> A Singleton class used as guide for placing towers/blocks. </para>
/// <para> Methods: SelectModule, SetModule, TrySetModule</para>
///</summary>
public class MotherShipUI : MonoBehaviour
{
    protected static MotherShipUI instance;
    public static MotherShipUI Instance{get => instance;}
    public Sprite[] rarityFrame;
    private MotherShip motherShip;
    public Transform pointer;
    public Transform placingBan;
    public Transform module;
    public PopUp popup;
    bool holding = false;
    ItemProfileSO itemProfile;
    void Awake(){
        if (instance == null){instance = this;}
        else{MyDebug.LogSingleton();}
    }
    void Start(){
        motherShip = MotherShip.Instance;
    }
    void Update(){
        
        if (holding){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            pointer.position = mousePos; 
            module.position = mousePos;
            // if (TrySetModule()){
            //     placingBan.gameObject.SetActive(true);
            //     placingBan.position = mousePos;
            // }
            // else{
            //     placingBan.gameObject.SetActive(false);
            // }
            if (Input.GetMouseButtonDown(0)){
                SetModule();
            }
        }
        
        
    }
    /// <summary> Make Player hold a tower/block and be ready to place it </summary> 
    public void SelectModule(ItemProfileSO itemProfileSO){
        holding = true;
        itemProfile = itemProfileSO;
        module.GetChild(0).GetComponent<SpriteRenderer>().sprite = itemProfileSO.sprite;
        pointer.gameObject.SetActive(true);
        module.gameObject.SetActive(true);
        placingBan.gameObject.SetActive(true);
    }
    /// <summary>Place the tower/block in the cell where the mouse pointer is in</summary>
    public void SetModule(){
        holding = false;
        pointer.gameObject.SetActive(false);
        module.gameObject.SetActive(false);
        placingBan.gameObject.SetActive(false);
        Vector2Int pos = WorldPointToShipPos();
        ShipMessage mes = ShipMessage.NotSuccess;
        if (itemProfile.itemType == ItemType.Block){
            mes = motherShip.SetBlock((BlockSO)itemProfile, pos.x, pos.y); 
        }
        else if (itemProfile.itemType == ItemType.Component){
            mes = motherShip.SetComponent((ShipComponentSO)itemProfile, pos.x, pos.y);
        }
        Debug.Log(SystemExtension.GetMousePos());
        popup.GetComponent<PopUp>().SetMessage(ShipMessageString.messageDict[mes], SystemExtension.GetMousePos() + new Vector3(0, 1, 0));
    }
    /// <summary> Return True if Player can put his tower/block in the location where the pointer is in. Otherwise, return False</summary>
    public ShipMessage TrySetModule(){
        Vector2Int pos = WorldPointToShipPos();
        if (itemProfile.itemType == ItemType.Block){
            return motherShip.TrySetBlock((BlockSO)itemProfile, pos.x, pos.y); 
        }
        else{
            return motherShip.TrySetComponent((ShipComponentSO)itemProfile, pos.x, pos.y);
        }
    }
    Vector2Int WorldPointToShipPos(){
        Vector2 diff = SystemExtension.GetMousePos() - motherShip.transform.position;
        return new Vector2Int((int)diff.y, (int)diff.x);
    }

}
