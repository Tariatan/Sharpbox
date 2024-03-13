namespace Sharpbox;

public static class Extensions
{
    public static KeyValuePair<T1, T2> ToPair<T1, T2>(this ValueTuple<T1, T2> source)
    {
        return new KeyValuePair<T1, T2>(source.Item1, source.Item2);
    }

}