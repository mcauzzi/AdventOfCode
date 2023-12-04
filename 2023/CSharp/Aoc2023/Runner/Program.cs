// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Implementations.Aoc3;
using Implementations.Aoc4;

var aoc =new Aoc4();
var st  = new Stopwatch();
st.Start();
Console.WriteLine(aoc.SolvePart1());
st.Stop();
Console.WriteLine($"Time for part 1:{st.ElapsedMilliseconds}ms");
st.Restart();
Console.WriteLine(aoc.SolvePart2());
st.Stop();
Console.WriteLine($"Time for part 2:{st.ElapsedMilliseconds}ms");