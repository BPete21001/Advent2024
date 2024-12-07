using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day6Part2
{
    public static int Solve(string input)
    {
        string[] inputLines = input.Split(Environment.NewLine).ToArray();

        char[][] map = inputLines.Select(l => l.ToCharArray()).ToArray();

        Guard guard = new Guard()
        {
            Direction = 'X'
        };

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '^')
                {
                    guard.yPos = i;
                    guard.xPos = j;
                    guard.Direction = 'N';
                    break;
                }
            }

            if (guard.Direction == 'N')
            {
                break;
            }

        }

        int numInfiniteLoops = 0;

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '^' || map[i][j] == '#')
                {
                    continue;
                }

                Guard tempGuard = new Guard()
                {
                    yPos = guard.yPos,
                    xPos = guard.xPos,
                    Direction = guard.Direction
                };

                map[i][j] = '#';

                if(IsInfiniteLoop(tempGuard, map))
                {
                    numInfiniteLoops++;
                }

                map[i][j] = '.';

            }
        }

        return numInfiniteLoops;

    }

    private static bool IsInfiniteLoop(Guard guard, char[][] map)
    {
        HashSet<string> seenPositions = new HashSet<string>();

        while (IsOnMap(guard.yPos, guard.xPos, map))
        {
            string currPosition = $"{guard.yPos}-{guard.xPos}-{guard.Direction}";

            if (seenPositions.Contains(currPosition))
            {
                return true;
            }

            seenPositions.Add(currPosition);

            Tuple<int, int> facingSquare = guard.GetFacingSquare();

            if (!IsOnMap(facingSquare.Item1, facingSquare.Item2, map))
            {
                guard.Step();
                continue;
            }

            if (map[facingSquare.Item1][facingSquare.Item2] == '#')
            {
                guard.Rotate();
                continue;
            }

            guard.Step();
        }

        return false;
    }

    private static bool IsOnMap(int yPos, int xPos, char[][] map)
    {
        return yPos >= 0 && xPos >= 0 && yPos < map.Length && xPos < map[1].Length;
    }

    private class Guard()
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public char Direction { get; set; }

        public void Rotate()
        {
            if (this.Direction == 'N')
            {
                this.Direction = 'E';
                return;
            }
            if (this.Direction == 'E')
            {
                this.Direction = 'S';
                return;
            }
            if (this.Direction == 'S')
            {
                this.Direction = 'W';
                return;
            }
            if (this.Direction == 'W')
            {
                this.Direction = 'N';
                return;
            }
        }

        public void Step()
        {
            if (this.Direction == 'N')
            {
                yPos--;
            }
            if (this.Direction == 'E')
            {
                xPos++;
            }
            if (this.Direction == 'S')
            {
                yPos++;
            }
            if (this.Direction == 'W')
            {
                xPos--;
            }
        }

        //returns a tuple of yPos, xPos
        public Tuple<int, int> GetFacingSquare()
        {
            if (this.Direction == 'N')
            {
                return new Tuple<int, int>(yPos - 1, xPos);
            }
            if (this.Direction == 'E')
            {
                return new Tuple<int, int>(yPos, xPos + 1);
            }
            if (this.Direction == 'S')
            {
                return new Tuple<int, int>(yPos + 1, xPos);
            }
            if (this.Direction == 'W')
            {
                return new Tuple<int, int>(yPos, xPos - 1);
            }

            throw new ApplicationException("This state should be impossible");
        }

    }

}
