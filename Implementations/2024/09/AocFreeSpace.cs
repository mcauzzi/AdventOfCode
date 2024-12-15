namespace Implementations._2024._09;

public class AocFreeSpace
{
    public AocFreeSpace( int start, int size)
    {
        BlocksIndexes = new HashSet<int>();
        for (var i = start; i < start + size; i++)
        {
            BlocksIndexes.Add(i);
        }
    }
    public HashSet<int> BlocksIndexes { get; private set; }

    public void RemoveFreeSpace(int blocksToSkip)
    {
        BlocksIndexes=new(BlocksIndexes.Skip(blocksToSkip));
    }
}