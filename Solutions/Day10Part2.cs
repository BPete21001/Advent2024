using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day10Part2
{
    public static int Solve(string input)
    {
        string[] lines = input.Split(Environment.NewLine).ToArray();
        int[][] map = new int[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            map[i] = lines[i].ToCharArray().Select(i => i - '0').ToArray();
        }

        int trailHeadCounter = 0;

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                trailHeadCounter += EvaluateSpace(i, j, map);
            }
        }

        return trailHeadCounter;
    }

    private static int EvaluateSpace(int yPos, int xPos, int[][] map, int previousValue = -1)
    {
        if (!IsOnMap(yPos, xPos, map))
        {
            return 0;
        }

        if (map[yPos][xPos] != previousValue + 1)
        {
            return 0;
        }

        if (map[yPos][xPos] == 9)
        {
            return 1;
        }

        return EvaluateSpace(yPos + 1, xPos, map, map[yPos][xPos])
            + EvaluateSpace(yPos - 1, xPos, map, map[yPos][xPos])
            + EvaluateSpace(yPos, xPos + 1, map, map[yPos][xPos])
            + EvaluateSpace(yPos, xPos - 1, map, map[yPos][xPos]);
    }

    private static bool IsOnMap(int yPos, int xPos, int[][] map)
    {
        return yPos >= 0 && xPos >= 0 && yPos < map.Length && xPos < map[1].Length;
    }
}
