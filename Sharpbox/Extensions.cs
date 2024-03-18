using System.Text.RegularExpressions;

namespace Sharpbox;

public static class Extensions
{
    public static KeyValuePair<T1, T2> ToPair<T1, T2>(this ValueTuple<T1, T2> source)
    {
        return new KeyValuePair<T1, T2>(source.Item1, source.Item2);
    }

    public static string SplitByCapitalLetters(this string str)
    {
        return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {m.Value[1]}");
    }
}