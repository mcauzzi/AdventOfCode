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
    
    public static long Lcm(this IEnumerable<long> numbers)
    {
        return numbers.Aggregate(Lcm);
    }
    public static long Lcm(this long a, long b)
    {
        return Math.Abs(a * b) / Gcd(a, b);
    }
    public static long Gcd(this long a, long b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}