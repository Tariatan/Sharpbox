
using Sharpbox;

var list = new List<KeyValuePair<string, string>>
{
    ("Hello", "world").ToPair()
};

Console.WriteLine($"{list.First().Key} {list.First().Value}!");