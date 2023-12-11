using Implementations.Helpers;

namespace Implementations.Aoc11;

public class Aoc11 : IAoc<double, double>
{
    private char[][] Input { get; set; } =
        File.ReadAllLines("./Aoc11/Input.txt").Select(x => x.Select(x => x).ToArray()).ToArray();

    public Dictionary<(Galaxy, Galaxy), double> Distances { get; set; } = new();

    public double SolvePart1()
    {
        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i].All(x => x == '.'))
            {
                var newArray = new char[Input[i].Length];
                Array.Fill(newArray, '.');
                Input = Input[..i].Concat(new[] { newArray }).Concat(Input[i..]).ToArray();
                i++;
            }
        }

        for (int i = 0; i < Input[0].Length; i++)
        {
            if (Input.Select(x => x[i]).All(x => x == '.'))
            {
                for (var j = 0; j < Input.Length; j++)
                {
                    Input[j] = Input[j][..i].Append('.').Concat(Input[j][i..]).ToArray();
                }

                i++;
            }
        }

        var galaxies = Input.SelectMany((x, row) => x.Select((x, col) => new { col, row, val = x })
                                                     .Where(x => x.val == '#').Select((y) => new Galaxy(y.col, y.row)))
                            .ToList();
        CalculateGalaxiesDistances(galaxies);
        foreach (var charArray in Input)
        {
            Console.WriteLine(new string(charArray));
        }

        return Distances.Sum(x => x.Value);
    }

    private void CalculateGalaxiesDistances(List<Galaxy> galaxies)
    {
        foreach (var gal in galaxies)
        {
            foreach (var other in galaxies.Where(x => x != gal))
            {
                if (!Distances.TryGetValue((gal, other), out _) && !Distances.TryGetValue((other, gal), out _))
                {
                    Distances.Add((gal, other), gal.DistanceBetweenGalaxies(other));
                }
            }
        }
    }


    public double SolvePart2()
    {
        for (int i = 0; i < Input.Length; i++)
        {
            if (Input[i].All(x => x == '.'))
            {
                var newRows = Enumerable.Repeat(Enumerable.Repeat('.', Input[i].Length).ToArray(), 1000000).ToArray();
                Input = Input[..i].Concat(newRows).Concat(Input[i..]).ToArray();
                i++;
            }
        }

        for (int i = 0; i < Input[0].Length; i++)
        {
            if (Input.Select(x => x[i]).All(x => x == '.'))
            {
                for (var j = 0; j < Input.Length; j++)
                {
                    Input[j] = Input[j][..i].Concat(Enumerable.Repeat('.', 1000000)).Concat(Input[j][i..]).ToArray();
                }

                i++;
            }
        }

        var galaxies = Input.SelectMany((x, row) => x.Select((x, col) => new { col, row, val = x })
                                                     .Where(x => x.val == '#').Select((y) => new Galaxy(y.col, y.row)))
                            .ToList();
        CalculateGalaxiesDistances(galaxies);

        return Distances.Sum(x => x.Value);
    }
}

public class Galaxy : IEquatable<Galaxy>
{
    public Galaxy(int column, int row)
    {
        Column = column;
        Row    = row;
        Id     = GalaxyCounter++;
    }

    public double DistanceBetweenGalaxies(Galaxy other)
    {
        return Math.Abs(other.Column - Column) + Math.Abs(other.Row - Row);
    }

    public         int Column        { get; }
    public         int Row           { get; }
    public         int Id            { get; }
    private static int GalaxyCounter { get; set; } = 1;

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