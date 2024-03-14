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

// Numbers format
Console.WriteLine($"{ElementToString(3.14142135)}");
Console.WriteLine($"{ElementToString(true)}");
var ml = new decimal(1.23456);
Console.WriteLine($"{ml:N2}");
Console.WriteLine($"{6:00}");
