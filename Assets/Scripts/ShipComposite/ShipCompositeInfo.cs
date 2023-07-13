using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCompositeInfo : MonoBehaviour
{
    protected static ShipCompositeInfo instance;
    public static ShipCompositeInfo Instance;
    public Dictionary<BlockCode, BlockSO> blockDict = new Dictionary<BlockCode, BlockSO>();
    public Dictionary<ComponentCode, ShipComponentSO> componentDict = new Dictionary<ComponentCode, ShipComponentSO>();
    public List<ShipCompositeData> dataList = new List<ShipCompositeData>();
    public ShipCompositeData usedComposite{get; private set;}
    protected int _usedComposite;
    public static string DATA_KEY = "ShipCompositeData";
    public int usedCompositeInd{
        get{return _usedComposite;}
        set{_usedComposite = value; usedComposite = dataList[usedCompositeInd];}
    }
    void Awake(){
        if (instance != null){MyDebug.LogSingleton();}
        else{instance = this;}
    }
    void Start(){
        DontDestroyOnLoad(this.gameObject);
        dataList = RetrieveData();
        BlockSO[] blockSOList = Resources.LoadAll<BlockSO>("ShipComposite\\Block");
        for (int i = 0; i < blockSOList.Length; ++i){
            blockDict.Add(blockSOList[i].blockCode, blockSOList[i]);
        }
        ShipComponentSO[] componentSOs = Resources.LoadAll<ShipComponentSO>("ShipComposite\\Block");
        for (int i = 0; i < componentSOs.Length; ++i){
            componentDict.Add(componentSOs[i].componentCode, componentSOs[i]);
        }
    }
    public void SaveData(){
        PlayerPrefsExtra.SetList<ShipCompositeData>(DATA_KEY, dataList);
    }
    public List<ShipCompositeData> RetrieveData(){
        if (PlayerPrefs.GetString(DATA_KEY, "No data") == "No data"){
            MyDebug.LogWarning("No saved ShipCompositeData");
        }
        else{
            MyDebug.Log("Retrieve ShipCompositeData successfully");
        }
        return PlayerPrefsExtra.GetList<ShipCompositeData>(DATA_KEY , new List<ShipCompositeData>());
    }
    /// <returns>True if the execution is successful, it means the Block must link with BaseBlock</returns>
    public void SetBlock(BlockCode block, int usedCompositeInd, int i, int j){
        
    }
}
public class ShipCompositeData{
    public string name;
    public (BlockCode block, ComponentCode com)[,] grid = new (BlockCode, ComponentCode)[ShipComposite.Instance.hei, ShipComposite.Instance.wid];
    
}
