using Implementations.Helpers;

namespace Implementations._2023.Aoc6;

public class Aoc6 :IAoc<long,long>
{
    public Aoc6(char[][] input) : base(input)
    {
        InputAsStrings=input.Select(x=>new string(x)).ToArray();
    }

    private string[] InputAsStrings { get; }
    public override long SolvePart1()
    {
        var times = InputAsStrings[0].Split(':', StringSplitOptions.TrimEntries)[1]
                            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        var record = InputAsStrings[1].Split(':', StringSplitOptions.TrimEntries)[1]
                            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        var races                     = times.Zip(record);
        var winningChargeTimesPerRace =new int[races.Count()];
        var raceIndex                 = 0;
        foreach (var race in races)
        {
            Console.WriteLine($"Race time {race.First}, record distance {race.Second}");
            for (int i = 1; i <= race.First; i++)
            {
                var actualRaceTime = race.First - i;
                var raceDistance   = i * actualRaceTime;
                if (raceDistance > race.Second)
                {
                    winningChargeTimesPerRace[raceIndex]++;
                }
            }

            raceIndex++;
        }

        return winningChargeTimesPerRace.Aggregate((res,next)=>res*next);
    }

    public override long SolvePart2()
    {
        var times = InputAsStrings[0].Split(':', StringSplitOptions.TrimEntries)[1]
                            .Replace(" ","").Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
        var record = InputAsStrings[1].Split(':', StringSplitOptions.TrimEntries)[1]
                             .Replace(" ","").Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
        var races                     = times.Zip(record);
        var winningChargeTimesPerRace =new long[races.Count()];
        var raceIndex                 = 0;
        foreach (var race in races)
        {
            Console.WriteLine($"Race time {race.First}, record distance {race.Second}");
            for (int i = 1; i <= race.First; i++)
            {
                var actualRaceTime = race.First - i;
                var raceDistance   = i * actualRaceTime;
                if (raceDistance > race.Second)
                {
                    winningChargeTimesPerRace[raceIndex]++;
                }
            }

            raceIndex++;
        }

        return winningChargeTimesPerRace.Aggregate((res, next)=>res*next);
    }
}