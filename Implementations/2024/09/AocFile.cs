namespace Implementations._2024._09;

public class AocFile : IEquatable<AocFile>
{
    public int          Id            { get; init; }
    public HashSet<int> BlocksIndexes { get; private set; }

    public AocFile(int id, int fileStart, int fileSize)
    {
        Id            = id;
        BlocksIndexes = new HashSet<int>();
        for (var i = fileStart; i < fileStart + fileSize; i++)
        {
            BlocksIndexes.Add(i);
        }
    }

    public void MoveToEarliestFreeSpace(HashSet<int> freeSpaceIndexes)
    {
        var newBlocksIndexes = new HashSet<int>();
        foreach (var blockIndex in BlocksIndexes.Reverse())
        {
            var newFreeSpaceIndexEnum = freeSpaceIndexes.Where(x => blockIndex > x);
            if (newFreeSpaceIndexEnum.Any())
            {
                newBlocksIndexes.Add(newFreeSpaceIndexEnum.First());
                freeSpaceIndexes.Remove(newFreeSpaceIndexEnum.First());
                freeSpaceIndexes.Add(blockIndex);
            }
            else
            {
                newBlocksIndexes.Add(blockIndex);
            }
        }

        BlocksIndexes = newBlocksIndexes.OrderBy(x => x).ToHashSet();
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
            BlocksIndexes = fileDest.BlocksIndexes.Take(BlocksIndexes.Count).ToHashSet();
            fileDest.RemoveFreeSpace(BlocksIndexes.Count);
        }
    }
}