namespace Implementations.Aoc8;

public class Instructions
{
    private char[] Steps        { get; init; }
    public int    CurrentIndex { get; private set; }

    public char GetNextStep()
    {
        var res = Steps[CurrentIndex++];
        if (CurrentIndex >= Steps.Length)
        {
            CurrentIndex = 0;
        }

        return res;
    }

    public Instructions(string input)
    {
        Steps = input.ToArray();
    }
}