using Implementations.Helpers;

namespace Implementations._2023._02;

public class Aoc2 : BaseAoc<int, int>
{
    public Aoc2(char[][] input) : base(input)
    {
        InputAsStrings = input.Select(x => new string(x)).ToArray();
    }
    private string[] InputAsStrings { get; }

    public override int SolvePart1()
    {
        return InputAsStrings.Select(x => new Game(x))
                             .Where(x => x.IsBagValid(new CubeSet(14, 13, 12)))
                             .Select(x => x.Id)
                             .Sum();
    }

    public override int SolvePart2()
    {
        return InputAsStrings.Select(x => new Game(x))
                             .Select(x=>x.Power())
                             .Sum();
    }
}