using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


/// <summary>
/// Singleton class. Store data and control MotherShip in a battle. Positions of Modules is relative to Mothership's position
/// </summary>

public enum ShipMessage{
    Success,
    OutOfArray,
    InBase,
    NotConnectToBase,
    FullHealth,
    NoBlockBelow
}
public static class ShipMessageString{
    public static Dictionary<ShipMessage, string> message = new Dictionary<ShipMessage, string>(){
        {ShipMessage.Success, "Placing success"},
        {ShipMessage.OutOfArray, "You have reached the limit of building grid"},
        {ShipMessage.InBase, "You cannot place anything in Base"},
        {ShipMessage.NotConnectToBase, "You should place Blocks that connect to Base"},
        {ShipMessage.NoBlockBelow, "Place a Block below first"}
    };
}
public class ShipComposite : MonoBehaviour
{
    protected static ShipComposite instance;
    public static ShipComposite Instance{get => instance;}
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
    public Transform shipBase;
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
    public void CreateEmpty(int hei, int wid){
        this.hei = hei;
        this.wid = wid;
        base_i = hei/2; base_j = wid/2;
        bool haveBase = false;
        for (int i = 0; i < hei; ++i){
            for (int j = 0; j < wid; ++j){
                Vector3 position = this.transform.position;
                position.x += j + 0.5f;
                position.y += i + 0.5f;
                ShipModule module = Instantiate(emptyModule, position, transform.rotation, transform);
                modules[i, j] = module;
                module.gameObject.SetActive(true);
                module.SetPosition(i, j); 
                if (i + 1 == ((int)hei)/2 && j + 1 == ((int)wid)/2 && haveBase == false){
                    haveBase = true;
                    shipBase.position = position;
                }
                if ((i == base_i + 1 || j == base_j + 1) && i - base_i <= 1 && j - base_j <= 1){
                    module.haveBaseIn = true;
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
    /// Use depth-first search to check if there's way to go from BaseModule to each ShipModule
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
    public bool SetBlock(BlockSO so, int i, int j, bool forceSet = false){
        if (!forceSet && !TrySetBlock(so, i, j)){return false;}
        modules[i, j].block.SetBlock(so);
        MyDebug.Log($"Successfully placing Block at position ({i},{j})");
        return true;
    }
    /// <returns>True if the execution is successful, it means a Block has been placed in given place before. 
    /// If ComponentType is Energy, it must be placed behind the ShipComposite </returns>
    public bool SetComponent(ShipComponentSO so, int i, int j, bool forceSet = false){
        if (!forceSet && !TrySetComponent(so, i, j)){return false;}
        modules[i, j].shipComponent.SetComponent(so);
        MyDebug.Log($"Successfully placing Component at position ({i},{j})");
        return true;
    }
    public bool RemoveComponent(int i, int j){
        if (IsOutOfArray(i, j)){return false;}
        return true;
    }
    public bool TrySetComponent(ShipComponentSO component, int i, int j){
        if (IsOutOfArray(i, j)){return false;}
        if (modules[i, j].block.gameObject.activeSelf == false){Debug.LogWarning("You must place Component on a Block!"); return false;}
        if (component.componentType == ComponentType.Engine && i == hei - 1 && modules[i, j].enabled == true){return false;}
        return true;
    }
    /// <returns>True if the execution is successful, it means the Block must link with BaseBlock</returns>
    public bool TrySetBlock(BlockSO block, int i, int j){
        if (IsOutOfArray(i, j)){return false;}
        if (modules[i,j].haveBaseIn){return false;}
        SearchBase(i, j);
        if (visited[base_i, base_j] == false){return false;}
        Array.Clear(visited, 0, visited.Length);
        return true;
    }
    bool IsOutOfArray(int i, int j){
        return i >= hei || j >= wid || i < 0 || j < 0;
    }
    void ReCalculateArea(){
        area = wid*hei;
    }
}
