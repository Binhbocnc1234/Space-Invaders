using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BlockSO", menuName = "SO/Block")]
public class BlockSO : ItemProfileSO
{
    [Header("Block stats")]
    public int mainHealth;
    public int armor;
    public int weight;
    public int antiElemental;
    public override void OnEnable(){
        base.OnEnable();
        stats.TryAdd(ItemStat.Health, () => mainHealth);
        stats.TryAdd(ItemStat.Armor, () => armor);
        stats.TryAdd(ItemStat.AntiElemental, () => antiElemental);
        stats.TryAdd(ItemStat.Weight, () => weight);
    }
}
