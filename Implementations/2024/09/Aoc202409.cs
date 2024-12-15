using Implementations.Helpers;

namespace Implementations._2024._09;

public class Aoc202409:IAoc<long,long>
{
    public Aoc202409()
    {
        Input=File.ReadAllLines("2024/09/Input.txt").First();
    }

    public string Input { get; set; }

    public long SolvePart1()
    {
        var currentFileId = 0;
        var files         = new HashSet<AocFile>();
        var freeSpaceMap  =new List<AocFreeSpace>();
        for(int i=0, currDiskIndex=0;i<Input.Length;i++)
        {
            var currNumber = int.Parse(Input[i].ToString());
            if (i % 2 == 0)
            {
                files.Add(new(currentFileId++, currDiskIndex, currNumber));
            }
            else
            {
                for (int j = 0; j < currNumber; j++)
                {
                    freeSpaceMap.Add(new( currDiskIndex, currNumber));
                }
            }
            currDiskIndex += currNumber;
        }
        var freeSpaceHashSet = new HashSet<int>(freeSpaceMap.SelectMany(x => x.BlocksIndexes));
        foreach (var file in files.OrderByDescending(x=>x.Id))
        {
            file.MoveToEarliestFreeSpace(freeSpaceHashSet);
        }

        return files.Sum(file=>file.BlocksIndexes.Sum(x=>(long)x*file.Id));
    }

    public long SolvePart2()
    {
        var currentFileId = 0;
        var currentFreeSpaceId = 0;
        var fileMap     = new HashSet<AocFile>();
        var freeSpaceMap=new List<AocFreeSpace>();
        for(int i=0, currDiskIndex=0;i<Input.Length;i++)
        {
            var currNumber = int.Parse(Input[i].ToString());
            if (i % 2 == 0)
            {
                fileMap.Add(new(currentFileId++, currDiskIndex, currNumber));
            }
            else
            {
                freeSpaceMap.Add(new( currDiskIndex, currNumber));
            }
            currDiskIndex += currNumber;
        }

        foreach (var aocFile in fileMap.OrderByDescending(x=>x.Id))
        {
            aocFile.Defragment(freeSpaceMap);
        }
        return fileMap.Sum(file=>file.BlocksIndexes.Sum(x=>(long)x*file.Id));
    }
}