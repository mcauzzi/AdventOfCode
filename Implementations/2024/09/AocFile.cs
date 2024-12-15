namespace Implementations._2024._09;

public class AocFile : IEquatable<AocFile>
{
    public int          Id            { get; init; }
    public List<int> BlocksIndexes { get; private set; }

    public AocFile(int id, int fileStart, int fileSize)
    {
        Id            = id;
        BlocksIndexes = new List<int>();
        for (var i = fileStart; i < fileStart + fileSize; i++)
        {
            BlocksIndexes.Add(i);
        }
    }

    public void MoveToEarliestFreeSpace(List<int> freeSpaceIndexes)
    {
        var currBlockIndex        = BlocksIndexes.Count-1;
        for (int i = 0; i < freeSpaceIndexes.Count; i++)
        {
            var currFreeSpaceBlock=freeSpaceIndexes[i];
            if(currFreeSpaceBlock<BlocksIndexes[currBlockIndex])
            {
                freeSpaceIndexes[i]=BlocksIndexes[currBlockIndex];
                BlocksIndexes[currBlockIndex--]=currFreeSpaceBlock;
                if (currBlockIndex < 0)
                {
                    return;
                }
            }
        }
    }

    public bool Equals(AocFile? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((AocFile)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public static bool operator ==(AocFile? left, AocFile? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(AocFile? left, AocFile? right)
    {
        return !Equals(left, right);
    }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(BlocksIndexes)}: {string.Join(',', BlocksIndexes)}";
    }

    public void Defragment(List<AocFreeSpace> freeSpaceMap)
    {
        var fileDest = freeSpaceMap.FirstOrDefault(x => x.BlocksIndexes.Count >= BlocksIndexes.Count
                                                     && x.BlocksIndexes.First() < BlocksIndexes.First());
        if (fileDest != null)
        {
            BlocksIndexes = fileDest.BlocksIndexes.Take(BlocksIndexes.Count).ToList();
            fileDest.RemoveFreeSpace(BlocksIndexes.Count);
        }
    }
}