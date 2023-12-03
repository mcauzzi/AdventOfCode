namespace Implementations.Helpers;

public static class Extensions
{
    public static bool IsNumber(this char ch)
    {
        return ch >= '0' && ch <= '9';
    }
    public static bool IsAlpha(this char ch)
    {
        return (ch >= 'a' && ch <= 'z')||(ch >= 'A' && ch <= 'Z');
    }

    public static bool IsSymbol(this char ch)
    {
        return !ch.IsAlpha() && !ch.IsNumber();
    }
}