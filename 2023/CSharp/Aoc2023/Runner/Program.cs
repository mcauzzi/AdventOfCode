// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Implementations.Aoc3;
using Implementations.Aoc4;
using Implementations.Aoc5;
using Implementations.Aoc6;
using Implementations.Aoc7;
using Implementations.Aoc8;
using Implementations.Aoc9;

var aoc =new Aoc9();
var st  = new Stopwatch();
st.Start();
Console.WriteLine(aoc.SolvePart1());
st.Stop();
Console.WriteLine($"Time for part 1:{st.ElapsedMilliseconds}ms");
st.Restart();
Console.WriteLine(aoc.SolvePart2());
st.Stop();
Console.WriteLine($"Time for part 2:{st.ElapsedMilliseconds}ms");