namespace AdventOfCode;

public interface IAoc<out T1, out T2>
{
    T1 RunFirstPart();
    T2 RunSecondPart();
}