namespace Implementations._2023._07;

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