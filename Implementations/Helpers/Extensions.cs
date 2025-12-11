namespace Implementations.Helpers;

public static class Extensions
{
    extension(char ch)
    {
        public bool IsNumber()
        {
            return ch >= '0' && ch <= '9';
        }

        public bool IsAlpha()
        {
            return (ch >= 'a' && ch <= 'z')||(ch >= 'A' && ch <= 'Z');
        }

        public bool IsSymbol()
        {
            return !ch.IsAlpha() && !ch.IsNumber();
        }
    }

    public static long Lcm(this IEnumerable<long> numbers)
    {
        return numbers.Aggregate(Lcm);
    }
    extension(long a)
    {
        public long Lcm(long b)
        {
            return Math.Abs(a * b) / Gcd(a, b);
        }

        public long Gcd(long b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
    }
}