namespace Implementations.Aoc1;

public class Aoc1
{
    public int Run()
    {
        var res = 0;

        res += Input.Select(GetLineNumber).Sum();
        return res;
    }

    private static int GetLineNumber(string line)
    {
        line = line.ToLower();
        var foundNumbers = new int?[line.Length];
        foreach (var digit in Enum.GetNames(typeof(Digits)))
        {
            var lastIndex = 0;
            do
            {
                lastIndex = line.IndexOf(digit.ToLower(), lastIndex);
                if (lastIndex>=0)
                {
                    foundNumbers[lastIndex] = (int)Enum.Parse<Digits>(digit);
                    lastIndex++;
                }
            } while (lastIndex>0);
        }
        foreach (int digit in Enum.GetValues(typeof(Digits)))
        {
            var lastIndex = 0;
            do
            {
                lastIndex = line.IndexOf(digit.ToString(), lastIndex);
                if (lastIndex>=0)
                {
                    foundNumbers[lastIndex] = (int)Enum.Parse<Digits>(digit.ToString());
                    lastIndex++;
                }
            } while (lastIndex>0);
        }

        var digits = foundNumbers.Where(x => x != null).ToArray();
        var res    = digits.First().ToString()+digits.Last().ToString();
        
        // for (int i = 0; i < digits.Count(); i++)
        // {
        //     if (i == 0)
        //     {
        //         res += digits[i].ToString();
        //     }
        //     else if (i == digits.Length-1)
        //     {
        //         res += digits[i].ToString();
        //     }
        // }
        Console.WriteLine($"{line}|{res}");
        return int.Parse(res);
    }

    private string[] Input { get; init; } = File.ReadAllLines("./Aoc1/Input.txt");

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