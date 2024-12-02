using Advent2024.Solutions;
using System.Runtime.CompilerServices;

string day1Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day1Input.txt");

Console.WriteLine("Day 1 part 1 solution: " + Day1Part1.Solve(day1Input));

Console.WriteLine("Day 1 part 2 solution: " + Day1Part2.Solve(day1Input));

string day2Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day2Input.txt");

Console.WriteLine("Day 2 part 1 solution: " + Day2Part1.Solve(day2Input));

Console.WriteLine("Day 2 part 2 solution: " + Day2Part2.Solve(day2Input));

static string GetThisFilePath([CallerFilePath] string path = null)
{
    return path;
}