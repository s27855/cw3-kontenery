using cw3_kontenery.Enum;
using cw3_kontenery.Exceptions;

namespace cw3_kontenery.Models;

public class GasContainer : ContainerBase
{
    public double Pressure { get; }
    public bool IsHazardous { get; set; }

    public GasContainer(double height, double depth, double cargoWeight, double ownWeight, double pressure)
        : base(height, depth, cargoWeight, ownWeight, ContainerType.G)
    {
        Pressure = pressure;
    }

    public override double MaximumLoad => IsHazardous ? base.MaximumLoad * 0.5 : base.MaximumLoad * 0.9;

    public override void LoadCargo(double cargoWeight)
    {
        if (IsOverfilling(cargoWeight))
        {
            throw new OverfillException($"Cargo weight ({cargoWeight}) exceeds maximum load ({MaximumLoad}) for container {SerialNumber}");
        }

        base.LoadCargo(cargoWeight);
    }

    private bool IsOverfilling(double cargoWeight)
    {
        if (IsHazardous && cargoWeight > 0.5 * base.MaximumLoad)
        {
            NotifyDangerousSituation();
            return true;
        }
        else if (!IsHazardous && cargoWeight > 0.9 * base.MaximumLoad)
        {
            NotifyDangerousSituation();
            return true;
        }
        return false;
    }

    public override void UnloadCargo()
    {
        base.UnloadCargo();
        LoadCargo(base.MaximumLoad * 0.05); // Pozostawienie 5% gazu wewnątrz kontenera po rozładowaniu
    }

    private void NotifyDangerousSituation()
    {
        Console.WriteLine($"Dangerous situation detected in container {SerialNumber}");
    }
}