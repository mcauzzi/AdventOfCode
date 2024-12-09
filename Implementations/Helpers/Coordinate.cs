namespace Implementations.Helpers;

public record Coordinate(int X, int Y)
{
    public static Coordinate operator +(Coordinate left, Coordinate right) => new(left.X + right.X, left.Y + right.Y);
    public        bool OutOfBounds(int             maxX, int        maxY)  => X < 0 || Y < 0 || X >= maxX || Y >= maxY;
}