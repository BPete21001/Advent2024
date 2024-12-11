using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day10Part1
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
                List<Tuple<int, int>> trailheadFinishes = EvaluateSpace(i, j, map);
                HashSet<string> uniqueTrailheadFinishes = new HashSet<string>();
                
                foreach(Tuple<int, int> finish in trailheadFinishes)
                {
                    uniqueTrailheadFinishes.Add($"{finish.Item1}-{finish.Item2}");
                }

                trailHeadCounter += uniqueTrailheadFinishes.Count;

            }
        }

        return trailHeadCounter;
    }

    private static List<Tuple<int, int>> EvaluateSpace(int yPos, int xPos, int[][] map, int previousValue = -1)
    {
        if(!IsOnMap(yPos, xPos, map))
        {
            return new List<Tuple<int, int>>();
        }

        if (map[yPos][xPos] != previousValue + 1)
        {
            return new List<Tuple<int, int>>();
        }

        if (map[yPos][xPos] == 9)
        {
            return new List<Tuple<int, int>>() { new Tuple<int, int>(yPos, xPos) };
        }

        List<Tuple<int, int>> trailheadFinishes = [.. EvaluateSpace(yPos + 1, xPos, map, map[yPos][xPos]),
            .. EvaluateSpace(yPos - 1, xPos, map, map[yPos][xPos]),
            .. EvaluateSpace(yPos, xPos + 1, map, map[yPos][xPos]),
            .. EvaluateSpace(yPos, xPos - 1, map, map[yPos][xPos])];


        return trailheadFinishes;
            
    }

    private static bool IsOnMap(int yPos, int xPos, int[][] map)
    {
        return yPos >= 0 && xPos >= 0 && yPos < map.Length && xPos < map[1].Length;
    }

}
