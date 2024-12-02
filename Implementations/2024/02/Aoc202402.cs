using Implementations.Helpers;

namespace Implementations._2024._02;

public class Aoc202402 : IAoc<long, long>
{
    public Aoc202402()
    {
        Reports = File.ReadAllLines("2024/02/Input.txt")
                      .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                      .Select(x=>x.Select(int.Parse).ToList())
                      .ToList();
    }

    public List<List<int>> Reports { get; set; }

    public long SolvePart1()
    {
        var safeReports = 0;
        foreach (var report in Reports)
        {
            if (IsReportSafe(report))
            {
                safeReports++;
            }
        }

        return safeReports;
    }
    public long SolvePart2()
    {
        var safeReports = 0;
        foreach (var report in Reports)
        {
            if (IsReportSafe(report))
            {
                safeReports++;
            }
            else
            {
                if (IsReportSafeWithOneLess(report))
                {
                    safeReports++;
                }
            }
        }

        return safeReports;
    }

    private bool IsReportSafeWithOneLess(List<int> report)
    {
        for (int i = 0; i < report.Count; i++)
        {
            var temp = new List<int>(report);
            temp.RemoveAt(i);
            if (IsReportSafe(temp))
            {
                return true;
            }
        }

        return false;
    }
    
    private bool IsReportSafe(List<int> report)
    {
        bool? isAsc = null;
        for (int i = 0; i < report.Count; i++)
        {
            if (i == 0)
            {
                continue;
            }

            var curr = report[i];
            var prev = report[i-1];
            var diff =Math.Abs(curr-prev);
            if (diff < 1 || diff > 3)
            {
                return false;
            }

            switch (isAsc)
            {
                case null when curr > prev:
                    isAsc=true;
                    continue;
                case null when curr<prev:
                    isAsc=false;
                    continue;
            }

            if(curr>prev && isAsc==false)
            {
                return false;
            }
            if(curr<prev && isAsc==true)
            {
                return false;
            }
        }
        return true;
    }

}