using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Marketable : ScriptableObject{
    [Header("Marketable fields")]
    public int cost;
    Type type = typeof((ItemProfileSO item, int count));
    public List<(ItemProfileSO item , int count)> materials;
    public bool IsEnoughMaterials(List<(ItemProfileSO item , int count)> yourMaterials){
        for(int i = 0; i < yourMaterials.Count; ++i){
            
        }
        return true;
    }
}