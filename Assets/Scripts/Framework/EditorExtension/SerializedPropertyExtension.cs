using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Experimental.GraphView;
#endif

public static class SerializedPropExtension
{
#if UNITY_EDITOR
    // Gets value from SerializedProperty - even if value is nested
    public static object GetTargetObject(this SerializedProperty prop){
        return prop.serializedObject.targetObject;
    }
    public static Type GetPropertyType(this SerializedProperty prop){
        return prop.GetTargetObject().GetType().GetField(prop.name).FieldType;
    }
    
    public static object GetValue(this SerializedProperty prop){
        object obj = prop.GetTargetObject();
        return obj.GetType().GetField(prop.name).GetValue(obj);
    }
    public static T GetValue<T>(this UnityEditor.SerializedProperty prop){return (T)prop.GetValue();}
    public static T GetCustomAttribute<T>(this SerializedProperty prop) where T : PropertyAttribute{
        object obj = prop.serializedObject.targetObject;
        return obj.GetType().GetField(prop.name).GetCustomAttribute<T>();
    }   
    // Sets value from SerializedProperty - even if value is nested
    public static void SetValue(this UnityEditor.SerializedProperty prop, object val)
    {
        object obj = prop.serializedObject.targetObject;
        obj.GetType().GetField(prop.name).SetValue(obj, val);
    }
#endif // UNITY_EDITOR
}