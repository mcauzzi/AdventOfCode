using System.Text.RegularExpressions;

namespace Implementations._2023._02;

public partial class CubeSet
{
    public int Red { get; private init; }
    public int Green { get; private init; }
    public int Blue { get; private init; }

    public CubeSet(string str)
    {
        str = str.ToLower();
        Red = int.TryParse(RedRegex().Match(str).Groups[1].Value, out var red) ? red : 0;
        Green = int.TryParse(GreenRegex().Match(str).Groups[1].Value, out var green) ? green : 0;
        Blue = int.TryParse(BlueRegex().Match(str).Groups[1].Value, out var blue) ? blue : 0;
    }

    public CubeSet(int blue, int green, int red)
    {
        Blue = blue;
        Green = green;
        Red = red;
    }

    public bool IsValid => Blue >= 0 && Green >= 0 && Red >= 0;

    public static CubeSet operator -(CubeSet left, CubeSet right)
    {
        return new CubeSet(left.Blue - right.Blue, left.Green - right.Green, left.Red - right.Red);
    }

    [GeneratedRegex("([0-9]{1,2}) red")]
    private static partial Regex RedRegex();

    [GeneratedRegex("([0-9]{1,2}) green")]
    private static partial Regex GreenRegex();

    [GeneratedRegex("([0-9]{1,2}) blue")]
    private static partial Regex BlueRegex();
}