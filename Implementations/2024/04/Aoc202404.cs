using Implementations.Helpers;
using Implementations.Helpers.Enums;

namespace Implementations._2024._04;

public class Aoc202404 : IAoc<long, long>
{
    public Aoc202404()
    {
        Input = File.ReadAllLines("2024/04/Input.txt");
    }

    public string[] Input { get; set; }

    public long SolvePart1()
    {
        var word      = "XMAS";
        var wordCount = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            var currLine = Input[i];
            for (int j = 0; j < currLine.Length; j++)
            {
                if (currLine[j] != word[0]) continue;
                wordCount += Enum.GetValues(typeof(Directions))
                                 .Cast<Directions>()
                                 .Count(dir => SearchWord(i, j, word, dir));
            }
        }

        return wordCount;
    }

    private bool SearchWord(int i, int j, string word, Directions dir)
    {
        var wordI        = i;
        var wordJ        = j;
        var charsMatched = 0;
        while (wordI >= 0 && wordJ >= 0 && wordI < Input.Length && wordJ < Input[wordI].Length)
        {
            if (Input[wordI][wordJ] == word[charsMatched])
            {
                charsMatched++;
                if (charsMatched == word.Length)
                {
                    return true;
                }

                switch (dir)
                {
                    case Directions.UP:
                        wordI--;
                        break;
                    case Directions.LEFT:
                        wordJ--;
                        break;
                    case Directions.RIGHT:
                        wordJ++;
                        break;
                    case Directions.DOWN:
                        wordI++;
                        break;
                    case Directions.UPLEFT:
                        wordI--;
                        wordJ--;
                        break;
                    case Directions.UPRIGHT:
                        wordI--;
                        wordJ++;
                        break;
                    case Directions.DOWNLEFT:
                        wordI++;
                        wordJ--;
                        break;
                    case Directions.DOWNRIGHT:
                        wordI++;
                        wordJ++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
                }
            }
            else
            {
                return false;
            }
        }

        return false;
    }


    public long SolvePart2()
    {
        var words      = new[] { "MAS", "SAM" };
        var crossCount = 0;
        for (int i = 0; i < Input.Length; i++)
        {
            var currLine = Input[i];
            for (int j = 0; j < Input[i].Length; j++)
            {
                var currChar = currLine[j];
                if (currChar == 'A')
                {
                    var upperLeft = SearchWord(i - 1, j - 1, words[0], Directions.DOWNRIGHT)
                                 || SearchWord(i - 1, j - 1, words[1], Directions.DOWNRIGHT);
                    var upperRight = SearchWord(i - 1, j + 1, words[0], Directions.DOWNLEFT)
                                  || SearchWord(i - 1, j + 1, words[1], Directions.DOWNLEFT);
                    if (upperLeft && upperRight)
                    {
                        crossCount++;
                    }
                }
            }
        }

        return crossCount;
    }
}