namespace Sharpbox;

public class BestPractices
{
    // Instead of this:
    public int ConditionalReturn(int? offset)
    {
        int result;

        if (offset == null)
        {
            result = -1;
        }
        else
        {
            result = offset.Value;
        }

        return result;
    }

    // Do this:
    public int ConditionalReturnNice(int? offset) => offset ?? -1;

    private DateTime? _firstJobStartedAt;

    // Instead of this:
    public void ConditionalAssignment()
    {
        if (_firstJobStartedAt == null)
        {
            _firstJobStartedAt = DateTime.UtcNow;
        }
    }

    // Do this:
    public void ConditionalAssignmentNice() => _firstJobStartedAt ??= DateTime.Now;

    // Instead of this:
    public DateTime? ConditionalNullReturn()
    {
        if (_firstJobStartedAt != null)
        {
            return _firstJobStartedAt.Value.Date;
        }
        else
        {
            return null;
        }
    }

    // Do this:
    public DateTime? ConditionalNullPropagation() => _firstJobStartedAt?.Date;


    // Instead of this:
    public int IterateTwoLists()
    {
        var moons = new[] {Moons.Io, Moons.Calisto};
        var presence = new[] {false, true};

        var presenceCount = 0;
        for (var i = 0; i < moons.Length; i++)
        {
            if(presence[i])
            {
                presenceCount++;
            }
        }

        return presenceCount;
    }

    // Do this:
    public int IterateDictionary()
    {
        var moonsPresence = new Dictionary<Moons, bool>()
        {
            [Moons.Io] = false,
            [Moons.Calisto] = true,
        };

        var presenceCount = 0;
        foreach (var (moon, present) in moonsPresence)
        {
            if(present)
            {
                presenceCount++;
            }
        }

        return presenceCount;
    }

    // Instead of this:
    public int IterateAllListEntries(Planets planet)
    {
        var planets = new[]
        {
            Planets.Mercury,
            Planets.Venus,
            Planets.Earth,
            Planets.Mars,
            Planets.Jupiter,
            Planets.Saturn,
            Planets.Uranus,
            Planets.Neptune,
            Planets.Pluto,
        };

        for (var i = 0; i < 9; ++i)
        {
            if (planets[i] == planet)
            {
                return i;
            }
        }

        return -1;
    }

    // Do this:
    public int IterateAllListEntriesWithIndex(Planets planet)
    {
        foreach (var (index, entry) in Enum.GetValues<Planets>().Index())
        {
            if (entry == planet)
            {
                return index;
            }
        }

        return -1;
    }
}