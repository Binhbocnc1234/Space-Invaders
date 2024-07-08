using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;
#endif



public enum ShipMessage{
    Success,
    NotSuccess,
    OutOfArray,
    InBase,
    NotConnectToBase,
    FullHealth,
    NoBlockBelow
}
/// <summary>
/// A message appears in screen when you place a Block or Tower. The messages are Success, Out of Array, In Base, NotConnectToBase, NoBlockBelow
/// </summary>
public static class ShipMessageString{
    public static Dictionary<ShipMessage, string> messageDict = new Dictionary<ShipMessage, string>(){
        {ShipMessage.Success, "Placing success"},
        {ShipMessage.OutOfArray, "You have reached the limit of building grid"},
        {ShipMessage.InBase, "You cannot place anything in Base"},
        {ShipMessage.NotConnectToBase, "You should place Blocks that connect to Base"},
        {ShipMessage.NoBlockBelow, "If you want to place a Component, place a Block below first"},
    };
}
/// <summary>
/// Singleton class. Store data and control MotherShip in a battle. Positions of Modules is relative to Mothership's position
/// </summary>
public class MotherShip : MonoBehaviour
{
    protected static MotherShip instance;
    public static MotherShip Instance{get => instance;}
    public BlockSO stone; public ShipComponentSO tower;
    public Transform moduleHolder;
    protected int _hei;
    public int hei{
        get{return _hei;}
        set{_hei = value; ReCalculateArea();}
    }
    protected int _wid;
    public int wid{
        get{return _wid;}
        set{_wid = value; ReCalculateArea();}
    }
    public int area;
    public ShipBase shipBase;
    [HideInInspector] public int base_i, base_j;
    public ShipModule[,] modules = new ShipModule[10, 10];
    public ShipModule emptyModule;
    private bool[,] visited;
    // Start is called before the first frame update
    void Awake(){
        if (instance != null){MyDebug.LogSingleton();}
        else{instance = this;}
    }
    void Start()
    {
        ReCalculateArea();
        modules = new ShipModule[10, 10];
        CreateEmpty(6, 6);
        visited = new bool[hei,wid];
        // LoadFromData();
    }
    /// <summary>
    /// Clear previous Block and Tower and create new array of Modules
    /// </summary>
    /// <param name="hei"></param>
    /// <param name="wid"></param>
    /// <param name="block"></param>
    /// <param name="com"></param>
    public void CreateEmpty(int hei, int wid, BlockSO block = null, ShipComponentSO com = null){
        //ClearPreviousData
        foreach(Transform child in moduleHolder){
            DestroyImmediate(child.gameObject);
        }
        //Set Width and height
        this.hei = hei;
        this.wid = wid;
        //ShipBase
        shipBase.SetPosition(hei/2-1, wid/2-1);
        //Setup for Modules
        bool haveBase = false;
        for (int i = 0; i < hei; ++i){
            for (int j = 0; j < wid; ++j){
                Vector3 position = this.transform.position;
                position.x += j + 0.5f;
                position.y += i + 0.5f;
                ShipModule module = Instantiate(emptyModule, position, transform.rotation, moduleHolder);
                modules[i, j] = module;
                module.gameObject.SetActive(true);
                module.SetPosition(i, j); 
                if (i == base_i && j == base_j && haveBase == false){
                    haveBase = true;
                }
                if ((i == base_i + 1 && j == base_j) || (i == base_i+1 && j == base_j+1) || 
                (i == base_i && j == base_j + 1) || (i == base_i && j == base_j)){
                    module.haveBaseIn = true;
                }
                else{
                    if (block != null){
                        module.SetBlock(block);
                    }
                    if(com != null){module.SetComponent(com);}
                }
            }
        }
    }
    public void LoadFromData(){
        ShipCompositeData data = ShipCompositeInfo.Instance.usedComposite;
        for (int i = 0; i < hei; ++i){
            for (int j = 0; j < wid; ++j){
                
                Vector3 position = this.transform.position;
                position.x += wid*1;
                position.y += hei*1;
                ShipModule module = Instantiate(emptyModule, position, transform.rotation, transform);
                module.SetPosition(i, j);
                // module.block.SetBlock(data.grid[i,j].block);
                // module.shipComponent.SetComponent();
            
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Use depth-first search(DFS) to check if there's way to go from BaseModule to each ShipModule
    /// </summary>
    /// <returns> Void. Result of implementation is stored in array "visited" </returns>
    void SearchBase(int i, int j){
        if (IsOutOfArray(i, j)){return;}
        if (modules[i, j].block.gameObject.activeSelf){
            visited[i, j] = true;
            SearchBase(i+1, j);
            SearchBase(i-1, j);
            SearchBase(i, j+1);
            SearchBase(1, j-1);
        }
    }
    /// <summary>
    /// Destroy discrete ShipModules. There is no way to go from BaseModule to those ShipModules
    /// </summary>
    /// <returns>Void</returns>
    public void DestroyDisjointed(){
        SearchBase(base_i, base_j);
        for(int i = 0; i < hei; ++i){
            for(int j = 0; j < wid; ++j){
                if (visited[i, j] == false){
                    modules[i, j].gameObject.SetActive(false);
                }
                visited[i, j] = false;
            }
        }
        
    }
    /// <returns>True if the execution is successful, it means the Block must link with BaseBlock</returns>
    public ShipMessage SetBlock(BlockSO so, int i, int j, bool forceSet = false){
        ShipMessage mes = TrySetBlock(so, i, j);
        if (forceSet || mes == ShipMessage.Success){modules[i, j].SetBlock(so);}
        // MyDebug.Log($"Successfully placing Component at position ({i},{j})");
        return mes;
    }
    /// <returns>True if the execution is successful, it means a Block has been placed in given place before. 
    /// If ComponentType is Energy, it must be placed behind the ShipComposite </returns>
    public ShipMessage SetComponent(ShipComponentSO so, int i, int j, bool forceSet = false){
        ShipMessage mes = TrySetComponent(so, i, j);
        if (forceSet || mes == ShipMessage.Success){modules[i, j].SetComponent(so);}
        // MyDebug.Log($"Successfully placing Component at position ({i},{j})");
        return mes;
    }
    public bool RemoveComponent(int i, int j){
        if (IsOutOfArray(i, j)){return false;}
        return true;
    }
    public ShipMessage TrySetComponent(ShipComponentSO component, int i, int j){
        if (IsOutOfArray(i, j)){return ShipMessage.OutOfArray;}
        if (modules[i, j].block.gameObject.activeSelf == false){return ShipMessage.NoBlockBelow;}
        return ShipMessage.Success;
    }
    /// <returns>True if the execution is successful, it means the Block must link with BaseBlock</returns>
    public ShipMessage TrySetBlock(BlockSO block, int i, int j){
        if (IsOutOfArray(i, j)){return ShipMessage.OutOfArray;}
        if (modules[i,j].haveBaseIn){return ShipMessage.InBase;}
        if (!IsBlockActive(i,j-1) && !IsBlockActive(i, j+1) && !IsBlockActive(i-1,j) && !IsBlockActive(i+1,j)){
            return ShipMessage.NotConnectToBase;
        }
        return ShipMessage.Success;
    }
    bool IsOutOfArray(int i, int j){
        return i >= hei || j >= wid || i < 0 || j < 0;
    }
    bool IsBlockActive(int i, int j){
        return !IsOutOfArray(i, j) && 
        (modules[i, j].block.gameObject.activeSelf || 
        modules[i, j].haveBaseIn);}
    /// <summary>
    /// Set area = width*height
    /// </summary>
    void ReCalculateArea(){
        area = wid*hei;
    }
    
}

#if UNITY_EDITOR
[CustomEditor(typeof(MotherShip))]
public class ShipCompositeEditor : Editor{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MotherShip motherShip = (MotherShip)target;
        if (GUILayout.Button("Generate Module")){
            motherShip.CreateEmpty(6,6, motherShip.stone);
        }
    }
}
#endif