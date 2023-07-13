using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[RequireComponent(typeof(GridLayoutGroup))]
public class LayoutElementFilter : MonoBehaviour
{
    
    public float initialWidth;
    public float initialElementWidth;
    GridLayoutGroup grid;
    RectTransform rectTransform;
    void Start(){
        grid = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        grid.cellSize.Scale(new Vector2(1,1)*(rectTransform.rect.x/initialWidth));
    }
}
public class LayoutElementFilterEditor : Editor{
    LayoutElementFilter layout ;
    public override void OnInspectorGUI()
    {
        layout = (LayoutElementFilter)target;
        base.OnInspectorGUI();

        if (GUILayout.Button("Get initial")){
            layout.initialElementWidth = layout.GetComponent<GridLayoutGroup>().cellSize.x;
            layout.initialWidth = layout.GetComponent<RectTransform>().rect.width;
        }
    }
}