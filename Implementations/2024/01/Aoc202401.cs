using Implementations.Helpers;

namespace Implementations._2024._01;

public class Aoc202401:IAoc<int,long>
{
    public List<string> InputLines { get; set; } = File.ReadLines("2024/01/Input.txt").ToList();

    public int SolvePart1()
    {
        var linesList = InputLines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries).Select(int.Parse)
                                                .ToArray());
        var firstList=linesList.Select(x=>x[0]).Order().ToList();
        var secondList=linesList.Select(x=>x[1]).Order().ToList();
        var diffs=firstList.Zip(secondList).Select(x=>Math.Abs(x.Second-x.First)).ToList();
        return diffs.Sum();
    }

    public long SolvePart2()
    {
        var linesList = InputLines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries).Select(int.Parse)
                                                .ToArray());
        var firstList  =linesList.Select(x=>x[0]).Order().ToList();
        var secondList =linesList.Select(x=>x[1]).Order().ToList();
        return firstList.Select(x=>x*secondList.Count(y=>y==x)).Sum();
    }
}