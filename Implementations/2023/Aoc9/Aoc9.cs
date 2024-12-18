using Implementations.Helpers;

namespace Implementations._2023.Aoc9;

public class Aoc9 : IAoc<long, long>
{
    public Aoc9(char[][] input) : base(input)
    {
        InputAsStrings=input.Select(x=>new string(x)).ToArray();
    }

    private string[] InputAsStrings { get; }

    public override long SolvePart1()
    {
        var numberArrays = InputAsStrings.Select(x => x.Split(' ', StringSplitOptions.TrimEntries))
                                .Select(x => x.Select(int.Parse).ToList()).ToList();
        return numberArrays.Select(x=>x.Last()+GetNextNumber(x)).Sum();
    }

    private int GetNextNumber(List<int> numbers)
    {
        var diffList = new List<int>();
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i != 0)
            {
                diffList.Add(numbers[i] - numbers[i - 1]);
            }
        }

        if (diffList.All(x => x == 0))
        {
            return 0;
        }

        return diffList.Last() + GetNextNumber(diffList);
    }

    public override long SolvePart2()
    {
        var numbersLists = InputAsStrings.Select(x => x.Split(' ', StringSplitOptions.TrimEntries))
                                .Select(x => x.Select(int.Parse).ToList()).ToList();
        foreach (var list in numbersLists)
        {
            list.Reverse();
        }
        return numbersLists.Select(x=>x.Last()+GetNextNumber(x)).Sum();
    }
}