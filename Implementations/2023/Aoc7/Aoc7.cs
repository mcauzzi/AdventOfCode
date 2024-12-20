using Implementations.Helpers;

namespace Implementations._2023._07;

public class Aoc7 : BaseAoc<int, int>
{
    public Aoc7(char[][] input) : base(input)
    {
        InputAsStrings=input.Select(x=>new string(x)).ToArray();
    }

    private string[] InputAsStrings { get; }

    public override int SolvePart1()
    {
        var game = new Game(InputAsStrings);
        return game.TotalPower;
    }

    public override int SolvePart2()
    {
        var game = new GameWithJokers(InputAsStrings);
        return game.TotalPower;
    }
}