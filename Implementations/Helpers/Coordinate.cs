using Implementations.Helpers.Enums;

namespace Implementations.Helpers;

public record Coordinate(int X, int Y)
{
    public static Coordinate operator +(Coordinate left, Coordinate right) => new(left.X + right.X, left.Y + right.Y);
    public static Coordinate operator -(Coordinate left, Coordinate right) => new(left.X - right.X, left.Y - right.Y);
    public        bool       OutOfBounds(int       maxX, int        maxY)  => X < 0 || Y < 0 || X >= maxX || Y >= maxY;
    public        Coordinate Abs()                              => new Coordinate(Math.Abs(X), Math.Abs(Y));
    public static Coordinate GetDirectionVector(Directions dir) => DirectionsVectors[dir];

    private static Dictionary<Directions, Coordinate> DirectionsVectors = new()
                                                                          {
                                                                              { Directions.UP, new(0, -1) },
                                                                              { Directions.DOWN, new(0, 1) },
                                                                              { Directions.LEFT, new(-1, 0) },
                                                                              { Directions.RIGHT, new(1, 0) }
                                                                          };
}