﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Implementations._2024._03;
using Implementations._2024._04;
using Implementations._2024._05;

var aoc =new Aoc202405();
var st  = new Stopwatch();
st.Start();
Console.WriteLine($"Part 1 Solution:{aoc.SolvePart1()}");
st.Stop();
Console.WriteLine($"Time for part 1:{st.ElapsedMilliseconds}ms");
st.Restart();
Console.WriteLine($"Part 2 Solution:{aoc.SolvePart2()}");
st.Stop();
Console.WriteLine($"Time for part 2:{st.ElapsedMilliseconds}ms");