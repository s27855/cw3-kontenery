using cw3_kontenery.Models;

namespace cw3_kontenery.Ship;

public class Ship
{
    private List<ContainerBase> _containers = new List<ContainerBase>();
    public List<ContainerBase> Containers => _containers;

    public int MaxSpeed { get; }
    public int MaxContainers { get; }

    public Ship(int maxSpeed, int maxContainers)
    {
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
    }

    public void LoadContainer(ContainerBase container)
    {
        if (_containers.Count >= MaxContainers)
        {
            throw new InvalidOperationException("The ship is full. Cannot load more containers.");
        }

        _containers.Add(container);
    }

    public void UnloadContainer(ContainerBase container)
    {
        _containers.Remove(container);
    }
}