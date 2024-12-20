using Implementations.Helpers;

namespace Implementations._2024._11;

public class Aoc202411 :BaseAoc<long,long>
{
    public Aoc202411(char[][] input) : base(input)
    {
        Stones=Input.Select(x=>new string(x)).First().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
    }

    public long[] Stones { get; set; }

    public override long SolvePart1()
    {
        return ExpandCount(Stones,25);
    }
    private Dictionary<(long,int),long> _cache=new();
    private long ExpandCount(long[] stones,int i)
    {
        if (i == 0)
        {
            return stones.Length;
        }

        var count=0L;
        foreach (var num in stones)
        {   
            if (_cache.TryGetValue((num,i), out var value))
            {
                count+=value;
                continue;
            }

            var sum = ApplyRules(num).Select(x=>ExpandCount([x],i-1)).Sum();
            if (!_cache.TryAdd((num,i), sum))
            {
                _cache[(num,i)] = sum;
            }
            count+=sum;
        }

        return count;
    }

    public long[] ApplyRules(long number)
    {
        if (number == 0)
        {
            return [1];
        }

        var numAsString = number.ToString();
        if (numAsString.Length % 2 == 0)
        {
            return [long.Parse(numAsString[..(numAsString.Length / 2)]), long.Parse(numAsString[(numAsString.Length / 2)..])];
        }

        return [number * 2024];
    }
    public override long SolvePart2()
    {
        return ExpandCount(Stones,75);
    }
}