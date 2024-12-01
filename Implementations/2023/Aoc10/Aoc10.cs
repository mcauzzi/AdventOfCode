using Implementations.Helpers;

namespace Implementations._2023.Aoc10;

public class Aoc10 : IAoc<int, int>
{
    public Aoc10()
    {
        Pipes = File.ReadAllLines("./Aoc10/Input.txt")
                    .Select((x, row) => x.Select((y, col) => new Pipe(y, row, col)).ToArray())
                    .ToArray();
        foreach (var pipeline in Pipes)
        {
            foreach (var pipe in pipeline)
            {
                pipe.Neighbours = GetNeighbors(pipe.Coordinate).ToList();
                pipe.ConnectedNeighbours = pipe.Neighbours
                                               .Where(x => x.IsConnected(pipe.Coordinate) &&
                                                           pipe.IsConnected(x.Coordinate))
                                               .ToList();
            }
        }
    }

    private Pipe[][] Pipes { get; }

    public int SolvePart1()
    {
        var currentPipe = FindStart();
        var pipeArray   = Pipes.SelectMany(x => x.Select(x => x)).ToArray();
        currentPipe.Distance = 0;
        while (
            pipeArray.Any(curr => curr.Distance != null && curr.PipeType is not (PipeType.Ground) &&
                                  !curr.HasValidNeighbours()))
        {
            var startPoint = pipeArray.First(x => x.Distance != null && !x.HasValidNeighbours() &&
                                                  x.PipeType is not (PipeType.Ground));
            FindMaxDistance(startPoint, startPoint.Distance ?? 0);
        }
        // foreach (var pipe in Pipes)
        // {
        //     Console.WriteLine(string.Join(',',
        //                                   pipe.Select(x => x.Distance.ToString() ?? ".").Select(x => x.PadLeft(3))));
        // }


        return pipeArray.Select(x => x.Distance ?? 0).Max();
    }


    private void FindMaxDistance(Pipe current, int distance, int maxStack = 2000)
    {
        current.Distance = distance;
        if (maxStack == 0)
        {
            return;
        }

        if (current.PipeType == PipeType.Start)
        {
            var connectedNodes =
                current.ConnectedNeighbours.Where(x => x.IsConnected(current.Coordinate)).ToList();
            foreach (var pipe in connectedNodes)
            {
                FindMaxDistance(pipe, distance + 1, maxStack - 1);
            }
        }
        else
        {
            var connectedNodes = current.ConnectedNeighbours
                                        .Where(x => x.IsConnected(current.Coordinate) &&
                                                    current.IsConnected(x.Coordinate) &&
                                                    (x.Distance == null || current.Distance + 1 < x.Distance)).ToList();
            foreach (var pipe in connectedNodes)
            {
                FindMaxDistance(pipe, distance + 1, maxStack - 1);
            }
        }
    }

    private IEnumerable<Pipe> GetNeighbors(Coordinate coord)
    {
        if (coord.Row - 1 >= 0)
        {
            yield return Pipes[coord.Row - 1][coord.Column];
        }

        if (coord.Row + 1 < Pipes.Length)
        {
            yield return Pipes[coord.Row + 1][coord.Column];
        }

        if (coord.Column - 1 >= 0)
        {
            yield return Pipes[coord.Row][coord.Column - 1];
        }

        if (coord.Column + 1 < Pipes[coord.Row].Length)
        {
            yield return Pipes[coord.Row][coord.Column + 1];
        }
    }

    private Pipe FindStart()
    {
        for (var i = 0; i < Pipes.Length; i++)
        {
            var pipeLine = Pipes[i];
            for (var j = 0; j < pipeLine.Length; j++)
            {
                var pipe = pipeLine[j];
                if (pipe.PipeType == PipeType.Start)
                {
                    return pipe;
                }
            }
        }

        throw new Exception();
    }

