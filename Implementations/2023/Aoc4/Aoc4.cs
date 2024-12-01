using Implementations.Helpers;

namespace Implementations._2023.Aoc4;

public class Aoc4 : IAoc<int, int>
{
    private string[] Input { get; } = File.ReadAllLines("./Aoc4/Input.txt");

    public int SolvePart1()
    {
        var totalSum = 0;
        foreach (var line in Input)
        {
            var firstSplit  = line.Split(':');
            var cardName    = firstSplit[0];
            var cardNumbers = firstSplit[1].Split('|');
            var winningNumbers = cardNumbers[0].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x))
                                               .Select(x => int.Parse(x.Trim()));
            var myNumbers = cardNumbers[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x))
                                          .Select(x => int.Parse(x.Trim()));
            var isWinner   = myNumbers.Select(x => winningNumbers.Contains(x));
            var linePoints = isWinner.Aggregate(0, (res, curr) => res == 0 && curr ? 1 : curr ? res * 2 : res);
            totalSum += linePoints;
        }

        return totalSum;
    }

    public int SolvePart2()
    {
        var startingInput = Input.Select(x => new BingoGame(int.Parse(x.Split(':')[0].Split(' ')
                                                                       .Where(x => !string.IsNullOrEmpty(x)).ToList()[1]
                                                                       .Trim()),
                                                            x.Split(':')[1].Split('|')[0].Trim()
                                                                .Split(' ')
                                                                .Where(x => !string.IsNullOrEmpty(x))
                                                                .Select(x => int.Parse(x.Trim())).ToArray(),
                                                            x.Split(':')[1].Split('|')[1].Trim().Split(' ')
                                                             .Where(x => !string.IsNullOrEmpty(x))
                                                             .Select(x => int.Parse(x.Trim())).ToArray())).ToList();
        var outPut = startingInput.Select(x=>x.CardId).ToList();
        for (int i = 0; i < outPut.Count(); i++)
        {
            var curr            = startingInput[outPut[i]-1];
            for (int j = 1; j <= curr.Winners.Count(); j++)
            {
                outPut.Add(curr.CardId + j);
            }
        }

        return outPut.Count;
    }
}

public record BingoGame
{
    public BingoGame(int cardId, int[] winningNumbers, int[] myNumbers)
    {
        CardId         = cardId;
        WinningNumbers = winningNumbers;
        MyNumbers = myNumbers;
        Winners=MyNumbers.Select(x => WinningNumbers.Contains(x)).Where(x => x).ToList();
    }

    public List<bool> Winners { get; set; }

    public int   CardId         { get; init; } 
    public int[] WinningNumbers { get; init; } 
    public int[] MyNumbers      { get; init; }
}