using Implementations.Helpers;

namespace Implementations._2024._08;

public class Aoc202408(char[][] input) : BaseAoc<long, long>(input)
{
    public override long SolvePart1()
    {
        var antennas = new Dictionary<char, List<Coordinate>>();
        GetAntennas(antennas);
        var antiNodes = new HashSet<Coordinate>();
        foreach (var kvp in antennas)
        {
            var antennaCoordinates = kvp.Value;
            for (var i = 0; i < antennaCoordinates.Count / 2 + 1; i++)
            {
                var currAntenna = antennaCoordinates[i];
                for (int j = i + 1; j < antennaCoordinates.Count; j++)
                {
                    var subAntenna     = antennaCoordinates[j];
                    var diff           = (currAntenna - subAntenna).Abs();
                    var currToTheRight = currAntenna.X > subAntenna.X;
                    var antinode1X     = currToTheRight ? currAntenna.X + diff.X : currAntenna.X - diff.X;
                    var antinode1Y     = currAntenna.Y - diff.Y;
                    antiNodes.Add(new Coordinate(antinode1X, antinode1Y));
                    var antinode2X = currToTheRight ? subAntenna.X - diff.X : subAntenna.X + diff.X;
                    var antinode2Y = subAntenna.Y + diff.Y;
                    antiNodes.Add(new Coordinate(antinode2X, antinode2Y));
                }
            }
        }

        return antiNodes.Count(x => !x.OutOfBounds(Input[0].Length, Input.Length));
    }

    public override long SolvePart2()
    {
        var antennas = new Dictionary<char, List<Coordinate>>();
        GetAntennas(antennas);
        var antiNodes = new HashSet<Coordinate>();
        foreach (var kvp in antennas)
        {
            var antennaCoordinates = kvp.Value;
            for (var i = 0; i < antennaCoordinates.Count / 2 + 1; i++)
            {
                var currAntenna = antennaCoordinates[i];
                antiNodes.Add(currAntenna);
                for (int j = i + 1; j < antennaCoordinates.Count; j++)
                {
                    var subAntenna     = antennaCoordinates[j];
                    antiNodes.Add(subAntenna);
                    var diff           = (currAntenna - subAntenna).Abs();
                    var currToTheRight = currAntenna.X > subAntenna.X;
                    var antiNode       = GetNewUpperAntiNode(currToTheRight, currAntenna, diff);

                    while (!antiNode.OutOfBounds(Input[0].Length, Input.Length))
                    {
                        antiNodes.Add(antiNode);
                        antiNode = GetNewUpperAntiNode(currToTheRight, antiNode, diff);
                    }
                    antiNode = GetLowerAntiNode(currToTheRight, subAntenna, diff);
                    while (!antiNode.OutOfBounds(Input[0].Length, Input.Length))
                    {
                        antiNodes.Add(antiNode);
                        antiNode = GetLowerAntiNode(currToTheRight, antiNode, diff);
                    }
                }
            }
        }

        return antiNodes.Count(x => !x.OutOfBounds(Input[0].Length, Input.Length));
    }

    private static Coordinate GetLowerAntiNode(bool currToTheRight, Coordinate subAntenna, Coordinate diff)
    {
        var antiNodeX = currToTheRight ? subAntenna.X - diff.X : subAntenna.X + diff.X; 
        var antiNodeY = subAntenna.Y + diff.Y;
        return new Coordinate(antiNodeX,antiNodeY);
    }

    private static Coordinate GetNewUpperAntiNode(bool currToTheRight, Coordinate currAntenna, Coordinate diff)
    {
        var antinode1X = currToTheRight ? currAntenna.X + diff.X : currAntenna.X - diff.X;
        var antinode1Y = currAntenna.Y - diff.Y;
        var antiNode   = new Coordinate(antinode1X, antinode1Y);
        return antiNode;
    }

    private void GetAntennas(Dictionary<char, List<Coordinate>> antennas)
    {
        for (var i = 0; i < Input.Length; i++)
        {
            var line = Input[i];
            for (var j = 0; j < line.Length; j++)
            {
                var c = line[j];
                if (c != '.')
                {
                    if (!antennas.TryGetValue(c, out var list))
                    {
                        list = new List<Coordinate>();
                        antennas.Add(c, list);
                    }

                    list.Add(new Coordinate(j, i));
                }
            }
        }
    }
}