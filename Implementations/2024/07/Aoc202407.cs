using Implementations.Helpers;

namespace Implementations._2024._07;

public class Aoc202407 : BaseAoc<long, long>
{
    public Aoc202407(char[][] input):base(input)
    {
        Equations = Input.Select(x=>new string(x))
                        .Select(x => x.Trim())
                        .Select(x => new Equation()
                                     {
                                         ExpectedResult = long.Parse(x.Split(':')[0]),
                                         Operators      = x.Split(':')[1].Trim().Split(' ').Select(long.Parse).ToArray()
                                     })
                        .ToList();
    }

    public List<Equation> Equations { get; set; }

    public override long SolvePart1()
    {
        var waitAllTask = Task.WhenAll(Equations.Select(x => x.HasSolution()));
        while (!waitAllTask.IsCompleted)
        {
            Thread.Sleep(10);
        }

        var completedEqs = Equations.Where(x => x.HasSolution().Result);
        return completedEqs.Sum(x => x.ExpectedResult);
    }

    public override long SolvePart2()
    {
        foreach (var eq in Equations)
        {
            eq.UseConcatenation = true;
        }

        var waitAllTask = Task.WhenAll(Equations.Select(x => x.HasSolution()));
        while (!waitAllTask.IsCompleted)
        {
            Thread.Sleep(10);
        }

        var completedEqs = Equations.Where(x => x.HasSolution().Result);
        return completedEqs.Sum(x => x.ExpectedResult);
    }

    public class Equation
    {
        public long   ExpectedResult   { get; init; }
        public long[] Operators        { get; init; }
        public bool   UseConcatenation { get; set; }

        public async Task<bool> HasSolution()
        {
            if (Operators.Length == 1)
            {
                return Operators[0] == ExpectedResult;
            }

            return await CheckOperators(0, 0);
        }

        private async Task<bool> CheckOperators(int index, long previousResult)
        {
            var nextIndex = index + 1;

            var sum = previousResult + Operators[index];
            if (previousResult == 0 && index == 0)
            {
                previousResult = 1;
            }

            var mul = previousResult * Operators[index];
            var concat = UseConcatenation
                             ? long.Parse(previousResult.ToString() + Operators[index])
                             : ExpectedResult + 1;
            var mulOver    = mul > ExpectedResult;
            var sumOver    = sum > ExpectedResult;
            var concatOver = concat > ExpectedResult;
            if (mulOver && sumOver && concatOver)
            {
                return false;
            }

            if (nextIndex <= Operators.Length - 1)
            {
                return (!mulOver && await CheckOperators(nextIndex,   mul))
                    || (!sumOver && await CheckOperators(nextIndex,    sum))
                    || (!concatOver && await CheckOperators(nextIndex, concat));
            }

            return mul == ExpectedResult || sum == ExpectedResult || concat == ExpectedResult;
        }
    }
}