using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day15Part1
{
    public static int Solve(string input)
    {
        string rawMap = input.Split($"{Environment.NewLine}{Environment.NewLine}").First();

        string rawMoves = input.Split($"{Environment.NewLine}{Environment.NewLine}").Last();

        char[] moves = rawMoves.Replace(Environment.NewLine, "").ToCharArray();

        string[] splitMap = rawMap.Split(Environment.NewLine);

        char[][] charMap = splitMap.Select(l => l.ToCharArray()).ToArray();

        List<MapObject> mapObjects = new List<MapObject>();

        for (int i = 0; i < charMap.Length; i++)
        {
            for (int j = 0; j < charMap[i].Length; j++)
            {
                if (charMap[i][j] == '@')
                {
                    mapObjects.Add(new MapObject()
                    {
                        xPos = j,
                        yPos = i,
                        Type = MapObjectType.Robot
                    });
                }

                if (charMap[i][j] == 'O')
                {
                    mapObjects.Add(new MapObject()
                    {
                        xPos = j,
                        yPos = i,
                        Type = MapObjectType.Box
                    });
                }
                
                if (charMap[i][j] == '#')
                {
                    mapObjects.Add(new MapObject()
                    {
                        xPos = j,
                        yPos = i,
                        Type = MapObjectType.Wall
                    });
                }
            }
        }

        MapObject robot = mapObjects.First(mo => mo.Type == MapObjectType.Robot);

        foreach(char move in moves)
        {
            MapObject currObject = robot;

            List<MapObject> objectsToMove = new List<MapObject>()
            {
                currObject
            };

            MapObject? objectInWay = currObject.GetObjectInWay(move, mapObjects);

            while (objectInWay != null)
            {
                objectsToMove.Add(objectInWay);
                currObject = objectInWay;
                objectInWay = currObject.GetObjectInWay(move, mapObjects);
            }

            if(!objectsToMove.Any(o => o.Type == MapObjectType.Wall))
            {
                objectsToMove.ForEach(o => o.Move(move));
            }
        }

        int gpsSum = 0;

        foreach(MapObject box in mapObjects.Where(o => o.Type == MapObjectType.Box))
        {
            gpsSum += box.yPos * 100;
            gpsSum += box.xPos;
        }

        return gpsSum;
    }

    private class MapObject()
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public MapObjectType Type { get; set; }

        public void Move(char direction)
        {
            if(direction == '^')
            {
                yPos--;
                return;
            }

            if (direction == '>')
            {
                xPos++;
                return;
            }

            if (direction == 'v')
            {
                yPos++;
                return;
            }

            if (direction == '<')
            {
                xPos--;
                return;
            }

            throw new Exception("invalid move");
        }

        public MapObject? GetObjectInWay(char direction, List<MapObject> objects)
        {
            if (direction == '^')
            {
                return objects.FirstOrDefault(o => o.xPos == xPos && o.yPos == yPos - 1);
            }

            if (direction == '>')
            {
                return objects.FirstOrDefault(o => o.xPos == xPos + 1 && o.yPos == yPos);
            }

            if (direction == 'v')
            {
                return objects.FirstOrDefault(o => o.xPos == xPos && o.yPos == yPos + 1);
            }

            if (direction == '<')
            {
                return objects.FirstOrDefault(o => o.xPos == xPos - 1 && o.yPos == yPos);
            }

            throw new Exception("invalid move");
        }

    }

    private enum MapObjectType
    {
        Wall,
        Robot,
        Box
    }
}
