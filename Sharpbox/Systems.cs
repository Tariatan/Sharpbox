using System.Reflection;

namespace Sharpbox;

public class Systems(Planets planet, Moons moon)
{
    public Planets Planet { get; } = planet;
    public Moons Moon { get; } = moon;

    public DateTime DateThePlanetWasDiscovered = DateTime.Now;

    public void PrintMethodName()
    {
        Console.WriteLine($"{this.GetType().Name}::{MethodBase.GetCurrentMethod()!.Name}");
    }
}