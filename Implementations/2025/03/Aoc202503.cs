using Implementations.Helpers;

namespace Implementations._2025._03;

public class Aoc202503(char[][] input) : BaseAoc<long, long>(input)
{
    public override long SolvePart1()
    {
        var digitMatrix = Input.Select(x => x.Select(ch => ch - '0').ToArray()).ToArray();
        var sums = new long[digitMatrix.Length];
        Parallel.For(0, digitMatrix.Length, i => sums[i] = SearchHighestJoltage(digitMatrix[i],  2));

        return sums.Sum();
    }

    private long SearchHighestJoltage(int[] bank, int start, int requiredDigits, Dictionary<(int idx, int left), long> memo)
    {
        if (requiredDigits == 0) return 0;
        if (start >= bank.Length) return 0;
        if (bank.Length - start < requiredDigits) return 0;

        var key = (start, requiredDigits);
        if (memo.TryGetValue(key, out var cached)) return cached;

        var pow = Pow10(requiredDigits - 1);
        long best = 0;

        for (int i = start; i <= bank.Length - requiredDigits; i++)
        {
            var rest = SearchHighestJoltage(bank, i + 1, requiredDigits - 1, memo);
            var candidate = bank[i] * pow + rest;
            if (candidate > best)
            {
                best = candidate;
            }
        }

        memo[key] = best;
        return best;
    }

    private static long Pow10(int exp)
    {
        long res = 1;
        for (int i = 0; i < exp; i++) res *= 10;
        return res;
    }

    private long SearchHighestJoltage(int[] bank, int requiredBatteries)
    {
        return SearchHighestJoltage(bank, 0, requiredBatteries, new());
    }

    public override long SolvePart2()
    {
        var digitMatrix = Input.Select(x => x.Select(ch => ch - '0').ToArray()).ToArray();
        var sums        = new long[digitMatrix.Length];
        Parallel.For(0, digitMatrix.Length, i => sums[i] = SearchHighestJoltage(digitMatrix[i],  12));

        return sums.Sum();
    }
}