using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComposite : MonoBehaviour
{
    public int hei, wid;
    private ShipModule shipBase;
    public ShipModule[,] modules;
    public ShipModule emptyModule;
    private bool[,] visited;
    // Start is called before the first frame update
    void Start()
    {
        modules = new ShipModule[hei, wid];
        visited = new bool[hei,wid];
        for(int i = 0; i < hei; ++i){
            for (int j = 0; j < wid; ++j){
                Vector3 position = this.transform.position;
                position.x += wid*1;
                position.y += hei*1;
                ShipModule module = Instantiate(emptyModule, position, transform.rotation, transform);
                module.i = i; module.j = j; module.shipComposite = this;
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
                    Destroy(modules[i, j]);
                }
                visited[i, j] = false;
            }
        }
        
    }
}
