using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerSO", menuName = "SO/Tower")]
public class TowerSO : ShipComponentSO
{
    [Header("Tower fields")]
    public int damage;
    public int range;
    public float fireRate;
    [HideInInspector] public int dps;
    public override void OnEnable()
    {
        base.OnEnable();
        dps = (int)(damage/fireRate);
        stats.TryAdd(ItemStat.Damage, () => damage);
        stats.TryAdd(ItemStat.Firerate, () => range);
        
    }
    
}
