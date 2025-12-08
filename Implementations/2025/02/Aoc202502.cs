using System.Text.RegularExpressions;

using Implementations.Helpers;

namespace Implementations._2025._02;

public partial class Aoc202502(char[][] input) : BaseAoc<long, long>(input)
{
    public override long SolvePart1()
    {
        var idRanges = new string(Input[0]).Split(',').Select(x => x.Split('-'))
            .ToArray();
        var invalidSum = 0L;
        foreach (var range in idRanges)
        {
            var start = range.First();
            var end = range.Last();
            for (long i = long.Parse(start); i <= long.Parse(end); i++)
            {
                var valueAsString = i.ToString();
                
                if (valueAsString.Length % 2 != 0)
                {
                    continue;
                }
                if (RepetitionRegex().IsMatch(valueAsString))
                {
                    invalidSum += i;
                }
            }
        }
        return invalidSum;
    }

    public override long SolvePart2()
    {
        var idRanges = new string(Input[0]).Split(',').Select(x => x.Split('-'))
            .ToArray();
        var invalidSum = 0L;
        foreach (var range in idRanges)
        {
            var start = range.First();
            var end = range.Last();
            for (long i = long.Parse(start); i <= long.Parse(end); i++)
            {
                var valueAsString = i.ToString();
                
                if (PartTwoRegex().IsMatch(valueAsString))
                {
                    invalidSum += i;
                }
            }
        }
        return invalidSum;
    }

    [GeneratedRegex(@"^([0-9]+)\1$")]
    private static partial Regex RepetitionRegex();
    [GeneratedRegex(@"^(\d+)\1+$")]
    private static partial Regex PartTwoRegex();
}