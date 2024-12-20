namespace Implementations._2023._10;

public class Coordinate : IEquatable<Coordinate>
{
    public                 int        Row    { get; init; }
    public                 int        Column { get; init; }
    public static readonly Coordinate North = new() { Column = 0, Row = -1 };
    public static readonly Coordinate South = new() { Column = 0, Row = +1 };
    public static readonly Coordinate East  = new() { Column = +1, Row = 0 };
    public static readonly Coordinate West  = new() { Column = -1, Row = 0 };
    public static Coordinate operator +(Coordinate left, Coordinate right)
    {
        return new Coordinate()
               {
                   Row    = left.Row + right.Row,
                   Column = left.Column + right.Column
               };
    }

    public bool Equals(Coordinate? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Coordinate)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public static bool operator ==(Coordinate? left, Coordinate? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Coordinate? left, Coordinate? right)
    {
        return !Equals(left, right);
    }
}