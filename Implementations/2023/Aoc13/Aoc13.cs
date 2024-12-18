using Implementations.Helpers;

namespace Implementations._2023.Aoc13;

public class Aoc13:IAoc<long,long>
{
    public Aoc13(char[][] input):base(input)
    {
        var inputStrings=input.Select(x=>new string(x)).ToArray();
        for (int i = 0; i < inputStrings.Length;)
        {
            var pattern = inputStrings.Skip(i).TakeWhile(x => x != "").Select(str=>str.Select(ch=>ch).ToArray()).ToArray();
            InputPattern.Add(pattern);
            i += pattern.Length+1;
        }
        
    }

    private List<char[][]> InputPattern { get; } = new();
    public override long SolvePart1()
    {
        var totalSum     = 0;
        foreach (var pattern in InputPattern)
        {
            for (int l = 0, r = 1; l < pattern[0].Length-1; l++, r++)
            {
                if (IsMirrorVerticalAxis(pattern, l, r))
                {
                    totalSum += l+1;
                }
            }
            for (int up = 0, down = 1; up < pattern.Length-1; up++, down++)
            {
                if (IsMirrorHorizontalAxis(pattern, up, down))
                {
                    totalSum += (up+1)*100;
                }
            }
        }
        return totalSum;
    }

    private bool IsMirrorHorizontalAxis(char[][] pattern, int aboveAxis, int belowAxis)
    {
        var found = false;
        for (var i = 0; i < pattern[0].Length; i++)
        {
            if (pattern[aboveAxis][i] != '#' || pattern[belowAxis][i] != '#') continue;
            found = true;
            break;
        }

        if (!found)
        {
            return false;
        }
        for (var i = 0; i < pattern[0].Length; i++)
        {
            var lineAboveAxis  = aboveAxis;
            var lineBelowAxis = belowAxis;
            while (lineAboveAxis>=0 && lineBelowAxis < pattern.Length)
            {
                if (pattern[lineAboveAxis--][i] != pattern[lineBelowAxis++][i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool IsMirrorVerticalAxis(char[][] pattern,int leftAxis, int rightAxis)
    {
        if (!pattern.Any(x => x[leftAxis] == '#' && x[rightAxis] == '#'))
        {
            return false;
        }
        foreach (var line in pattern)
        {
            var lineLeftAxis  = leftAxis;
            var lineRightAxis = rightAxis;
            while (lineLeftAxis >= 0 && lineRightAxis < line.Length)
            {
                if (line[lineLeftAxis] != line[lineRightAxis])
                {
                    return false;
                }
                lineLeftAxis--;
                lineRightAxis++;
            } 
        }

        return true;
    }

    public override long SolvePart2()
    {
        return 0;
    }
}