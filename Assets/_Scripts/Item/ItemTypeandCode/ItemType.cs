using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Store some useful value to choice
/// </summary>
public enum ItemType
{
   None,
   Material,
   Block,
   Tower,
   TowerShard, 
   LoreItem,
}
public enum ItemStat{
   Armor,
   ArmorPenetration,
   AntiElemental,
   Cost,
   Damage,
   EnergyConsumption,
   EnergyProduction,
   ExplosionDamage,
   Firerate,
   Health,
   Weight,
}

public enum Rarity{Common, Occasional, Rare, Epic, Exotic, Legendary, Mythical}
