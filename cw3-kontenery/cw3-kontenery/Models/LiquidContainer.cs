using cw3_kontenery.Enum;
using cw3_kontenery.Exceptions;
using cw3_kontenery.Inteface;
namespace cw3_kontenery.Models;

public class LiquidContainer : ContainerBase
{
    public LiquidContainer(double height, double depth, double cargoWeight, double ownWeight)
        : base(height, depth, cargoWeight, ownWeight, ContainerType.L) { }
    
    public bool IsHazardous { get; set; }

    public override double MaximumLoad => IsHazardous ? 0.5 * base.MaximumLoad : 0.9 * base.MaximumLoad;

    public override double EmptyLoad => base.EmptyLoad;

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

    private void NotifyDangerousSituation()
    {
        Console.WriteLine($"Dangerous situation detected in container {SerialNumber}");
    }
}