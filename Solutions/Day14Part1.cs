using MoreLinq;
using System.Data;

namespace Advent2024.Solutions;

public class Day14Part1
{
    private static readonly int xDimension = 101;
    private static readonly int yDimension = 103;

    public static int Solve(string input)
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

        for(int i = 0; i < 100; i++)
        {
            foreach(Robot robot in robots)
            {
                robot.Move();
            }
        }

        int safetyFactor = 1;

        safetyFactor *= robots.Where(r => r.xPos < xDimension / 2 && r.yPos < yDimension / 2).Count();
        safetyFactor *= robots.Where(r => r.xPos > xDimension / 2 && r.yPos < yDimension / 2).Count();
        safetyFactor *= robots.Where(r => r.xPos < xDimension / 2 && r.yPos > yDimension / 2).Count();
        safetyFactor *= robots.Where(r => r.xPos > xDimension / 2 && r.yPos > yDimension / 2).Count();

        return safetyFactor;
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
            if(rawYPos >= 0)
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
