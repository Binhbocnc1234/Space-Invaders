using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



/// <summary> 
/// Conversion conventions between Enum and string value:
/// Underscores in enum correspond to Spaces in string value
/// 
/// </summary>
public class EnumParser{

    public static Enum FromString(string itemName)
    {
        try
        {
            return (Enum)System.Enum.Parse(typeof(Enum), itemName);
        }
        catch (ArgumentException e)
        {
            MyDebug.LogError(e);
            return null;
        }
    }
    public static string FromEnumToString(Enum enumName){
        return enumName.ToString();
    }
}
public static class MyDebug{
    public static bool canLog = true;
    public static void Log(object content){
        if (!canLog){return;}
        Debug.Log(content);
    }
    public static void LogWarning(object content){
        if (!canLog){return;}
        Debug.LogWarning(content);
    }
    public static void LogError(object content){
        if (!canLog){return;}
        Debug.LogError(content);
    }
    public static void LogSingleton(){
        if (!canLog){return;}
        Debug.LogWarning("You have created a singleton before. Check your code now!");
    }
    

}

