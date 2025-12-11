namespace Implementations.Helpers.MatrixDirections;

public static class DirectionsMatrix
{
    public static (Direction, T)[] GetAdjacentItemsInMatrix<T>(this T[][] matrix, int rowIndex, int colIndex)
    {
        return Enum.GetValues<Direction>()
            .Select(x => GetAdjacentElement(x, matrix, rowIndex, colIndex))
            .Where(x => x.HasValue)
            .Select(x => x!.Value).ToArray();
    }

    private static (Direction, T)? GetAdjacentElement<T>(Direction direction, T[][] matrix, int rowIndex, int colIndex)
    {
        switch (direction)
        {
            case Direction.Up:
                if (rowIndex == 0)
                {
                    return null;
                }

                return (Direction.Up, matrix[rowIndex - 1][colIndex]);
            case Direction.Down:
                if (rowIndex == matrix.Length - 1)
                {
                    return null;
                }

                return (Direction.Down, matrix[rowIndex + 1][colIndex]);
            case Direction.Left:
                if (colIndex == 0)
                {
                    return null;
                }

                return (Direction.Left, matrix[rowIndex][colIndex - 1]);
            case Direction.Right:
                if (colIndex == matrix[rowIndex].Length - 1)
                {
                    return null;
                }

                return (Direction.Right, matrix[rowIndex][colIndex + 1]);
            case Direction.UpLeft:
                if (colIndex == 0 || rowIndex == 0)
                {
                    return null;
                }

                return (Direction.UpLeft, matrix[rowIndex - 1][colIndex - 1]);
            case Direction.UpRight:
                if (colIndex == matrix[rowIndex].Length - 1 || rowIndex == 0)
                {
                    return null;
                }

                return (Direction.UpRight, matrix[rowIndex - 1][colIndex + 1]);
            case Direction.DownLeft:
                if (colIndex == 0 || rowIndex == matrix.Length - 1)
                {
                    return null;
                }

                return (Direction.DownLeft, matrix[rowIndex + 1][colIndex - 1]);
            case Direction.DownRight:
                if (colIndex == matrix[rowIndex].Length - 1 || rowIndex == matrix.Length - 1)
                {
                    return null;
                }

                return (Direction.DownRight, matrix[rowIndex + 1][colIndex + 1]);
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}