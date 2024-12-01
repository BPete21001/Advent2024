using Advent2024.Solutions;
using System.Runtime.CompilerServices;

string day1Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day1Input.txt");

Console.WriteLine("Day 1 part 1 solution: " + Day1Part1.Solve(day1Input));




static string GetThisFilePath([CallerFilePath] string path = null)
{
    return path;
}