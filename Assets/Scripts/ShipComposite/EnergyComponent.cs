using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyComponent : ShipComponent
{
    [HideInInspector] public EnergySO energySO;
    public int energyProduction;
    public int initalEnergy;

    public override void Reset()
    {
        base.Reset();
        energySO = (EnergySO)shipComponentSO;
        energyProduction = energySO.energyProduction;
        initalEnergy = energySO.initalEnergy;
    }
}
