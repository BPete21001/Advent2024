using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day1Part1
{
    public static int Solve(string input)
    {
        List<string> lines = input.Split(Environment.NewLine).ToList();

        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        foreach (string line in lines)
        {
            List<string> splitLine = line.Split("   ").ToList();

            list1.Add(int.Parse(splitLine[0]));
            list2.Add(int.Parse(splitLine[1]));
        }

        list1.Sort();
        list2.Sort();

        int distance = 0;

        for (int i = 0; i < list1.Count; i++)
        {
            distance += Math.Abs(list1[i] - list2[i]);
        }

        return distance;
    }

}
