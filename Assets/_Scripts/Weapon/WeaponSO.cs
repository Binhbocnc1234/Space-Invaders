using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "SO/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon basic fields")]

    public string weaponName;
    public string description;
    public int damage;
    public int fireRate;
    public int bulletSpeed;
    public int armorPenetration;
    public bool strikeThrough;
    [Header("Explosion")]
    public int explosionDamage;
    public float explosionRadius;
    [Header("MultipleBullets")]
    public int bulletNum;

}
