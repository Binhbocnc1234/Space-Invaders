using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BlockSO", menuName = "SO/Block")]
public class BlockSO : ScriptableObject
{
    public BlockCode blockCode;
    public string blockName;
    public int mainHealth;
    public int armor;
    public Sprite texture;

}

public enum BlockCode{
    None,
    Wood,
    Stone,
    BlueNanotech,

}
