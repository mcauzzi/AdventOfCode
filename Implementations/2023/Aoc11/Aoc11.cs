using Implementations.Helpers;

namespace Implementations._2023.Aoc11;

public class Aoc11(char[][] input) : IAoc<double, double>(input)
{
   

    public override double SolvePart1()
    {
        Dictionary<(Galaxy, Galaxy), double> distances  = new();

        var galaxies = Input.SelectMany((x, row) => x.Select((x, col) => new { col, row, val = x })
                                                     .Where(x => x.val == '#').Select((y) => new Galaxy(y.col, y.row)))
                            .ToList();
        ExpandGalaxies(galaxies, 1);
        CalculateGalaxiesDistances(distances,galaxies);
        foreach (var charArray in Input)
        {
            Console.WriteLine(new string(charArray));
        }

        return distances.Sum(x => x.Value);
    }

    private void CalculateGalaxiesDistances(Dictionary<(Galaxy, Galaxy), double> distances, List<Galaxy> galaxies)
    {
        foreach (var gal in galaxies)
        {
            foreach (var other in galaxies.Where(x => x != gal))
            {
                if (!distances.TryGetValue((gal, other), out _) && !distances.TryGetValue((other, gal), out _))
                {
                    distances.Add((gal, other), gal.DistanceBetweenGalaxies(other));
                }
            }
        }
    }


    public override double SolvePart2()
    {
        Dictionary<(Galaxy, Galaxy), double> distances  = new();
        var galaxies = Input.SelectMany((x, row) => x.Select((x, col) => new { col, row, val = x })
                                                     .Where(x => x.val == '#').Select((y) => new Galaxy(y.col, y.row)))
                            .ToList();
        ExpandGalaxies(galaxies,999999);
        CalculateGalaxiesDistances(distances,galaxies);
        foreach (var galaxy in galaxies)
        {
            Console.WriteLine($"Id:{galaxy.Id}, RealCol:{galaxy.RealColumn}, RealRow:{galaxy.RealRow}");
        }
        return distances.Sum(x => x.Value);
    }

    private void ExpandGalaxies(List<Galaxy> galaxies,long expansion)
    {
        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i].All(x => x == '.'))
            {
                foreach (var galaxy in galaxies.Where(x=>x.Row>i))
                {
                    galaxy.RealRow += expansion;
                }
            }
        }

        for (int i = 0; i < Input[0].Length; i++)
        {
            if (Input.Select(x => x[i]).All(x => x == '.'))
            {
                foreach (var galaxy in galaxies.Where(x=>x.Column>i))
                {
                    galaxy.RealColumn += expansion;
                }
            }
        }
    }
}

public class Galaxy : IEquatable<Galaxy>
{
    public Galaxy(int column, int row)
    {
        Column     = column;
        Row        = row;
        RealRow    = row;
        RealColumn = column;
        Id         = GalaxyCounter++;
    }

    public double DistanceBetweenGalaxies(Galaxy other)
    {
        return Math.Abs(other.RealColumn - RealColumn) + Math.Abs(other.RealRow - RealRow);
    }

    public         long Column        { get; }
    public         long Row           { get; }
    public         long RealRow       { get; set; }
    public         long RealColumn    { get; set; }
    public         int  Id            { get; }
    private static int  GalaxyCounter { get; set; } = 1;

    public bool Equals(Galaxy? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Galaxy)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public static bool operator ==(Galaxy? left, Galaxy? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Galaxy? left, Galaxy? right)
    {
        return !Equals(left, right);
    }
}