using Implementations.Helpers;

namespace Implementations._2024._10;

public class Aoc202410 : BaseAoc<long, long>
{
    public Aoc202410(char[][] input) : base(input)
    {
        InputAsIntMatrix = Input
                    .Select(x => x.Select(x => int.Parse(x.ToString())).ToArray())
                    .ToArray();
    }

    public int[][] InputAsIntMatrix { get; set; }

    public override long SolvePart1()
    {
        var trailHeads = new List<Coordinate>();
        for (int i = 0; i < InputAsIntMatrix.Length; i++)
        {
            var currLine = InputAsIntMatrix[i];
            for (int j = 0; j < currLine.Length; j++)
            {
                if (currLine[j] == 0)
                {
                    trailHeads.Add(new Coordinate(j, i));
                }
            }
        }

        var trailsTails = new Dictionary<Coordinate, List<Coordinate>>();
        for (var i = 0; i < trailHeads.Count; i++)
        {
            var head  = trailHeads[i];
            var tails = new List<Coordinate>();
            SearchTrails(head, tails);
            trailsTails.Add(head,tails);
        }

        return trailsTails.SelectMany(x=>x.Value.Distinct()).Count();
    }

    private void SearchTrails(Coordinate head, List<Coordinate> trailTails)
    {
        if (head.OutOfBounds(InputAsIntMatrix[0].Length, InputAsIntMatrix.Length))
        {
            return;
        }

        var currValue = InputAsIntMatrix[head.Y][head.X];
        if (currValue == 9)
        {
            trailTails.Add(head);
            return;
        }

        foreach (var coordinate in Coordinate._4DirectionsVectors)
        {
            var nextStep = head + coordinate.Value;
            if (nextStep.OutOfBounds(InputAsIntMatrix[0].Length, InputAsIntMatrix.Length))
            {
                continue;
            }

            var nextValue = InputAsIntMatrix[nextStep.Y][nextStep.X];

            if ((nextValue - currValue) != 1)
            {
                continue;
            }

            SearchTrails(nextStep, trailTails);
        }
    }

    public override long SolvePart2()
    {
        var trailHeads = new List<Coordinate>();
        for (int i = 0; i < InputAsIntMatrix.Length; i++)
        {
            var currLine = InputAsIntMatrix[i];
            for (int j = 0; j < currLine.Length; j++)
            {
                if (currLine[j] == 0)
                {
                    trailHeads.Add(new Coordinate(j, i));
                }
            }
        }

        var trailsTails = new Dictionary<Coordinate, List<Coordinate>>();
        for (var i = 0; i < trailHeads.Count; i++)
        {
            var head  = trailHeads[i];
            var tails = new List<Coordinate>();
            SearchTrails(head, tails);
            trailsTails.Add(head,tails);
        }

        return trailsTails.SelectMany(x=>x.Value).Count();
    }
}