using Implementations.Helpers;

namespace Implementations._2023._12;

public class Aoc12 : BaseAoc<long, long>
{
    public Aoc12(char[][] input) : base(input)
    {
        InputAsStrings = input.Select(x => new string(x)).ToArray();
    }

    private string[] InputAsStrings { get; }

    public override long SolvePart1()
    {
        var conditions = InputAsStrings.Select(x => x.Split(' ', StringSplitOptions.TrimEntries))
                              .Select(x => new ConditionRecord(x[0], x[1]));
        return conditions.Select(x => x.CalculatePossibilities()).Sum();
    }

    public override long SolvePart2()
    {
        return 0;
    }
}

public class ConditionRecord
{
    public List<Spring> Record        { get; set; }
    public List<int>    GroupsLengths { get; set; }

    public ConditionRecord(string record, string groupsLengths)
    {
        Record        = record.Select(x => new Spring(x)).ToList();
        GroupsLengths = groupsLengths.Split(',', StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
    }

    public long CalculatePossibilities()
    {
        return CalculatePossibilities(Record,0);
    }

    private long CalculatePossibilities(List<Spring> record,int currentIndex)
    {
        
        if (record.All(x => x.Status != SpringStatus.Unkwnown) )
        {
            if (IsValidRecord(record))
            {
                return 1;
            }
            return 0;
        }

        for (int i = currentIndex; i < record.Count; i++)
        {
            if (record[i].Status == SpringStatus.Unkwnown)
            {
                var newRecord = record.ToList();
                currentIndex =  i;
                var partSum = 0L;
                newRecord[i] =  new Spring(SpringStatus.Broken);
                partSum      += CalculatePossibilities(newRecord, currentIndex);
                newRecord[i] =  new Spring(SpringStatus.Operational);
                partSum      += CalculatePossibilities(newRecord, currentIndex);
                return partSum;
            }
        }

        return 1;
    }

    private bool IsValidRecord(List<Spring> record)
    {
        var currentGroup = 0;
        
        for (var index = 0; index < record.Count; index++)
        {
            var spring = record[index];
            if (currentGroup >= GroupsLengths.Count && record[index..].Any(x => x.Status == SpringStatus.Broken))
            {
                return false;
            }

            if (spring.Status != SpringStatus.Broken) continue;
            var cntBroken = 0;
            while (spring.Status == SpringStatus.Broken)
            {
                cntBroken++;
                index++;
                if (index >= record.Count )
                {
                    return currentGroup == GroupsLengths.Count - 1 && cntBroken == GroupsLengths[currentGroup];
                }
                spring = record[index];
            }

            if (cntBroken != GroupsLengths[currentGroup])
            {
                return false;
            }

            currentGroup++;
        }

        return currentGroup >= GroupsLengths.Count;
    }
}

public class Spring
{
    public SpringStatus Status { get; set; }

    public Spring(char c)
    {
        Status = c switch
                 {
                     '#' => SpringStatus.Broken,
                     '.' => SpringStatus.Operational,
                     '?' => SpringStatus.Unkwnown,
                     _   => Status
                 };
    }

    public Spring(SpringStatus st)
    {
        Status = st;
    }
}

public enum SpringStatus
{
    Unkwnown,
    Operational,
    Broken
}