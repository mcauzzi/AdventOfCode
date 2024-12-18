namespace Implementations.Helpers;

public abstract class IAoc<TRes1, TRes2>(char[][] input)
{
    public char[][] Input { get; init; } = input;
    public abstract TRes1 SolvePart1();
    public abstract TRes2 SolvePart2();
}