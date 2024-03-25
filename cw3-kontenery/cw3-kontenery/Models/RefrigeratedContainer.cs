using cw3_kontenery.Enum;
using cw3_kontenery.Exceptions;

namespace cw3_kontenery.Models;

public class RefrigeratedContainer : ContainerBase
{
    public string ProductType { get; }
    public double RequiredTemperature { get; }

    public RefrigeratedContainer(double height, double depth, double cargoWeight, double ownWeight, string productType, double requiredTemperature)
        : base(height, depth, cargoWeight, ownWeight, ContainerType.C)
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
    }

    public override double MaximumLoad => base.MaximumLoad;

    public override double EmptyLoad => base.EmptyLoad;

    public override void LoadCargo(double cargoWeight)
    {
        if (cargoWeight > MaximumLoad)
        {
            throw new OverfillException($"Cargo weight ({cargoWeight}) exceeds maximum load ({MaximumLoad}) for container {SerialNumber}");
        }
        base.LoadCargo(cargoWeight);
    }
}