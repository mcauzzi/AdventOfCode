namespace Implementations._2023._07;

public class Game
{
    protected List<(Hand Hand, int Bid)> Hands      { get; } = [];
    public    int                        TotalPower =>Hands.Order().Select((x, y) => x.Bid * (y + 1)).Sum();
    public Game(string[] lines)
    {
        BuildHands(lines);
    }

    protected virtual void BuildHands(string[] lines)
    {
        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.TrimEntries);
            Hands.Add((new Hand(parts[0]), int.Parse(parts[1])));
        }
    }

    public override string ToString()
    {
        return $"{nameof(Hands)}: {string.Join('\n',Hands.Order())}\n {nameof(TotalPower)}: {TotalPower}";
    }
}