using Implementations.Helpers;

namespace Implementations._2023.Aoc9;

public class Aoc9 : IAoc<long, long>
{
    private string[] Input { get; } = File.ReadAllLines("./Aoc9/Input.txt");

    public long SolvePart1()
    {
        var numberArrays = Input.Select(x => x.Split(' ', StringSplitOptions.TrimEntries))
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

    public long SolvePart2()
    {
        var numbersLists = Input.Select(x => x.Split(' ', StringSplitOptions.TrimEntries))
                                .Select(x => x.Select(int.Parse).ToList()).ToList();
        foreach (var list in numbersLists)
        {
            list.Reverse();
        }
        return numbersLists.Select(x=>x.Last()+GetNextNumber(x)).Sum();
    }
}