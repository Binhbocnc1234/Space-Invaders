using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Marketable : ScriptableObject{
    [Header("Marketable fields")]
    public int cost;
    public List<(ItemProfileSO item , int count)> materials;
}