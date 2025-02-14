using System.Globalization;
using System.Text;
using Sharpbox;

var list = new List<KeyValuePair<string, string>>
{
    ("Hello", "world").ToPair()
};

// Variables in strings
Console.WriteLine($"{list.First().Key} {list.First().Value}!");

// Enum values to list
var mnemonic = Enum.GetValues(typeof(Mnemonic)).Cast<Mnemonic>().ToArray();
// Concatenate list entries
if (mnemonic.Any(word => word.Equals(Mnemonic.Mother)))
{
    Console.WriteLine($"{string.Join(" ", mnemonic)}");
}

// Parse Enum
var us = (Mnemonic)Enum.Parse(typeof(Mnemonic), nameof(Mnemonic.Pancakes));
Console.WriteLine(us);

// Advanced switch
var moon = us.Equals(Mnemonic.Pancakes) ? Moons.Deimos : Moons.Phobos;
bool AdvancedSwitch(object value, bool flag)
{
    return value switch
    {
        MnemonicPair {Planet: Planets.Earth} => true,
        Systems castEnum when castEnum.Moon == moon && flag == false => true,
        _ => false
    };
}

var systemMars = new Systems(Planets.Mars, Moons.Deimos);
var mnemonicPair = new MnemonicPair(Planets.Earth, Mnemonic.Educated);
var result = AdvancedSwitch(systemMars, false);
Console.WriteLine(result);
result = AdvancedSwitch(mnemonicPair, false);
Console.WriteLine(result);

systemMars.PrintMethodName();

var match = systemMars is { Planet: Planets.Mars, Moon: Moons.Deimos };
Console.WriteLine(match);

// Populate list
var moons = Enumerable.Repeat<Moons>(default, 5).ToList();
Console.WriteLine($"{string.Join(" ", moons)}");

string? ElementToString<T>(T element)
{
    return element switch
    {
        double volume => volume.ToString("N2"),
        bool overVolume => overVolume ? "Yes" : "No",
        _ => element?.ToString(),
    };
}

// Format
Console.WriteLine($"{ElementToString(3.14142135)}");
Console.WriteLine($"{ElementToString(true)}");
var ml = new decimal(1.23456);
Console.WriteLine($"{ml:N2}");
Console.WriteLine($"{6:000}");
Console.WriteLine(double.Parse("16.18864", NumberStyles.Float, CultureInfo.CurrentCulture).ToString("N3"));

// Template
var enums = new List<Enum>();
void AddEnumEntry<TEntry>(
    ref List<Enum> values,
    TEntry enumEntry)
    where TEntry : struct, IConvertible
{
    if (!typeof(TEntry).IsEnum)
    {
        throw new ArgumentException("TEntry must be an enumerated type");
    }

    values.Add((Enum)(object)enumEntry);
}

AddEnumEntry(ref enums, Planets.Earth);
AddEnumEntry(ref enums, Mnemonic.Educated);
AddEnumEntry(ref enums, Moons.Io);

Console.WriteLine($"{string.Join(" ", enums)}");

Console.WriteLine($"{nameof(Systems.DateThePlanetWasDiscovered)}".SplitByCapitalLetters());

foreach (var field in systemMars.GetType().GetProperties())
{
    Console.WriteLine($"{field.Name.SplitByCapitalLetters()}: {field.GetValue(systemMars)}");
}

var data = new List<KeyValuePair<Planets, Moons>>()
{
    new KeyValuePair<Planets, Moons>( Planets.Earth, Moons.Luna ),
    new KeyValuePair<Planets, Moons>( Planets.Jupiter, Moons.Io ),
    new KeyValuePair<Planets, Moons>( Planets.Mars, Moons.Phobos ),
    new KeyValuePair<Planets, Moons>( Planets.Mars, Moons.Deimos ),
    new KeyValuePair<Planets, Moons>( Planets.Mars, Moons.Deimos ),
    new KeyValuePair<Planets, Moons>( Planets.Mars, Moons.Deimos ),
    new KeyValuePair<Planets, Moons>( Planets.Mars, Moons.Deimos ),
};

var dict = new SortedDictionary<Planets, List<Moons>>();
// Structured bindings example
foreach (var (planet, planetMoons) in data)
{
    if (dict.TryGetValue(planet, out var value))
    {
        value.Add(planetMoons);
    }
    else
    {
        dict.Add(planet, [planetMoons]);
    }
}

foreach (var (planet, planetMoons) in dict)
{
    Console.WriteLine($"{planet}: {string.Join(" ", planetMoons)} #of_Deimos:{planetMoons.Count(myMoon => myMoon == Moons.Deimos)}");
}

Console.WriteLine($"{TimeSpan.FromSeconds(10).TotalMilliseconds}");

// Heavy string
var manyWords = new StringBuilder();
for (var i = 0; i < 100; i++)
{
    manyWords.Append("word");
}
Console.WriteLine($"{manyWords}");

var scan = new Scan();
scan.Do();