    public int SolvePart2()
    {
        var currentPipe = FindStart();
        var pipeArray   = Pipes.SelectMany(x => x.Select(x => x)).ToArray();
        currentPipe.Distance = 0;
        while (
            pipeArray.Any(curr => curr.Distance != null && curr.PipeType is not (PipeType.Ground) &&
                                  !curr.HasValidNeighbours()))
        {
            var startPoint = pipeArray.First(x => x.Distance != null && !x.HasValidNeighbours() &&
                                                  x.PipeType is not (PipeType.Ground));
            FindMaxDistance(startPoint, startPoint.Distance ?? 0);
        }

        var outsideCount = 0;
        do
        {
            outsideCount = 0;
            foreach (var pipe in pipeArray)
            {
                if (pipe.PipeType == PipeType.Ground)
                {
                    if (pipe.Enclosed == null &&
                        (pipe.Neighbours.Count < 4 || pipe.Neighbours.Any(x => x.Enclosed == false)))
                    {
                        pipe.Enclosed = false;
                        outsideCount++;
                    }
                }
            }
        } while (outsideCount != 0);

        // foreach (var pipe in pipeArray)
        // {
        //     if (pipe.PipeType == PipeType.Ground)
        //     {
        //         if (pipe.Enclosed == null)
        //         {
        //             pipe.Enclosed = true;
        //         }
        //     }
        // }

        foreach (var pipe in Pipes)
        {
            Console.WriteLine(string.Join(',',
                                          pipe.Select(x => x.Distance?.ToString() ?? (x.Enclosed switch
                                                                       {
                                                                           true => "IN",
                                                                           null => "UND",
                                                                           _    => "OUT"
                                                                       }))
                                              .Select(x => x.PadLeft(3))));
        }

        return pipeArray.Count(x => x.Enclosed == true);
    }
}

public class Pipe
{
    public List<Pipe> ConnectedNeighbours { get; set; }

    public Pipe(char c, int row, int col)
    {
        PipeType = c switch
                   {
                       NorthSouth => PipeType.NorthSouth,
                       EastWest   => PipeType.EastWest,
                       NorthEast  => PipeType.NorthEast,
                       NorthWest  => PipeType.NorthWest,
                       SouthWest  => PipeType.SouthWest,
                       SouthEast  => PipeType.SouthEast,
                       Ground     => PipeType.Ground,
                       Start      => PipeType.Start,
                       _          => throw new ArgumentOutOfRangeException(nameof(c), c, null)
                   };
        Coordinate = new Coordinate()
                     {
                         Row    = row,
                         Column = col
                     };
    }

    public bool HasValidNeighbours()
    {
        return ConnectedNeighbours.All(neigh => Math.Abs((Distance ?? 0) - (neigh.Distance ?? 0)) == 1);
    }

    public bool? Enclosed { get; set; }

    public bool IsConnected(Coordinate coord)
    {
        switch (PipeType)
        {
            case PipeType.NorthSouth:
            {
                if (Coordinate + Coordinate.South == coord)
                {
                    return true;
                }

                return Coordinate + Coordinate.North == coord;
            }
            case PipeType.EastWest:
                if (Coordinate + Coordinate.East == coord)
                {
                    return true;
                }

                return Coordinate + Coordinate.West == coord;
            case PipeType.NorthEast:
                if (Coordinate + Coordinate.North == coord)
                {
                    return true;
                }

                return Coordinate + Coordinate.East == coord;
            case PipeType.NorthWest:
                if (Coordinate + Coordinate.North == coord)
                {
                    return true;
                }

                return Coordinate + Coordinate.West == coord;
            case PipeType.SouthWest:
                if (Coordinate + Coordinate.South == coord)
                {
                    return true;
                }

                return Coordinate + Coordinate.West == coord;
            case PipeType.SouthEast:
                if (Coordinate + Coordinate.South == coord)
                {
                    return true;
                }

                return Coordinate + Coordinate.East == coord;
            case PipeType.Ground:
                return false;
            case PipeType.Start:
                return true;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public PipeType   PipeType   { get; }
    public Coordinate Coordinate { get; }
    public int?       Distance   { get; set; }
    public List<Pipe> Neighbours { get; set; }

    private const char NorthSouth = '|';
    private const char EastWest   = '-';
    private const char NorthEast  = 'L';
    private const char NorthWest  = 'J';
    private const char SouthWest  = '7';
    private const char SouthEast  = 'F';
    private const char Ground     = '.';
    private const char Start      = 'S';
}

public enum PipeType
{
    NorthSouth,
    EastWest,
    NorthEast,
    NorthWest,
    SouthWest,
    SouthEast,
    Ground,
    Start
}