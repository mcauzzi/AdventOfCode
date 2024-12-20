using System.Text.RegularExpressions;
using Implementations.Helpers;

namespace Implementations._2024._03;

public partial class Aoc202403(char[][] input) : BaseAoc<long, long>(input)
{
    public override long SolvePart1()
    {
        var sumMuls = 0L;
        foreach (var line in Input.Select(x=>new string(x)))
        {
            var regexMatch = Part1Regex().Matches(line);
            foreach (Match match in regexMatch)
            {
                var first  = int.Parse(match.Groups[1].Value);
                var second = int.Parse(match.Groups[2].Value);
                sumMuls += first * second;
            }
        }

        return sumMuls;
    }

    public override long SolvePart2()
    {
        var sumMuls = 0L;
        var enabled = true;
        foreach (var line in Input.Select(x=>new string(x)))
        {
            var regexMatch = Part2Regex().Matches(line);
            foreach (Match match in regexMatch)
            {
                if (match.Value == "do()")
                {
                    enabled = true;
                }
                else if (match.Value == "don't()")
                {
                    enabled = false;
                }
                else if(enabled)
                {
                    var first  = int.Parse(match.Groups[1].Value);
                    var second = int.Parse(match.Groups[2].Value);
                    sumMuls += first * second;
                }
            }
        }

        return sumMuls;
    }

    [GeneratedRegex(@"mul\(([0-9]+),([0-9]+)\)")]
    private static partial Regex Part1Regex();

    [GeneratedRegex(@"mul\(([0-9]+),([0-9]+)\)|do\(\)|don't\(\)")]
    private static partial Regex Part2Regex();
}