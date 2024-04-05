using System.Reflection;

namespace Sharpbox;

public class Systems
{
    public Planets Planet { get; }
    public Moons Moon { get; }

    public DateTime DateThePlanetWasDiscovered = DateTime.Now;

    public Systems(Planets planet, Moons moon)
    {
        Planet = planet;
        Moon = moon;
    }

    public void PrintMethodName()
    {
        Console.WriteLine($"{this.GetType().Name}::{MethodBase.GetCurrentMethod()!.Name}");
    }
}