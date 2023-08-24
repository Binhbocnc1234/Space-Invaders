using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Experimental.GraphView;
#endif





// !---Unfinished script-----!
[AttributeUsage(AttributeTargets.Field)]
public class SearchWindowAttribute : PropertyAttribute{ //Basically , PropertyAttribute is the same as System Attribute


}
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SearchWindowAttribute))]
public class SearchWindowAttributeDrawer : PropertyDrawer{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Type t = property.GetPropertyType();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(property.displayName, GUILayout.ExpandWidth(false), GUILayout.Width(property.name.Length*12));
        if (GUILayout.Button($"{(ItemCode)property.GetValue()}", EditorStyles.popup)){
            SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)), 
            new StringSearchTree(t, selected => property.SetValue(Enum.Parse<ItemCode>(selected))));
        }
        EditorGUILayout.EndHorizontal();
    }
}
#endif