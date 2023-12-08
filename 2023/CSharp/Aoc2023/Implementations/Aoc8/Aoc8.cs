using Implementations.Helpers;
namespace Implementations.Aoc8;

public class Aoc8 : IAoc<int, long>
{
    private string[] Input { get; } = File.ReadAllLines("./Aoc8/Input.txt");

    public int SolvePart1()
    {
        var instructions = new Instructions(Input[0]);
        var map          = new Map(Input.Skip(2));
        var currentPos   = "AAA";
        var steps        = 0;
        while (currentPos != "ZZZ")
        {
            var nextPositions   = map.GetNextPositions(currentPos);
            var nextInstruction = instructions.GetNextStep();
            currentPos = nextInstruction == 'R' ? nextPositions[1] : nextPositions[0];
            steps++;
        }

        return steps;
    }

    public long SolvePart2()
    {
        var map              = new Map(Input.Skip(2));
        var currentPositions = map.GetAllStartingPositions();
        var instructionsSet  = Enumerable.Range(0, currentPositions.Length).Select(x => new Instructions(Input[0])).ToArray();
        var currentSteps =Enumerable.Range(0, currentPositions.Length).Select(x => 0L).ToList();
        var loopsList = new List<List<string>>();
        for (int i = 0; i < currentPositions.Length; i++)
        {
            loopsList.Add(FindLoop(i, currentPositions, instructionsSet, currentSteps,map));
        }

        return currentSteps.Lcm();
    }

    private List<string> FindLoop(int i, string[] currentPositions, Instructions[] instructionsSet, IList<long> currentSteps,
                                  Map map)
    {
        var res = new List<string>();
        while (currentPositions[i][2] != 'Z')
        {
            var nextPositions   = map.GetNextPositions(currentPositions[i]);
            var nextInstruction = instructionsSet[i].GetNextStep();
            currentPositions[i] = nextInstruction == 'R' ? nextPositions[1] : nextPositions[0];
        }
        res.Add(currentPositions[i]);
        var firstIndex = instructionsSet[i].CurrentIndex;
        do
        {
            do
            {
                var nextPositions   = map.GetNextPositions(currentPositions[i]);
                var nextInstruction = instructionsSet[i].GetNextStep();
                currentPositions[i] = nextInstruction == 'R' ? nextPositions[1] : nextPositions[0];
                currentSteps[i]++;
            } while (currentPositions[i][2] != 'Z');
            
            res.Add(currentPositions[i]);
        } while (currentPositions[i] != res.FirstOrDefault()||firstIndex!=instructionsSet[i].CurrentIndex);

        return res;
    }

    private static bool IsValidEnd(string[] currentPositions)
    {
        for (int i = 0; i < currentPositions.Length; i++)
        {
            if (currentPositions[i][2] != 'Z')
            {
                return false;
            }
        }

        return true;
    }
}