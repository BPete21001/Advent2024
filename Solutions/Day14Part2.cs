using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Advent2024.Solutions;

public class Day14Part2
{
    private static readonly int xDimension = 101;
    private static readonly int yDimension = 103;

    public static void Solve(string input)
    {
        List<string> robotList = input.Split(Environment.NewLine).ToList();
        List<Robot> robots = new List<Robot>();


        foreach (string robot in robotList)
        {
            List<string> splitRobot = robot.Split(" ").ToList();

            Robot newRobot = new Robot();

            newRobot.xPos = int.Parse(splitRobot.First(s => s.Contains("p")).Replace("p=", "").Split(",").First());
            newRobot.yPos = int.Parse(splitRobot.First(s => s.Contains("p")).Replace("p=", "").Split(",").Last());

            newRobot.xVelocity = int.Parse(splitRobot.First(s => s.Contains("v")).Replace("v=", "").Split(",").First());
            newRobot.yVelocity = int.Parse(splitRobot.First(s => s.Contains("v")).Replace("v=", "").Split(",").Last());

            robots.Add(newRobot);
        }

        Tuple<int, int> outlier = new Tuple<int, int>(GetNumUniqueYPositions(robots) * GetNumUniqueXPositions(robots), 0);

        for(int i = 1; i < xDimension * yDimension; i++)
        {
            foreach (Robot robot in robots)
            {
                robot.Move();
            }

            int numUniqueYPositions = GetNumUniqueYPositions(robots) * GetNumUniqueXPositions(robots);

            if(outlier.Item1 > numUniqueYPositions)
            {
                outlier = new Tuple<int, int>(numUniqueYPositions, i);
                PrintRobots(robots);
                Console.WriteLine($"^^^ {i} Seconds ^^^");
            }
        }

        Console.WriteLine(outlier.Item2);

    }

    private static int GetNumUniqueYPositions(List<Robot> robots)
    {
        HashSet<int> uniqueYPositions = new HashSet<int>();

        foreach (Robot robot in robots)
        {
            uniqueYPositions.Add(robot.yPos);
        }

        return uniqueYPositions.Count;
    }

    private static int GetNumUniqueXPositions(List<Robot> robots)
    {
        HashSet<int> uniqueYPositions = new HashSet<int>();

        foreach (Robot robot in robots)
        {
            uniqueYPositions.Add(robot.xPos);
        }

        return uniqueYPositions.Count;
    }

    private static void PrintRobots(List<Robot> robots)
    {
        for(int i = 0; i < yDimension; i++)
        {
            for(int j = 0; j < xDimension; j++)
            {
                if(robots.Any(r => r.xPos == j && r.yPos == i))
                {
                    Console.Write("x");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }

    private class Robot()
    {
        public int yPos { get; set; }
        public int xPos { get; set; }
        public int yVelocity { get; set; }
        public int xVelocity { get; set; }

        public void Move()
        {
            int rawYPos = yPos + yVelocity;
            if (rawYPos >= 0)
            {
                yPos = rawYPos % yDimension;
            }
            else
            {
                yPos = yDimension + rawYPos;
            }

            int rawXPos = xPos + xVelocity;
            if (rawXPos >= 0)
            {
                xPos = rawXPos % xDimension;
            }
            else
            {
                xPos = xDimension + rawXPos;
            }
        }

    }

}
