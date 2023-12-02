namespace Implementations.Aoc2;

public class Game
{
    private List<CubeSet> Sets { get;  }
    public int Id { get; private init; }

    public Game(string str)
    {
        var split = str.Split(':');
        Id = int.Parse(split[0].Replace("Game ", ""));
        Sets = split[1].Split(";").Select(x => new CubeSet(x)).ToList();
    }

    public bool IsBagValid(CubeSet bag)
    {
        return Sets.All(x => (bag - x).IsValid);
    }

    public int Power() => Sets.Select(x => x.Blue).Max()
                          * Sets.Select(x => x.Red).Max()
                          * Sets.Select(x => x.Green).Max();
}