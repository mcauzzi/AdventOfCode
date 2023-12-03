using Implementations.Helpers;

namespace Implementations.Aoc3;

public class Aoc3 : IAoc<int, int>
{
    private string[] Input { get; } = File.ReadAllLines("./Aoc3/Input.txt");

    public int SolvePart1()
    {
        var sum = 0;
        for (var i = 0; i < Input.Length; i++)
        {
            var line          = Input[i];
            var currentNumber = "";
            var shouldSum     = false;
            for (var j = 0; j < line.Length; j++)
            {
                var ch = line[j];
                if (ch.IsNumber())
                {
                    currentNumber += ch;
                    if (IsAdjacentToSymbol(i, j))
                    {
                        shouldSum = true;
                    }
                }
                else if (ch.IsSymbol())
                {
                    if (shouldSum)
                    {
                        sum += int.Parse(currentNumber);
                    }

                    shouldSum     = false;
                    currentNumber = "";
                }
            }

            if (shouldSum)
            {
                sum += int.Parse(currentNumber);
            }
        }

        return sum;
    }

    public int SolvePart2()
    {
        var gearDict = new Dictionary<Position, List<int>>();
        for (var i = 0; i < Input.Length; i++)
        {
            var       line          = Input[i];
            var       currentNumber = "";
            Position? adjacentGear  = null;
            for (var j = 0; j < line.Length; j++)
            {
                var ch = line[j];
                if (ch.IsNumber())
                {
                    currentNumber += ch;
                    adjacentGear  =  FindAdjacentGear(i, j)??adjacentGear;
                }
                else if (ch.IsSymbol())
                {
                    if (adjacentGear != null)
                    {
                        if (gearDict.TryGetValue(adjacentGear, out var list))
                        {
                            list.Add(int.Parse(currentNumber));
                        }
                        else
                        {
                            gearDict.Add(adjacentGear, new List<int>() { int.Parse(currentNumber) });
                        }
                    }

                    adjacentGear  = null;
                    currentNumber = "";
                }
            }

            if (adjacentGear != null)
            {
                if (gearDict.TryGetValue(adjacentGear, out var list))
                {
                    list.Add(int.Parse(currentNumber));
                }
                else
                {
                    gearDict.Add(adjacentGear, new List<int>() { int.Parse(currentNumber) });
                }
            }
        }

        return gearDict.Where(x => x.Value.Count == 2).Sum(x => x.Value.Aggregate( (x, y) => x * y));
    }

    private Position? FindAdjacentGear(int i, int j)
    {
        var notLowerEdge = i + 1 < Input.Length;
        var notUpperEdge = i - 1 > 0;
        var notleftEdge  = j - 1 > 0;
        var notRightEdge = j + 1 < Input[i].Length;
        if (notleftEdge)
        {
            if (Input[i][j - 1] == '*')
            {
                return new Position() { X = j - 1, Y = i };
            }
        }

        if (notRightEdge)
        {
            if (Input[i][j + 1] == '*')
            {
                return new Position() { X = j + 1, Y = i };
            }
        }

        if (notLowerEdge)
        {
            if (Input[i + 1][j] == '*')
            {
                return new Position() { X = j, Y = i + 1 };
            }

            if (notleftEdge)
            {
                if (Input[i + 1][j - 1] == '*')
                {
                    return new Position() { X = j - 1, Y = i + 1 };
                }
            }

            if (notRightEdge)
            {
                if (Input[i + 1][j + 1] == '*')
                {
                    return new Position() { X = j + 1, Y = i + 1 };
                }
            }
        }

        if (notUpperEdge)
        {
            if (Input[i - 1][j] == '*')
            {
                return new Position() { X = j, Y = i - 1 };
            }

            if (notleftEdge)
            {
                if (Input[i - 1][j - 1] == '*')
                {
                    return new Position() { X = j - 1, Y = i - 1 };
                }
            }

            if (notRightEdge)
            {
                if (Input[i - 1][j + 1] == '*')
                {
                    return new Position() { X = j + 1, Y = i - 1 };
                }
            }
        }

        return null;
    }

    private bool IsAdjacentToSymbol(int i, int j)
    {
        var notLowerEdge = i + 1 < Input.Length;
        var notUpperEdge = i - 1 > 0;
        var notleftEdge  = j - 1 > 0;
        var notRightEdge = j + 1 < Input[i].Length;
        if (notleftEdge)
        {
            if (Input[i][j - 1].IsSymbol() && Input[i][j - 1] != '.')
            {
                return true;
            }
        }

        if (notRightEdge)
        {
            if (Input[i][j + 1].IsSymbol() && Input[i][j + 1] != '.')
            {
                return true;
            }
        }

        if (notLowerEdge)
        {
            if (Input[i + 1][j].IsSymbol() && Input[i + 1][j] != '.')
            {
                return true;
            }

            if (notleftEdge)
            {
                if (Input[i + 1][j - 1].IsSymbol() && Input[i + 1][j - 1] != '.')
                {
                    return true;
                }
            }

            if (notRightEdge)
            {
                if (Input[i + 1][j + 1].IsSymbol() && Input[i + 1][j + 1] != '.')
                {
                    return true;
                }
            }
        }

        if (notUpperEdge)
        {
            if (Input[i - 1][j].IsSymbol() && Input[i - 1][j] != '.')
            {
                return true;
            }

            if (notleftEdge)
            {
                if (Input[i - 1][j - 1].IsSymbol() && Input[i - 1][j - 1] != '.')
                {
                    return true;
                }
            }

            if (notRightEdge)
            {
                if (Input[i - 1][j + 1].IsSymbol() && Input[i - 1][j + 1] != '.')
                {
                    return true;
                }
            }
        }

        return false;
    }

    private class Position : IEquatable<Position>
    {
        public bool Equals(Position? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Position? left, Position? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position? left, Position? right)
        {
            return !Equals(left, right);
        }

        public int X { get; init; }
        public int Y { get; init; }
    }
}