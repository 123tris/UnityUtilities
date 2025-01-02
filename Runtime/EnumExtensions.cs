using System;

public static class EnumExtensions
{
    public static int GetEnumIndex(this Enum e)
    {
        return Array.IndexOf(Enum.GetValues(e.GetType()), e);
    }

    public static T GetEnumByIndex<T>(this int index) where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(index);
    }
}
