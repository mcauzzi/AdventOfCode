using System.Data;
using Implementations.Helpers;

namespace Implementations._2024._05;

public class Aoc202405:IAoc<long,long>
{
    public Aoc202405(char[][] input):base(input)
    {
        var i     = 0;
        var inputAsString= input.Select(x=>new string(x)).ToArray();
        while (!string.IsNullOrEmpty(inputAsString[i]))
        {
            var split = inputAsString[i].Split("|");
            Rules.Add((int.Parse(inputAsString[0]),int.Parse(inputAsString[1])));
            i++;
        }
        Rules=Rules.OrderBy(x=>x.First).ToList();
        i++;
        while (i<input.Length)
        {
            var update = inputAsString[i].Split(',').Select(int.Parse).ToList();
            Updates.Add(update);
            i++;
        }
    }
    
    public override long SolvePart1()
    {
        var sum = 0L;
        foreach (var update in Updates)
        {
            if (RespectsAllRules(update))
            {
                var middleIndex = update.Count / 2;
                sum += update[middleIndex];
            }
        }

        return sum;
    }

    

    public override long SolvePart2()
    {
        var sum = 0L;
        foreach (var update in Updates)
        {
            var shouldSum = false;
            var recheck = false;
            foreach (var rule in Rules)
            {
                if (!RespectsRule(update, rule))
                {
                    var indexOfFirst  = update.IndexOf(rule.First);
                    var indexOfSecond = update.IndexOf(rule.Second);
                    shouldSum                                     = true;
                    recheck                                       = true;
                    (update[indexOfFirst], update[indexOfSecond]) = (update[indexOfSecond], update[indexOfFirst]);
                }
            }
            Fix(recheck, update);
            
            if (shouldSum)
            {
                var middleIndex = update.Count / 2;
                sum += update[middleIndex];
            }
        }

        return sum;
    }
    private bool RespectsAllRules(List<int> update)
    {
        return Rules.All(rule => RespectsRule(update, rule));
    }

    private static bool RespectsRule(List<int> update, (int First, int Second) rule)
    {
        var indexOfFirst  =update.IndexOf(rule.First);
        var indexOfSecond =update.IndexOf(rule.Second);
        if(indexOfFirst==-1||indexOfSecond==-1)
        {
            return true;
        }
        if (indexOfFirst < indexOfSecond)
        {
            return true;
        }

        return false;
    }
    private void Fix(bool recheck, List<int> update)
    {
        while (recheck)
        {
            recheck = false;
            foreach (var rule in Rules)
            {
                if (!RespectsRule(update, rule))
                {
                    var indexOfFirst  = update.IndexOf(rule.First);
                    var indexOfSecond = update.IndexOf(rule.Second);
                    recheck                                       = true;
                    (update[indexOfFirst], update[indexOfSecond]) = (update[indexOfSecond], update[indexOfFirst]);
                }
            }
        }
    }

    private List<(int First, int Second)> Rules   { get; set; } = [];
    private List<List<int>>               Updates { get; set; } = [];
}