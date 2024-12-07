using Advent2024.Solutions;
using System.Runtime.CompilerServices;

string day1Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day1Input.txt");

Console.WriteLine("Day 1 part 1 solution: " + Day1Part1.Solve(day1Input));

Console.WriteLine("Day 1 part 2 solution: " + Day1Part2.Solve(day1Input));

string day2Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day2Input.txt");

Console.WriteLine("Day 2 part 1 solution: " + Day2Part1.Solve(day2Input));

Console.WriteLine("Day 2 part 2 solution: " + Day2Part2.Solve(day2Input));

string day3Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day3Input.txt");

Console.WriteLine("Day 3 part 1 solution: " + Day3Part1.Solve(day3Input));

Console.WriteLine("Day 3 part 2 solution: " + Day3Part2.Solve(day3Input));

string day4Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day4Input.txt");

Console.WriteLine("Day 4 part 1 solution: " + Day4Part1.Solve(day4Input));

Console.WriteLine("Day 4 part 2 solution: " + Day4Part2.Solve(day4Input));

string day5Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day5Input.txt");

Console.WriteLine("Day 5 part 1 solution: " + Day5Part1.Solve(day5Input));

Console.WriteLine("Day 5 part 2 solution: " + Day5Part2.Solve(day5Input));

string day6Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day6Input.txt");

Console.WriteLine("Day 6 part 1 solution: " + Day6Part1.Solve(day6Input));

Console.WriteLine("Day 6 part 2 solution: too slow uncomment to run");// + Day6Part2.Solve(day6Input));

string day7Input = File.ReadAllText($"{Path.GetDirectoryName(GetThisFilePath())}\\Inputs\\Day7Input.txt");

Console.WriteLine("Day 7 part 1 solution: " + Day7Part1.Solve(day7Input));

Console.WriteLine("Day 7 part 2 solution: " + Day7Part2.Solve(day7Input));

static string GetThisFilePath([CallerFilePath] string path = null)
{
    return path;
}