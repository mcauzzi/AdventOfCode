using System.Collections.Concurrent;
using Implementations.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace Implementations.Aoc5;

public class Aoc5 : IAoc<long, long>
{
    private string[] Input { get; } = File.ReadAllLines("./Aoc5/Input.txt");

    public long SolvePart1()
    {
        var seeds = Input[0][(Input[0].IndexOf(':') + 1)..]
                    .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x))
                    .ToList();
        List<Mapping> mappings  = ParseInput(Input.Skip(1));
        var           locations = new List<long>();
        foreach (var seed in seeds)
        {
            var mappedValue = seed;
            foreach (var mapping in mappings)
            {
                mappedValue = mapping.Map(mappedValue);
            }

            locations.Add(mappedValue);
        }

        return locations.Min();
    }

    private List<Mapping> ParseInput(IEnumerable<string> lines)
    {
        var enumeratedList = lines as string[] ?? lines.ToArray();
        var res            = new List<Mapping>();
        for (int i = 0; i < enumeratedList.Length; i++)
        {
            if (string.IsNullOrEmpty(enumeratedList[i]))
            {
                continue;
            }

            if (enumeratedList[i][0].IsAlpha())
            {
                var endMapsLines = enumeratedList.Skip(i + 1)
                                                 .TakeWhile(x => !string.IsNullOrEmpty(x) && x[0].IsNumber())
                                                 .ToArray();
                res.Add(new Mapping(endMapsLines));
                i += endMapsLines.Length;
            }
        }

        return res;
    }

    public long SolvePart2()
    {
        var seedsRanges = Input[0][(Input[0].IndexOf(':') + 1)..]
                          .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => long.Parse(x))
                          .ToList();
        var mappings = ParseInput(Input.Skip(1));
        var minimums = new List<long>();
        for (int i = 0; i < seedsRanges.Count; i += 2)
        {
            var initialValue = seedsRanges[i];
            var length       = seedsRanges[i + 1];
            Console.WriteLine($"Starting Range {i/2} with length {length}");
            minimums.Add(FindRangeMinimum(initialValue, length, mappings));
        }

        return minimums.Min();
    }

    private long FindRangeMinimum(long initialValue, long length, List<Mapping> mappings)
    {
        var rangeMinimums = new List<long>();
        var interval      = Math.Max(1, length / 24);
        var threads       = new List<Thread>();
        for (int i = 0; length > 0; i++)
        {
            var currentLength = length;
            var currentIndex  = i;
            var thread =
                new Thread(() => rangeMinimums.Add(CalculateIntervalMin(initialValue + interval * currentIndex,
                                                                        Math.Min(currentLength, interval), mappings)));
            threads.Add(thread);
            thread.Start();
            length -= interval;
        }

        while (threads.Any(x => x.IsAlive))
        {
            Thread.Sleep(1000);
        }

        return rangeMinimums.Min();
    }

    private long CalculateIntervalMin(long initialValue, long length, List<Mapping> mappings)
    {
        long min = long.MaxValue;
        for (long seed = initialValue; seed < initialValue + length; seed++)
        {
            var mappedValue = FindMappedValue(seed, mappings);

            if (mappedValue < min)
            {
                min = mappedValue;
            }
        }

        return min;
    }

    private long FindMappedValue(long seed, List<Mapping> mappings)
    {
        var mappedValue = seed;
        foreach (var mapping in mappings)
        {
            mappedValue = mapping.Map(mappedValue);
        }
        
        return mappedValue;
    }

    private MemoryCache MappedValues = new(new MemoryCacheOptions() { CompactionPercentage = 0.5 });

    private long FindMinInRange(long initialValue, long length, List<Mapping> mappings)
    {
        var min = long.MaxValue;


        return min;
    }

    private class Map
    {
        public long SourceStart { get; init; }
        public long DestStart   { get; init; }
        public long Length      { get; init; }

        public Map(string str)
        {
            var splitString = str.Split(' ', StringSplitOptions.TrimEntries);
            DestStart   = long.Parse(splitString[0]);
            SourceStart = long.Parse(splitString[1]);
            Length      = long.Parse(splitString[2]);
        }
    }

    private class Mapping
    {
        private List<Map> Maps { get; init; }

        public Mapping(string[] mapsStr)
        {
            Maps = mapsStr.Select(x => new Map(x)).ToList();
        }

        public long Map(long value)
        {
            var mapper = Maps.FirstOrDefault(x => value >= x.SourceStart && value < x.SourceStart + x.Length);
            if (mapper == null)
            {
                return value;
            }

            return mapper.DestStart + (value - mapper.SourceStart);
        }
    }
}