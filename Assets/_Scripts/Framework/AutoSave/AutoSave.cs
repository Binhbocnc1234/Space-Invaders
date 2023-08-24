using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

[ExecuteInEditMode]
public class AutoSave : MonoBehaviour
{
    public IEnumerator Count()
    {
        while(true){
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
            MyDebug.Log("AutoSave has activated");
            yield return new WaitForSeconds(1.5f);
        }
        
    }
    void OnEnable(){
        this.runInEditMode = true;
        if (!Application.isPlaying){
            StartCoroutine(Count());
        }
    }
    void Update(){
        // MyDebug.Log("Called");
        
    }
}
// [CustomEditor(typeof(AutoSave))] 
// public class AutoSaveEditor : Editor{
//     public override void OnInspectorGUI()
//     {
//         Debug.Log("Called");
//         AutoSave autoSave = (AutoSave)target;
//         base.OnInspectorGUI();
//         autoSave.Count();

//     }
// }
