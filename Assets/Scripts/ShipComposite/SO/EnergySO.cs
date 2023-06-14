using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnergySO", menuName = "SO/EnergyComponent")]
public class EnergySO : ShipComponentSO
{
    [Header("Energy Component fields")]
    public int energyProduction;
    public int initalEnergy;
}
