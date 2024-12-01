using Implementations.Helpers;

namespace Implementations._2023.Aoc8;

public class Map
{
    private Dictionary<string, string[]> Positions { get; set; }

    public Map(IEnumerable<string> Input)
    {
        Positions = Input.Select(x => x.Split("=", StringSplitOptions.TrimEntries))
                         .Select(x => new KeyValuePair<string, string[]>(x[0],
                                                                         x[1]
                                                                             .Split(',', StringSplitOptions.TrimEntries)
                                                                             .Select(x =>
                                                                                          new string(x.Where(x =>
                                                                                                                x.IsAlpha()
                                                                                                             || x
                                                                                                                    .IsNumber())
                                                                                                   .ToArray()))
                                                                             .ToArray()))
                         .ToDictionary();
    }

    public string[] GetNextPositions(string pos)
    {
        return Positions[pos];
    }

    public string[] GetAllStartingPositions()
    {
        return Positions.Where(x => x.Key[2] == 'A').Select(x => x.Key).ToArray();
    }
    public string[] GetEndingPositions()
    {
        return Positions.Where(x => x.Key[2] == 'Z').Select(x => x.Key).ToArray();
    }
}