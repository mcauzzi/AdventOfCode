namespace AdventOfCode.AocImplementations;

public class Aoc2 : IAoc<int, int>
{
    #region Input
    private string Input = @"A X
A X
B Y
B Y
A Y
A X
A Y
A X
A X
B Y
A X
A X
A X
A X
C X
C Z
A X
B Y
A X
A X
C X
C Y
A X
A Z
B Y
A X
C X
A X
B Y
A X
A X
A X
A Z
C X
C X
C X
B Y
B X
B Z
B Y
C X
A Y
A X
A X
B X
A X
A X
B Y
C X
B Y
A X
A X
A X
C X
B Y
C X
B Y
A X
C X
B Y
B X
B Y
C Z
A X
A Y
C Z
C X
A X
C X
A X
A X
C Z
B Y
C X
B X
B X
C X
A X
A X
A X
C Z
C X
B Y
A X
C X
B Z
A X
C Z
C Z
A X
A X
A X
A Y
A X
A X
B Y
A X
C Z
C Z
A X
A X
C X
A Y
A Y
A X
A X
A X
B Z
A X
A Z
A X
A X
A X
C Z
C Z
A X
B Y
C Z
A X
A X
A X
A X
A Y
B Y
A Z
A X
A X
A X
A Z
A X
C Z
C Z
C X
C Z
A X
B Y
C Y
A X
B Y
A X
A X
A X
A X
A X
C X
A X
A X
B X
A X
B Y
A X
B Y
A X
B Y
B Y
C X
A X
A X
A X
A Z
C X
A Y
C X
C X
B Y
A X
A X
C Z
A X
C X
B Y
A Y
A X
A X
B Y
A X
A X
C X
A Z
A X
A X
A X
B Y
B Y
B Z
A Z
A X
B Y
B Y
A X
A X
A X
B Z
C Z
A X
A Y
A X
A X
A X
A X
C X
A Y
A X
B Z
C Z
C Z
A X
C X
B Y
A X
A X
B Y
A X
B Y
B Y
A X
A X
A X
A X
A X
B Y
B Y
A X
B X
C X
A X
B Y
A X
A X
A X
B Y
B Y
A Z
C Z
B X
C X
A X
A X
B Y
A Y
A X
A X
A X
A Z
B Y
A X
A Y
A X
A X
A X
A Z
A X
B Y
A X
A X
C X
B Y
B Y
B Y
A X
A Y
B Y
B Y
A X
B Y
A Y
A Y
A X
A X
B Y
A X
A X
A X
A Y
B Y
A Z
A X
C Z
A X
A Y
A Z
A X
A Z
A X
A X
A X
A Z
C X
A X
A X
C Z
A X
A X
C X
C Z
B Y
B Y
C Z
C X
A X
C Z
A Z
B Y
B Y
C Z
C X
A X
C Z
A X
A X
A Y
A X
B Y
B Y
C Y
A X
C X
A X
C X
A X
A Y
A X
C X
C Z
C X
B Y
A X
A X
A Z
C Z
A X
B Y
A X
B X
C Z
C Z
B Z
B Y
A X
A X
A X
A X
C Z
C Z
A X
A X
A X
C X
A X
A X
A X
B Y
A Y
A X
C X
C Z
A X
C Z
B Y
A X
A X
A Y
A X
B Y
C X
A X
A Y
A Y
B X
A Y
C Z
B Y
A X
C Z
C X
B Y
B Y
B Y
A X
A X
A X
A X
A X
A X
A X
A Y
A X
B Z
A X
A X
A X
C Z
A X
A X
A X
A X
A X
A X
B Y
C X
B Y
A X
A X
A X
A X
C Z
A X
A X
C X
A X
A X
B Y
A X
B X
A X
A X
A X
A Y
B X
B Y
B Y
A X
C X
A X
A Y
B Z
A Y
A Z
B Y
B Y
A X
A Y
A X
B Y
A X
B Z
A X
A X
A X
A X
A X
B Y
B Y
A X
A X
B Y
A Y
A X
B Z
A X
A X
A X
A X
B Z
B Y
A X
C X
A X
A X
A X
B Y
C Z
C Z
B Y
B Y
A X
B Y
A Y
C X
A X
A X
A X
A Y
C Z
A X
A Z
B Y
B Y
B Y
A X
B Z
C Z
A X
A Y
C Z
A X
B Y
A X
B Y
A Z
A X
A X
A X
A Y
A X
A X
B Y
A X
C X
C Z
A X
A X
C Z
A X
C X
A X
A X
A X
C Z
A X
A X
B Y
A X
C X
B Y
A X
B Y
A X
A X
A X
A X
C Z
B Y
A X
A X
A X
A X
A X
A X
C X
A X
A X
B Y
A X
B Y
A X
A X
C X
A X
A X
A X
A X
C Z
B Y
C Z
C X
A Y
A X
A X
A X
C X
A Y
A X
A X
A X
A X
A X
C Z
A X
A X
A X
B Y
A Z
A X
A X
C Z
B X
A Z
A X
B Y
B Y
B Y
B Y
B Y
A X
B Y
A X
A X
A Z
B X
B Y
A X
C Y
A X
A X
A X
A X
B Y
C X
A Y
A X
A X
B Z
A X
B Y
A Z
A Y
A X
A X
C X
A Y
C X
A X
A Y
A X
B Y
C X
A X
C Z
A X
A X
A X
A X
A X
B X
C Y
B Y
A X
C X
C X
A X
C X
C Z
A X
A X
A X
B Y
C X
B Y
B Y
A X
A X
C X
A X
C Z
A X
A Y
A X
B Y
A X
A X
A X
A X
C Z
A X
B Y
B Y
A X
B Y
A X
A Z
A X
C Y
B Y
A X
A X
C X
B Y
B Y
A Y
A X
C Y
B Y
A Y
A X
A Z
C Y
A X
A X
A Y
C X
C Y
A X
B Y
A X
A X
C Z
A Z
C Z
A Y
A X
A X
C X
C Z
A Z
B Y
B Y
B Y
A X
A Z
C X
A X
A X
B Y
A X
A X
C Z
A Y
A Y
C Z
A X
A X
C Y
B Z
A Y
A Z
A X
C X
A X
A X
A X
A X
B Y
B Y
C Z
A X
C X
B Y
A X
A X
A X
A X
A X
A X
A X
A X
C Z
A Y
C X
C Z
A X
A X
A Y
A X
A X
C X
C X
B Y
A X
B Y
B Y
A Z
A X
A Y
A Y
A X
A X
A X
B Y
B X
A X
B Y
B Y
A X
A Y
A Y
A X
C Z
A X
A X
A Z
C Z
B Z
A X
A X
A X
A Y
C X
A X
B Y
A X
B Z
A Y
A X
B Y
A X
C X
A X
B Y
A X
C X
C X
C Z
A X
A X
C Y
A X
B Y
A X
B X
A X
B X
A X
A Y
A X
C X
C X
A X
A X
A Y
A X
A X
C X
A X
B Y
A X
A X
C Y
A X
A X
A X
C X
A X
B Z
A X
A Z
A X
A X
A Z
A X
A X
A X
A Y
B Y
A X
A X
A X
B Z
B Y
A Z
B X
B Y
A X
C X
B Y
A X
A X
B Y
A X
C X
A Z
A X
A Z
A Z
B Y
A X
C X
C Z
A X
B Y
A X
B Y
C Z
A X
C Z
B Y
C X
C X
C Z
B Y
A X
B Y
C X
C X
A X
B Y
A X
A X
A Y
C Z
B Y
A X
A Z
A Y
A X
A Y
C X
A X
A X
A X
C X
A X
A X
A X
B Y
C Y
B Y
A X
B Y
B Y
A X
A X
A X
A X
A X
C Z
B Y
B X
B Y
A X
A Z
A X
A X
B Y
B Y
C X
C Z
A X
C Z
B Y
A Z
A X
A X
A X
A X
B Z
B Y
A X
A X
A X
A X
A X
B Y
B X
B Y
C X
B Y
C X
B Y
A X
A X
B Y
A X
C Z
B Y
C X
A Z
B Y
B Y
A X
B Y
A X
A Y
B Y
B Y
B Z
C Z
A X
C X
A Y
B X
A X
A X
A X
C Z
B Y
B Y
A Y
B Y
A X
B Y
A X
C X
A X
A X
A X
A Y
A Y
A Z
A X
B Y
A X
A X
A X
A X
A X
A X
A Z
A X
A X
B Y
C Z
C X
C Z
B Y
A X
A Z
A Z
A Y
B X
A X
A X
C Y
A Z
A X
A X
B Y
A X
B X
A Z
A X
A X
A X
A X
A Y
A X
A Z
A X
B Y
B Z
C Z
A Y
B Y
A Y
C X
B Y
B Y
A Z
A X
A X
A Y
A X
A X
A X
A X
C Z
B X
A X
B Y
C X
A X
A X
C X
B Y
C Z
C Z
B Y
C X
A X
C Z
B Y
A X
C Z
A Y
B Y
A X
A Z
A Z
B Z
A X
A Z
A X
C Z
C X
A X
C X
A Y
C X
A X
A X
A Z
B Z
B Y
B Y
A X
A X
A X
A Z
A X
B Y
C Z
A X
A X
A Z
A X
B Y
B Y
C X
A X
A X
A X
C Z
C X
B Y
A X
A X
B Y
C Z
B Y
A Y
A X
C X
A Z
A X
A X
A X
C X
A X
A X
A X
A X
C Z
B Y
A X
A X
C Z
C X
B Y
B Y
C X
B Y
A X
A X
A X
C X
A X
A X
A Z
A X
A X
B Z
A X
C X
B Y
A Z
B Y
A X
A X
B Z
A X
A X
A X
B Y
A X
A X
A X
A X
B Y
A Y
A X
B X
A X
A X
A X
A X
C Z
B Y
A X
C Z
C Z
B Y
C Z
A X
A Y
B Y
B Y
A X
A X
A X
A X
A X
A X
B Y
A Y
B Y
A X
B Y
B Y
B Z
A Y
B Y
C Z
A X
A X
B Y
A X
A X
A X
A Y
A X
A X
B Y
A Y
A X
A X
A X
B Y
A X
C X
A X
C X
B Y
C X
A X
B Y
A Z
A X
A X
B Y
A X
A X
A X
B X
A X
A X
A X
B Y
A Z
B Y
B Y
C X
C X
B Y
A Y
A X
B Y
A X
B Z
A X
A X
B Y
A Y
A X
A Y
A X
C Z
A X
C Z
B Y
A Y
B Y
A X
A Z
A X
B Y
B X
B Y
A X
A Y
A X
A X
A X
A X
C X
A X
B Y
C X
A Y
B Y
B Y
A X
A X
C Z
A X
C X
B Y
A X
A X
B Y
A Y
A X
A Z
A X
C X
B Y
B Y
C X
A X
B Y
A X
B Y
C X
A X
B Y
A X
A Z
A X
C X
A Z
A X
A X
A Y
A X
A X
A X
A Y
A X
A X
A X
A X
A X
B Y
C X
C Z
C X
A X
B Y
C Z
B X
A X
A X
B Y
A X
A X
C Z
C X
C X
A X
A Y
B Y
A Y
C X
B Y
A X
A X
A Y
A X
A X
B X
C X
A Y
B Y
B Y
A X
B Y
A X
A Y
A X
A X
B Y
B Y
A X
B Y
A X
C X
C X
C Z
A X
A X
A X
B Y
C X
A X
A X
B Y
A X
C X
A Y
A X
A X
A X
C X
A X
A Z
A X
A X
A X
A Y
C Z
A Y
A X
B Z
A X
A X
B Y
C Z
A X
B Y
B Y
A X
B Y
A Y
A X
B Y
B Y
A X
C Z
B Y
A X
B Z
C Z
B Y
A X
C Z
A X
A X
A Z
A X
A X
A X
A X
A X
A X
C Z
A X
A X
B X
A X
A X
A X
A Z
A X
C X
A X
C Y
A X
B X
C X
A X
B Y
B Y
A X
C X
A X
A X
A X
A Y
A X
B Y
C Z
B Y
A Z
A X
A X
A Z
C Z
C X
C X
B Y
C X
A X
A X
A X
A X
B Y
A X
A X
A Y
C X
A X
C X
A X
A X
A X
C X
C X
A X
A X
B Y
A X
A X
A X
A Y
B Y
A X
A X
C X
A X
B Y
C X
C Y
C X
B Y
B Z
A X
A X
A Z
C X
A X
A X
A X
A X
A X
B Z
A Z
A X
A X
A X
A X
A Y
A X
C X
A Z
A X
A Z
C X
A X
A X
A X
A Z
A Y
A X
C Z
A X
A X
B Y
A X
A X
A X
A Y
B Y
A X
B Y
B Y
C Z
B Y
A X
A X
A X
A X
A X
A X
A Y
A X
A X
B Y
A Y
A X
A X
C X
A X
B Y
A X
B Y
A X
A X
C X
A Y
A X
C X
B Y
C X
A X
A X
A X
C X
A X
A X
A X
C Z
A X
A X
B Y
A X
A X
A X
A X
C Z
A X
C Z
B Y
C X
A X
A Y
A X
A Z
A X
C X
C Z
A X
C X
A X
A X
A X
A X
C Z
B Y
A X
C X
B Y
C X
C Z
C Z
C X
C Z
C Z
A Y
A Z
C Z
A X
A Y
A Y
A X
A X
B Y
A X
B Y
A X
A Y
C X
A X
A X
A X
C Z
C Z
B Y
A X
B Y
C X
A X
A X
A X
A Y
B Y
A X
C X
C Y
C X
A X
A X
C Z
B Y
A X
B Y
A X
A X
C Z
B Y
A X
A Z
C Y
A Z
A X
C X
A Y
A X
C Z
C X
A X
A X
A X
A X
A X
A X
A X
A Y
A X
A X
A X
C X
C X
B Y
B Y
A X
B Y
A X
C X
C Z
C X
B Y
C X
B Y
B Y
A X
B X
C Z
A X
A X
B Y
A X
B Y
A X
B Y
A X
A X
A X
A X
A X
A X
A X
A X
A X
C Z
A X
A X
A X
A X
B Y
A X
B Y
B Y
C Y
B Y
A X
B Y
B Y
C X
C Z
C X
C Z
A X
C X
A X
A X
A Y
A X
B Y
A X
B Y
B Y
B Y
A X
A X
A X
A X
A X
B Y
A X
C X
B Y
C X
A X
A X
C X
B Y
C Z
C X
B Y
A X
A X
B Y
A X
A X
A Y
C Z
A X
B Y
B Y
A X
B Y
C Z
A Z
A Y
A X
B Y
A Y
B Y
B Y
C Z
A Y
A X
A Y
B Y
A X
A X
C Z
A X
B Y
A X
B Y
B Y
A X
A X
A X
B Y
B Y
A X
A X
C X
B Z
A X
B X
B Y
C Z
B Y
C Z
C Z
A X
A Z
A X
A X
A X
A X
A X
B Z
B Y
C X
A X
A X
B Y
C X
C Z
B Y
C X
B Y
A X
A X
C Z
A X
A Y
B Y
A X
A X
A X
A X
A X
A X
A X
B Y
A Y
B Y
B Y
A X
B Y
A Z
B Y
A X
A X
A X
C Z
C X
C X
B Y
A X
C Z
C X
A X
A X
C Z
A X
A X
A Z
C Z
B Y
C X
A X
A X
B Y
A Y
A X
A Z
C Z
A X
C Y
A X
B Y
A X
B Z
A X
A X
A X
A Y
C X
A X
A Z
B Y
A X
A X
B Y
C X
C Z
A Y
C Z
A Z
B Y
A X
A X
C Z
A Z
C X
A X
A Y
A X
A X
A Y
A X
A X
A Z
A X
A X
A Y
C X
A X
A X
A Y
B Y
A X
B Y
B Y
A X
C X
A X
A X
C X
A Y
A X
A X
B Y
A X
C X
C Z
B Y
C X
A Y
A Y
A X
A X
A X
B Y
B Z
A X
A X
B Y
B Y
B Y
C Z
B Y
B Y
A X
B Z
A X
A X
A X
A X
B Y
A X
C X
B Y
B Y
A X
A X
B Y
B Y
B X
A X
A X
A X
A X
C Z
A X
A X
B Y
A X
A X
B Y
C X
B Y
A X
A X
B Y
A X
A X
A X
C Z
B Y
B Y
A Y
B X
A X
B Y
C Z
A X
A X
C Z
A X
A X
A Y
C X
A X
C X
A Y
A Y
A X
A Z
A X
C X
C Z
C X
B Y
A X
C Z
A Z
B X
B Y
C Z
C X
C X
B Y
A Y
B Y
A X
A X
A Z
B Y
A X
A X
A Y
A X
A X
B Y
B Z
B Y
A X
A X
A Y
A X
A X
A Y
B Y
C Z
C Z
C Z
B Y
A X
A X
B Y
C X
A X
A X
A Y
A X
B Y
B X
A X
C Z
A X
A X
A X
A Y
A X
C X
A X
A X
C Z
A X
A X
A X
A X
A Z
B Y
A X
A X
C X
C X
C X
B Y
A X
A X
A X
B Y
B Y
A X
C X
C Y
A X
A X
A X
B Y
B Y
A X
A X
A Z
A X
A Y
A X
B Y
A Z
B Y
C X
A Z
C X
B Y
A X
A X
B Y
A X
C Z
B Y
B Y
A X
B X
A X
B Y
B Y
A X
A X
A X
A X
A Y
B Y
A Y
B Y
B Y
C X
A Z
A X
A X
A X
A X
C Z
A X
A X
C X
C X
A Z
A X
A Z
C X
C Z
B Y
B Y
A Z
B Y
B Y
B Y
A X
C X
C X
A Y
B Y
A X
A X
A X
B Y
C Z
C X
A Z
A X
C Z
A X
A X
C X
A X
B Y
A X
A Z
B Y
A X
A X
A X
C X
A X
A X
A X
A X
A X
A X
B Y
B Y
B Y
B X
A X
A Z
C X
A X
B Y
A X
A X
C Z
C X
B Y
A X
A X
A X
C X
A X
A X
B Y
A X
C Y
A Y
A Z
B Y
A Y
B Y
B Y
A X
A X
A X
A X
A X
A X
A Y
A X
C X
C X
C X
C Z
A Z
A X
B Z
B Y
B Y
A Z
A X
A X
C Z
B Y
B Y
C X
A X
B Y
B Y
A X
C X
C Z
B Y
B Y
B Y
A X
B Y
B Y
A X
A X
A X
A X
B Y
B Y
B Y
A X
A X
A X
B Y
B Y
A X
A X
C X
A Y
B Z
C X
A X
A Y
A X
A X
C Z
A X
C X
B Y
A X
C Z
C Y
A X
C Z
A Z
C Z
C X
B Y
B Y
A X
B Z
A X
A X
B X
A X
A X
A X
A X
C Z
C X
A X
B Y
A X
C X
A X
B Y
C Z
A X
C X
A Y
A X
A X
A X
A X
A X
B Y
B Y
A X
A X
B Y
B Y
C Z
C X
A X
A X
B Z
A X
A X
A Z
A X
A X
A X
A X
C X
A X
A X
A X
B Z
C Z
B Y
B Y
C Z
C X
A X
A X
B Y
A X
A X
B Y
A X
A Y
C X
B Y
A X
C X
A X
B Y
C X
B Y
A X
C X
A X
A X
C X
A X
C X
A X
C X
A X
A X
B Y
A X
A X
A X
A X
A X
A X
A X
A Y
A X
A X
C X
B Y
C Z
A X
B Y
A X
B Y
C Z
C Z
B Y
A X
A X
A X
A X
A Y
A X
A Z
A X
C Y
C X
C Z
A X
A X
A X
A X
A X
C Z
C X
A X
A X
B Z
A X
C X
A Z
B Y
C Z
A X
A X
A Z
B Y
A X
B Z
A X
A X
A Y
A X
A X
C Z
A X
B Y
B X
A X
C X
A X
C X
B Y
A X
A X
B Z
A X
A X
B Y
B Y
A Z
C X
A X
A X
A Z
A X
A Z
A X
A X
A X
B Y
A X
C X
C X
A Z
B Y
B Y
A X
A X
A X
A X
A X
A X
C X
A X
A Y
C X
A X
A X
A X
C X
A X
A X
A X
A X
A X
B Z
A X
A X
C Y
B Y
C X
A X
A X
A X
A X
A X
C X
A Y
B Y
A X
A X
A X
A Y
A X
C X
A Z
A X
C Z
C X
A X
A X
A X
A X
C X
C X
B Y
A Z
A Y
B Y
C X
C Z
B Y
B Y
A X
C X
A X
A Y
B Y
A X
C X
C X
B Y
A X
B Y
A Y
A X
B X
A X
A X
B Y
A X
B X
B Y
A X
C Z
A X
A Z
A X
A X
C X
A Y
A X
C X
A X
A X
A X";
#endregion
    public int RunFirstPart()
    {
        var games = Input.Split("\n");
        var res   = 0;
        foreach (var game in games)
        {
            var player1 = game.Split(" ")[0];
            var player2 = game.Split(" ")[1].Trim();
            res += GetGameResult(player1, player2);
        }

        return res;
    }

