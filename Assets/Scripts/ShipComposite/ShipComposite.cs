using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


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
    private ShipModule shipBase;
    public ShipModule[,] modules;
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
        modules = new ShipModule[hei, wid];
        visited = new bool[hei,wid];
        LoadFromData();
    }
    public void LoadFromData(){
        ShipCompositeData data = ShipCompositeInfo.Instance.usedComposite;
        for (int i = 0; i < hei; ++i){
            for (int j = 0; j < wid; ++j){
                Vector3 position = this.transform.position;
                position.x += wid*1;
                position.y += hei*1;
                ShipModule module = Instantiate(emptyModule, position, transform.rotation, transform);
                module.i = i; module.j = j; module.shipComposite = this;
                module.block.blockSO = ShipCompositeInfo.Instance.blockDict[data.grid[i, j].block];
                module.shipComponent.shipComponentSO = ShipCompositeInfo.Instance.componentDict[data.grid[i,j].com];
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
        if (modules[i, j] != null){
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
        SearchBase(shipBase.i, shipBase.j);
        for(int i = 0; i < hei; ++i){
            for(int j = 0; j < hei; ++j){
                if (visited[i, j] == false){
                    modules[i, j].gameObject.SetActive(false);
                }
                visited[i, j] = false;
            }
        }
        
    }
    /// <returns>True if the execution is successful, it means the Block must link with BaseBlock</returns>
    public bool SetBlock(BlockSO block, int i, int j){
        SearchBase(i, j);
        if (visited[shipBase.i, shipBase.j] == false){return false;}
        Array.Clear(visited, 0, visited.Length);
        modules[i, j].block.blockSO = block;
        modules[i, j].block.Reset();
        modules[i, j].gameObject.SetActive(true);
        return true;
    }
    /// <returns>True if the execution is successful, it means a Block has been placed in given place before. 
    /// If ComponentType is Energy, it must be placed behind the ShipComposite </returns>
    public bool SetComponent(ShipComponentSO component, int i, int j){
        if (modules[i, j].enabled == false){Debug.LogWarning("You must place Component on a Block!"); return false;}
        if (component.componentType == ComponentType.Engine && i == hei - 1 && modules[i, j].enabled == true){return false;}
        modules[i, j].shipComponent.shipComponentSO = component;
        modules[i, j].shipComponent.Reset();
        return true;
    }
    void ReCalculateArea(){
        area = wid*hei;
    }
}
