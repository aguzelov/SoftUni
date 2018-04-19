﻿public class HammerHarvester : Harvester
{
    private const int EnergyRequirementMultiplier = 2;
    private const int OreOutputMultiplier = 4;

    public HammerHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput *= OreOutputMultiplier, energyRequirement *= EnergyRequirementMultiplier)
    {
    }
}