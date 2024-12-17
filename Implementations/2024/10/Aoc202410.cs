using Implementations.Helpers;

namespace Implementations._2024._10;

public class Aoc202410 : IAoc<long, long>
{
    public Aoc202410()
    {
        Input = File.ReadAllLines("2024/10/Input.txt")
                    .Select(x => x.Select(x => int.Parse(x.ToString())).ToArray())
                    .ToArray();
    }

    public int[][] Input { get; set; }

    public long SolvePart1()
    {
        var trailHeads = new List<Coordinate>();
        for (int i = 0; i < Input.Length; i++)
        {
            var currLine = Input[i];
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
        if (head.OutOfBounds(Input[0].Length, Input.Length))
        {
            return;
        }

        var currValue = Input[head.Y][head.X];
        if (currValue == 9)
        {
            trailTails.Add(head);
            return;
        }

        foreach (var coordinate in Coordinate._4DirectionsVectors)
        {
            var nextStep = head + coordinate.Value;
            if (nextStep.OutOfBounds(Input[0].Length, Input.Length))
            {
                continue;
            }

            var nextValue = Input[nextStep.Y][nextStep.X];

            if ((nextValue - currValue) != 1)
            {
                continue;
            }

            SearchTrails(nextStep, trailTails);
        }
    }

    public long SolvePart2()
    {
        var trailHeads = new List<Coordinate>();
        for (int i = 0; i < Input.Length; i++)
        {
            var currLine = Input[i];
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