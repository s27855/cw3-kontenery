﻿using cw3_kontenery.Enum;

namespace cw3_kontenery.Models;

public abstract class ContainerBase : IHazardNotifier
{
    private static int _containerCount = 0;

    protected double Height { get; }
    protected double Depth { get; }
    protected double CargoWeight { get; private set; }
    protected double OwnWeight { get; }
    protected string SerialNumber { get; }
    public ContainerType ContainerType { get; }

    protected ContainerBase(double height, double depth, double cargoWeight, double ownWeight, ContainerType containerType)
    {
        Height = height;
        Depth = depth;
        CargoWeight = cargoWeight;
        OwnWeight = ownWeight;
        ContainerType = containerType;
        SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        _containerCount++;
        return $"KON-{ContainerType}-{_containerCount}";
    }

    public virtual void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaximumLoad)
        {
            throw new OverfillException($"Cargo weight ({cargoWeight}) exceeds maximum load ({MaximumLoad}) for container {SerialNumber}");
        }
        CargoWeight += cargoWeight;
    }

    public virtual void UnloadCargo()
    {
        CargoWeight = 0;
    }

    public abstract double MaximumLoad { get; }
    public abstract double EmptyLoad { get; }

    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.WriteLine($"Dangerous situation detected in container {containerNumber}");
    }
}