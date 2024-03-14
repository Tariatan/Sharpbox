namespace Sharpbox;

public class Systems
{
    public Planets Planet { get; }
    public Moons Moon { get; }

    public Systems(Planets planet, Moons moon)
    {
        Planet = planet;
        Moon = moon;
    }
}