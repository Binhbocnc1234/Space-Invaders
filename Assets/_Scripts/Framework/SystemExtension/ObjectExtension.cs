using System;
using UnityEngine;

public static class SystemExtension 
{
    public static Vector3 GetMousePos(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
