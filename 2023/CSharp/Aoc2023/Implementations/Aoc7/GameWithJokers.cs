namespace Implementations.Aoc7;

public class GameWithJokers : Game
{
    public GameWithJokers(string[] lines) : base(lines)
    {
    }

    protected override void BuildHands(string[] lines)
    {
        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.TrimEntries);
            Hands.Add((new HandWithJokers(parts[0]), int.Parse(parts[1])));
        }
    }
}