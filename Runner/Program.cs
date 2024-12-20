using System.Reflection;
using System.Diagnostics;
using Implementations;
using Implementations.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        var solutions = LoadSolutions();
        while (true)
        {
            Console.WriteLine("Select a year:");
            var years = solutions.Keys.OrderBy(y => y).ToList();
            for (int i = 0; i < years.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {years[i]}");
            }
            Console.WriteLine($"{years.Count + 1}. Run latest solution");

            if (!int.TryParse(Console.ReadLine(), out var yearIndex) || yearIndex < 1 || yearIndex > years.Count + 1)
            {
                Console.WriteLine("Invalid selection. Please try again.");
                continue;
            }

            if (yearIndex == years.Count + 1)
            {
                var latestSolution = GetLatestSolution(solutions);
                if (latestSolution != null)
                {
                    ExecuteSolution(latestSolution, years.Last(), solutions[years.Last()].Keys.Max());
                }
                else
                {
                    Console.WriteLine("No solutions found.");
                }
                continue;
            }

            var selectedYear = years[yearIndex - 1];
            var days = solutions[selectedYear].Keys.OrderBy(d => d).ToList();
            Console.WriteLine("Select a day:");
            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Day {days[i]}");
            }

            if (!int.TryParse(Console.ReadLine(), out var dayIndex) || dayIndex < 1 || dayIndex > days.Count)
            {
                Console.WriteLine("Invalid selection. Please try again.");
                continue;
            }

            var selectedDay = days[dayIndex - 1];
            var solutionType = solutions[selectedYear][selectedDay];
            ExecuteSolution(solutionType, selectedYear, selectedDay);
        }
    }

    private static Dictionary<int, Dictionary<int, Type>> LoadSolutions()
    {
        var solutions = new Dictionary<int, Dictionary<int, Type>>();
        var assemblies = new[] { Assembly.GetExecutingAssembly(), Assembly.Load("Implementations") };

        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes().Where(t => t.BaseType?.IsGenericType==true && t.BaseType?.GetGenericTypeDefinition()==typeof(BaseAoc<,>));
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                var splitNamespaceName = type.Namespace?.Replace("_","").Split('.', StringSplitOptions.RemoveEmptyEntries);
                var year               = int.Parse(splitNamespaceName?[1][..4] ?? "0");
                var day                = int.Parse(splitNamespaceName?[2][..2] ?? "0");

                if (!solutions.ContainsKey(year))
                {
                    solutions[year] = new Dictionary<int, Type>();
                }

                solutions[year][day] = type;
            }
        }

        return solutions;
    }

    private static Type GetLatestSolution(Dictionary<int, Dictionary<int, Type>> solutions)
    {
        var latestYear = solutions.Keys.Max();
        var latestDay = solutions[latestYear].Keys.Max();
        return solutions[latestYear][latestDay];
    }

    private static void ExecuteSolution(Type solutionType, int year = 0, int day = 0)
    {
        try
        {
            var inputFilePath = $"Implementations/{year}/Inputs/Aoc{day}.txt";
            var inputUrl = $"https://adventofcode.com/{year}/day/{day}/input";
            var input = FileLoader.GetInput(inputFilePath, inputUrl).Select(x=>x.ToCharArray()).ToArray();

            var solutionInstance = Activator.CreateInstance(solutionType, new object[] { input });
            var runFirstPartMethod = solutionType.GetMethod("SolvePart1");
            var runSecondPartMethod = solutionType.GetMethod("SolvePart2");

            if (runFirstPartMethod != null && runSecondPartMethod != null)
            {
                var stopwatch = Stopwatch.StartNew();
                var firstPartResult = runFirstPartMethod.Invoke(solutionInstance, null);
                stopwatch.Stop();
                Console.WriteLine($"Part 1: {firstPartResult} (Execution Time: {stopwatch.ElapsedMilliseconds} ms)");

                stopwatch.Restart();
                var secondPartResult = runSecondPartMethod.Invoke(solutionInstance, null);
                stopwatch.Stop();
                Console.WriteLine($"Part 2: {secondPartResult} (Execution Time: {stopwatch.ElapsedMilliseconds} ms)");
            }
            else
            {
                Console.WriteLine("The selected solution does not have the required methods.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while executing the solution: {ex.Message}, {ex.InnerException?.Message}");
        }
    }
}
