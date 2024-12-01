using Implementations.Helpers;

namespace Implementations._2023.Aoc2;

public class Aoc2 : IAoc<int, int>
{
    private IEnumerable<string> Input { get; } = File.ReadAllLines("./Aoc2/Input.txt");

    public int SolvePart1()
    {
        return Input.Select(x => new Game(x))
            .Where(x => x.IsBagValid(new CubeSet(14, 13, 12)))
            .Select(x => x.Id)
            .Sum();
    }

    public int SolvePart2()
    {
        return Input.Select(x => new Game(x))
            .Select(x=>x.Power())
            .Sum();
    }
}