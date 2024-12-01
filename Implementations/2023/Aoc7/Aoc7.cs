using Implementations.Helpers;

namespace Implementations._2023.Aoc7;

public class Aoc7 : IAoc<int, int>
{
    private string[] Input { get; } = File.ReadAllLines("./Aoc7/Input.txt");

    public int SolvePart1()
    {
        var game = new Game(Input);
        return game.TotalPower;
    }

    public int SolvePart2()
    {
        var game = new GameWithJokers(Input);
        return game.TotalPower;
    }
}