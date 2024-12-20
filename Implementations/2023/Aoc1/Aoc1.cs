using Implementations.Helpers;

namespace Implementations._2023._01;

public class Aoc1 : BaseAoc<int, long>
{
    public Aoc1(char[][] input):base(input)
    {
        InputAsStrings = input.Select(x => new string(x)).ToArray();
    }

    public string[] InputAsStrings { get; set; }

    public override int SolvePart1()
    {
        var res = 0;
        res += InputAsStrings.Select(GetLineNumber).Sum();
        return res;
    }

    public override long SolvePart2()
    {
        var res = 0L;
        res += InputAsStrings.Select(GetLineNumber).Sum();
        return res;
    }

    private static int GetLineNumber(string line)
    {
        line = line.ToLower();
        var foundNumbers = new int?[line.Length];
        foreach (var digit in Enum.GetNames(typeof(Digits)))
        {
            FindName(line, digit, foundNumbers);
        }
        foreach (int digit in Enum.GetValues(typeof(Digits)))
        {
            FindDigit(line, digit, foundNumbers);
        }

        var digits = foundNumbers.Where(x => x != null).ToArray();
        var res    = digits.First().ToString()+digits.Last().ToString();
        
        return int.Parse(res);
    }

    private static void FindDigit(string line, int digit, int?[] foundNumbers)
    {
        var lastIndex = 0;
        do
        {
            lastIndex = line.IndexOf(digit.ToString(), lastIndex);
            if (lastIndex >= 0)
            {
                foundNumbers[lastIndex] = (int)Enum.Parse<Digits>(digit.ToString());
                lastIndex++;
            }
        } while (lastIndex > 0);
    }

    private static void FindName(string line, string digit, int?[] foundNumbers)
    {
        var lastIndex = 0;
        do
        {
            lastIndex = line.IndexOf(digit.ToLower(), lastIndex);
            if (lastIndex >= 0)
            {
                foundNumbers[lastIndex] = (int)Enum.Parse<Digits>(digit);
                lastIndex++;
            }
        } while (lastIndex > 0);
    }

    private enum Digits
    {
        Zero=0,
        One=1,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9
    }
}
