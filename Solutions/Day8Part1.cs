using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day8Part1
{
    public static int Solve(string input)
    {
        string[] inputLines = input.Split(Environment.NewLine).ToArray();
        char[][] map = inputLines.Select(s => s.ToCharArray()).ToArray();

        Dictionary<char, List<Position>> antennaLocations = new Dictionary<char, List<Position>>();

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '.')
                {
                    continue;
                }

                if (!antennaLocations.ContainsKey(map[i][j]))
                {
                    antennaLocations.Add(map[i][j], new List<Position>());
                }

                antennaLocations.TryGetValue(map[i][j], out List<Position>? coords);

                if(coords is null)
                {
                    throw new Exception("this shouldn't be possible");
                }

                coords.Add(new Position() { yPos = i, xPos = j });

            }
        }

        List<char> antennaKeys = antennaLocations.Keys.ToList();

        List<Position> rawAntinodePositions = new List<Position>();

        foreach (char key in antennaKeys)
        {
            List<Position> interactiveAntennaPositions = antennaLocations[key];

            rawAntinodePositions.AddRange(GetAntinodePositions(interactiveAntennaPositions));
        }

        List<Position> antinodesOnMap = rawAntinodePositions.Where(a => IsOnMap(a.yPos, a.xPos, map)).ToList();

        HashSet<string> uniquePositions = new HashSet<string>();

        foreach(Position pos in antinodesOnMap)
        {
            uniquePositions.Add($"{pos.xPos}-{pos.yPos}");
        }

        return uniquePositions.Count;

    }

    private static List<Position> GetAntinodePositions(List<Position> antennaPositions)
    {
        List<Position> antinodePositions = new List<Position>();

        foreach (Position antenna in antennaPositions)
        {
            foreach (Position otherAntenna in antennaPositions.Where(a => a.xPos != antenna.xPos && a.yPos != antenna.yPos))
            {
                int xDiff = antenna.xPos - otherAntenna.xPos;
                int yDiff = antenna.yPos - otherAntenna.yPos;

                antinodePositions.Add(new Position()
                {
                    xPos = antenna.xPos + xDiff,
                    yPos = antenna.yPos + yDiff
                });

                antinodePositions.Add(new Position()
                {
                    xPos = otherAntenna.xPos - xDiff,
                    yPos = otherAntenna.yPos - yDiff
                });
            }
        }

        return antinodePositions;
    }

    private static bool IsOnMap(int yPos, int xPos, char[][] map)
    {
        return yPos >= 0 && xPos >= 0 && yPos < map.Length && xPos < map[1].Length;
    }

    private class Position
    {
        public int xPos;
        public int yPos;
    }
}