    private int GetGameResult(string player1, string player2)
    {
        var res = player2 switch
                  {
                      "X" => 1,
                      "Y" => 2,
                      _   => 3
                  };
        if ((player1 == "A" && player2 == "X") || (player1 == "B" && player2 == "Y") ||
            (player1 == "C" && player2 == "Z"))
        {
            return res + 3;
        }

        if ((player2 == "X" && player1 == "C") || (player2 == "Y" && player1 == "A") ||
            (player2 == "Z" && player1 == "B"))
        {
            return res + 6;
        }

        return res;
    }

    public int RunSecondPart()
    {
        var games = Input.Split("\n");
        var res   = 0;
        foreach (var game in games)
        {
            var player1 = game.Split(" ")[0];
            var result  = game.Split(" ")[1].Trim();
            res += GetGameResultPart2(player1, result);
        }

        return res;
    }

    private int GetGameResultPart2(string player1, string result)
    {
        var res = result switch
                  {
                      "X" => 0,
                      "Y" => 3,
                      _   => 6
                  };
        return result switch
               {
                   "X" => res + (player1 switch
                                 {
                                     "A" => 3,
                                     "B" => 1,
                                     _   => 2
                                 }),
                   "Y" => res + (player1 switch
                                 {
                                     "A" => 1,
                                     "B" => 2,
                                     _   => 3
                                 }),
                   _ => res + (player1 switch
                               {
                                   "A" => 2,
                                   "B" => 3,
                                   _   => 1
                               })
               };
    }
}