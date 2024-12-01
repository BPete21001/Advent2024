using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

internal class Day1Part2
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

        int similarity = 0;

        foreach (int number in list1)
        {
            int numMatches = list2.Where(x => x == number).Count();

            similarity += numMatches * number;

        }

        return similarity;

    }

}
