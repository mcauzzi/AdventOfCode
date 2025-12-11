using Implementations.Helpers;
using Implementations.Helpers.MatrixDirections;

namespace Implementations._2025._04;

public class Aoc202504(char[][] input) :BaseAoc<long,long>(input)
{
    public override long SolvePart1()
    {
        var rowResults=new int[Input.Length];
        Parallel.For(0,Input.Length, (row) => { rowResults[row] = GetAccessiblePapers(row, Input);});
        return rowResults.Sum();
    }

    private int GetAccessiblePapers(int rowIndex, char[][] row)
    {
        var result = 0;
        for (int col = 0; col < row[rowIndex].Length; col++)
        {
            if (row[rowIndex][col] == '.')
            {
                continue;
            }
            var adjacentItems = row.GetAdjacentItemsInMatrix(rowIndex, col);
            if (adjacentItems.Count(x => x.Item2 == '@') < 4)
            {
                result++;
            }
        }
        return result;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}