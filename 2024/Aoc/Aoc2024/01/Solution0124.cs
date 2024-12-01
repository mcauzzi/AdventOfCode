namespace Aoc2024._01;

public class Solution0124
{
    public Solution0124()
    {
        InputLines = File.ReadLines("01/Input01.txt").ToList();
    }

    public List<string> InputLines { get; set; }

    public int Part1()
    {
        var linesList = InputLines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries).Select(int.Parse)
                                                .ToArray());
        var firstList=linesList.Select(x=>x[0]).Order().ToList();
        var secondList=linesList.Select(x=>x[1]).Order().ToList();
        var diffs=firstList.Zip(secondList).Select(x=>Math.Abs(x.Second-x.First)).ToList();
        return diffs.Sum();
    }

    public long Part2()
    {
        var linesList = InputLines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries).Select(int.Parse)
                                                .ToArray());
        var firstList  =linesList.Select(x=>x[0]).Order().ToList();
        var secondList =linesList.Select(x=>x[1]).Order().ToList();
        return firstList.Select(x=>x*secondList.Count(y=>y==x)).Sum();
    }
}