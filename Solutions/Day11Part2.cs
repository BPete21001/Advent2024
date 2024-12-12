using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day11Part2
{
    public static long Solve(string input)
    {
        List<long> stonesList = input.Replace(Environment.NewLine, "").Split(" ").Select(long.Parse).ToList();

        Dictionary<long, long> stonesMap = new Dictionary<long, long>();

        foreach (long stone in stonesList)
        {
            stonesMap.Add(stone, 1);
        }

        for (int i = 0; i < 75; i++)
        {

            Console.WriteLine(i);

            Dictionary<long, long> newStonesMap = new Dictionary<long, long>();

            foreach (KeyValuePair<long, long> stone in stonesMap)
            {
                if (stone.Key == 0)
                {
                    AddOrIncrement(newStonesMap, 1, stone.Value);
                    continue;
                }

                string currStoneString = stone.Key.ToString();

                if (currStoneString.Length % 2 == 0)
                {
                    AddOrIncrement(newStonesMap, long.Parse(currStoneString.Substring(0, currStoneString.Length / 2)), stone.Value);
                    AddOrIncrement(newStonesMap, long.Parse(currStoneString.Substring(currStoneString.Length / 2)), stone.Value);
                    continue;
                }

                if (currStoneString.Length % 2 == 1)
                {
                    AddOrIncrement(newStonesMap, stone.Key * 2024, stone.Value);
                    continue;
                }
            }

            stonesMap = newStonesMap;
        }

        long stoneCount = 0;

        foreach(KeyValuePair<long, long> stone in stonesMap)
        {
            stoneCount += stone.Value;
        }

        return stoneCount;

    }

    public static void AddOrIncrement(Dictionary<long, long> stonesMap, long key, long value)
    {
        if (stonesMap.TryAdd(key, value))
        {
            return;
        }

        stonesMap[key] += value;
    }

}
