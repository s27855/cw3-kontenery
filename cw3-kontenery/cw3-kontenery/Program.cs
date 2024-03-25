using cw3_kontenery.Models;
using cw3_kontenery.Ship;

class Program
{
    static void Main()
    {
        var liquidContainer = new LiquidContainer(2.5, 3.0, 1500, 500, false);
        var gasContainer = new GasContainer(2.0, 2.5, 1000, 400, 2.5);
        var refrigeratedContainer = new RefrigeratedContainer(2.0, 2.0, 1200, 600, "Fish", 2.0);
        
        var ship = new Ship(30, 10);
        
        try
        {
            ship.LoadContainer(liquidContainer);
            ship.LoadContainer(gasContainer);
            ship.LoadContainer(refrigeratedContainer);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine("Containers on the ship:");
        foreach (var container in ship.Containers)
        {
            Console.WriteLine($"Container {container.SerialNumber}, Type: {container.ContainerType}");
        }
        
        var containerToUnload = ship.Containers[0];
        ship.UnloadContainer(containerToUnload);
        Console.WriteLine($"Container {containerToUnload.SerialNumber} unloaded from the ship.");
        
        Console.WriteLine("Updated containers on the ship:");
        foreach (var container in ship.Containers)
        {
            Console.WriteLine($"Container {container.SerialNumber}, Type: {container.ContainerType}");
        }
    }
}