﻿using System;

public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; protected set; }
    public bool TakeEnergy(double energyNeeded)
    {
        if (this.EnergyStored >= energyNeeded)
        {
            this.EnergyStored -= energyNeeded;
            return true;
        }

        return false;
    }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }
}

