using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


/// <summary>
/// Show item's infomation on screen
/// </summary>
public class ItemProfileUI : MonoBehaviour
{
    public ItemProfileSO itemProfileSO;
    [Header("No need to care about the fields below")]
    public TextMeshProUGUI description;
    public TextMeshProUGUI itemName;
    public Image icon;
    public GridLayoutGroup stats;
    public void LoadNewItem(ItemProfileSO itemProfileSO){
        if (itemProfileSO == null){MyDebug.LogWarning("You must pass an ItemProfileSO in order to initialize ItemProfileUI!");}
        this.itemProfileSO = itemProfileSO;
        if (itemName != null){itemName.text = itemProfileSO.itemName;}
        if (description != null){description.text = itemProfileSO.description;}
        if (icon.sprite != null){icon.sprite = itemProfileSO.sprite;}
        if (stats != null){
            for(int i = 0; i < stats.transform.childCount; ++i){
                StatUI stat = stats.transform.GetChild(i).GetComponent<StatUI>();
                Func<object> value_func;
                bool isContain = itemProfileSO.stats.TryGetValue(stat.itemStat, out value_func);

                if (isContain && (int)value_func() != 0){
                    stat.gameObject.SetActive(true);
                    stat.tmp.text = ((int)value_func()).ToString();
                    stat.value = ((int)value_func());
                }
                else{stat.gameObject.SetActive(false);}
            }
        }
        MyDebug.Log("Load new item successfully");
    }

}
#if UNITY_EDITOR
[CustomEditor(typeof(ItemProfileUI))]
[CanEditMultipleObjects]
public class ItemProfileUIEditor : Editor{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ItemProfileUI itemProfileUI = (ItemProfileUI)target;
        if (GUILayout.Button("Load new item")){
            itemProfileUI.LoadNewItem(itemProfileUI.itemProfileSO);
        }
    }
}
#endif