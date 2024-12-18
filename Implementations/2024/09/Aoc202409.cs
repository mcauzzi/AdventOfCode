using Implementations.Helpers;

namespace Implementations._2024._09;

public class Aoc202409 : IAoc<long, long>
{
    public Aoc202409(char[][] input):base(input)
    {
        Line = new string(input[0]);
    }

    public string Line { get; set; }

    public override long SolvePart1()
    {
        var currentFileId = 0;
        var files         = new HashSet<AocFile>();
        var freeSpaceMap  = new List<AocFreeSpace>();
        for (int i = 0, currDiskIndex = 0; i < Line.Length; i++)
        {
            var currNumber = int.Parse(Line[i].ToString());
            if (i % 2 == 0)
            {
                files.Add(new(currentFileId++, currDiskIndex, currNumber));
            }
            else
            {
                freeSpaceMap.Add(new(currDiskIndex, currNumber));
            }

            currDiskIndex += currNumber;
        }

        var freeBlocks = new List<int>(freeSpaceMap.SelectMany(x => x.BlocksIndexes));
        foreach (var file in files.OrderByDescending(x => x.Id))
        {
            file.MoveToEarliestFreeSpace(freeBlocks);
        }

        return files.Sum(file => file.BlocksIndexes.Sum(x => (long)x * file.Id));
    }

    public override long SolvePart2()
    {
        var currentFileId      = 0;
        var currentFreeSpaceId = 0;
        var fileMap            = new HashSet<AocFile>();
        var freeSpaceMap       = new List<AocFreeSpace>();
        for (int i = 0, currDiskIndex = 0; i < Line.Length; i++)
        {
            var currNumber = int.Parse(Line[i].ToString());
            if (i % 2 == 0)
            {
                fileMap.Add(new(currentFileId++, currDiskIndex, currNumber));
            }
            else
            {
                freeSpaceMap.Add(new(currDiskIndex, currNumber));
            }

            currDiskIndex += currNumber;
        }

        foreach (var aocFile in fileMap.OrderByDescending(x => x.Id))
        {
            aocFile.Defragment(freeSpaceMap);
        }

        return fileMap.Sum(file => file.BlocksIndexes.Sum(x => (long)x * file.Id));
    }
}