using System.Text.RegularExpressions;
using Implementations.Helpers;

namespace Implementations._2025._01;

public partial class Aoc202501(char[][] input) : BaseAoc<long, long>(input)
{
    public override long SolvePart1()
    {
        var ops = Input.Select(x => StepRegex().Match(new string(x)))
                       .Select(x => new
                                    {
                                        Direction = x.Groups[1].Value,
                                        Steps     = int.Parse(x.Groups[2].Value)
                                    });
        var dial = new Dial();
        foreach (var op in ops)
        {
            if (op.Direction == "L")
            {
                dial.TurnLeft(op.Steps);
            }
            else
            {
                dial.TurnRight(op.Steps);
            }
        }

        return dial.TimesStoppedAtZero;
    }

    public override long SolvePart2()
    {
        var testData = """
            L68
            L30
            R48
            L5
            R60
            L55
            L1
            L99
            R14
            L82
            """.Split('\n')
               .Select(x => x.ToCharArray());
        var ops = Input.Select(x => StepRegex().Match(new string(x)))
                       .Select(x => new
                                    {
                                        Direction = x.Groups[1].Value,
                                        Steps     = int.Parse(x.Groups[2].Value)
                                    });
        var dial = new Dial();
        foreach (var op in ops)
        {
            if (op.Direction == "L")
            {
                dial.TurnLeft(op.Steps);
            }
            else
            {
                dial.TurnRight(op.Steps);
            }
        }

        return dial.TimesOnZero;
    }

    [GeneratedRegex("([LR]{1})([0-9]{1,})")]
    private static partial Regex StepRegex();
}

public class Dial
{
    private int _currentPosition = 50;


    public int  CurrentPosition    => _currentPosition;
    public long TimesStoppedAtZero { get; private set; } = 0;
    public long TimesOnZero   { get; private set; } = 0;

    public void TurnLeft(int steps)
    {
        var p = _currentPosition;

        if (p == 0)
        {
            TimesOnZero += steps / 100;
        }
        else if (steps >= p)
        {
            TimesOnZero += 1 + (steps - p) / 100;
        }
        var sum = p - steps;
        _currentPosition = ((sum % 100)+100)%100;

        if (_currentPosition == 0)
        {
            TimesStoppedAtZero++;
        }
    }

    public void TurnRight(int steps)
    {
        var sum = _currentPosition + steps;
        TimesOnZero += sum / 100;
        _currentPosition = sum % 100;

        if (_currentPosition == 0)
        {
            TimesStoppedAtZero++;
        }
    }
}