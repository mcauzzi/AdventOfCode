namespace Implementations.Helpers;

public interface IAoc<TRes1, TRes2>
{
    public TRes1 SolvePart1();
    public TRes2 SolvePart2();
}