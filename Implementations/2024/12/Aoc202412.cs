using Implementations.Helpers;

namespace Implementations._2024._12;

public class Aoc202412 : BaseAoc<long, long>
{
    public Aoc202412(char[][] input) : base(input)
    {
        // Input = """
        //     RRRRIICCFF
        //     RRRRIICCCF
        //     VVRRRCCFFF
        //     VVRCCCJFFF
        //     VVVVCJJCFE
        //     VVIVCCJJEE
        //     VVIIICJJEE
        //     MIIIIIJJEE
        //     MIIISIJEEE
        //     MMMISSJEEE
        //     """.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        //        .Select(x => x.ToCharArray())
        //        .ToArray();
    }

    public override long SolvePart1()
    {
        var regionsDict = new Dictionary<string, List<Region>>();
        for (int yCoord = 0; yCoord < Input.Length; yCoord++)
        {
            for (int xCoord = 0; xCoord < Input[0].Length; xCoord++)
            {
                var plotRegion = Input[yCoord][xCoord];
                if (regionsDict.TryGetValue(plotRegion.ToString(), out var nameRegions))
                {
                    var coordinate      = new Coordinate(xCoord, yCoord);
                    var adjacentRegions = nameRegions.Where(x => x.Plots.Any(y => y.Adjacent(coordinate)));
                    var adjacentRegion  = adjacentRegions.FirstOrDefault();
                    if (adjacentRegion != null)
                    {
                        adjacentRegion.AddPlot(coordinate);
                    }
                    else
                    {
                        var newRegion = new Region(plotRegion, new Coordinate(xCoord, yCoord));
                        nameRegions.Add(newRegion);
                    }

                    if (adjacentRegions.Count() > 1)
                    {
                        var otherPlots = adjacentRegions.Skip(1).SelectMany(x => x.Plots);
                        foreach (var plot in otherPlots)
                        {
                            adjacentRegion.AddPlot(plot);
                        }

                        nameRegions.RemoveAll(x => adjacentRegions.Skip(1).Contains(x));
                    }
                }
                else
                {
                    var newRegion = new Region(plotRegion, new Coordinate(xCoord, yCoord));
                    regionsDict.Add(plotRegion.ToString(), [newRegion]);
                }
            }
        }

        return regionsDict.SelectMany(x => x.Value).Sum(x => x.Area * x.Perimeter);
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}

public class Region : IEquatable<Region>
{
    public bool Equals(Region? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && StartingPlot.Equals(other.StartingPlot);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Region)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, StartingPlot);
    }

    public static bool operator ==(Region? left, Region? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Region? left, Region? right)
    {
        return !Equals(left, right);
    }

    public long                Area      { get; private set; }
    public long                Perimeter { get; private set; }
    public HashSet<Coordinate> Plots     { get; } = new();

    public Region(char name, Coordinate startingPlot)
    {
        Name         = name;
        StartingPlot = startingPlot;
        AddPlot(startingPlot);
    }

    public char       Name         { get; set; }
    public Coordinate StartingPlot { get; }

    public void AddPlot(Coordinate plot)
    {
        Plots.Add(plot);
        Area++;

        var perimeter = 4;
        foreach (var other in Plots)
        {
            if (plot.Adjacent(other))
            {
                perimeter--;
                Perimeter--;
                if (perimeter == 0)
                {
                    break;
                }
            }
        }

        Perimeter += perimeter;
    }
}