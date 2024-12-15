using System.Xml.XPath;

namespace Advent2024.Solutions;

public class Day15Part2
{
    public static int Solve(string input)
    {
        string rawMap = input.Split($"{Environment.NewLine}{Environment.NewLine}").First();

        string rawMoves = input.Split($"{Environment.NewLine}{Environment.NewLine}").Last();

        char[] moves = rawMoves.Replace(Environment.NewLine, "").ToCharArray();

        string[] splitMap = rawMap.Split(Environment.NewLine);
        List<string> expandedSplitMap = new List<string>();

        foreach (string line in splitMap)
        {
            string tempLine = line;
            tempLine = tempLine.Replace(".", "..");
            tempLine = tempLine.Replace("@", "@.");
            tempLine = tempLine.Replace("#", "##");
            tempLine = tempLine.Replace("O", "[]");
            expandedSplitMap.Add(tempLine);
        }

        char[][] charMap = expandedSplitMap.Select(l => l.ToCharArray()).ToArray();

        List<MapObject> mapObjects = new List<MapObject>();

        for (int i = 0; i < charMap.Length; i++)
        {
            for (int j = 0; j < charMap[i].Length; j++)
            {
                if (charMap[i][j] == '@')
                {
                    mapObjects.Add(new MapObject()
                    {
                        Positions = new List<Position>()
                        {
                            new Position()
                            {
                                xPos = j,
                                yPos = i,
                            }
                        },
                        Type = MapObjectType.Robot
                    });
                }

                if (charMap[i][j] == '[')
                {
                    mapObjects.Add(new MapObject()
                    {
                        Positions = new List<Position>()
                        {
                            new Position()
                            {
                                xPos = j,
                                yPos = i,
                            },
                            new Position()
                            {
                                xPos = j + 1,
                                yPos = i,
                            }
                        },
                        Type = MapObjectType.Box
                    });
                }
                
                if (charMap[i][j] == '#')
                {
                    mapObjects.Add(new MapObject()
                    {
                        Positions = new List<Position>()
                        {
                            new Position()
                            {
                                xPos = j,
                                yPos = i,
                            }
                        },
                        Type = MapObjectType.Wall
                    });
                }
            }
        }

        MapObject robot = mapObjects.First(mo => mo.Type == MapObjectType.Robot);

        foreach(char move in moves)
        {

            List<MapObject> currObjects = new List<MapObject>()
            {
                robot
            };

            List<MapObject> objectsToMove = new List<MapObject>(currObjects);

            List<MapObject> objectsInWay = new List<MapObject>();
                
            foreach(MapObject obj in currObjects)
            {
                objectsInWay.AddRange(obj.GetObjectsInWay(move, mapObjects));
            }

            while (objectsInWay.Any())
            {
                objectsToMove.AddRange(objectsInWay);
                currObjects = objectsInWay;
                objectsInWay = new List<MapObject>();
                foreach (MapObject obj in currObjects)
                {
                    objectsInWay.AddRange(obj.GetObjectsInWay(move, mapObjects));
                }
            }

            if(!objectsToMove.Any(o => o.Type == MapObjectType.Wall))
            {
                objectsToMove.Distinct().ToList().ForEach(o => o.Move(move));
            }

        }

        int gpsSum = 0;

        foreach(MapObject box in mapObjects.Where(o => o.Type == MapObjectType.Box))
        {
            gpsSum += box.Positions.First().yPos * 100;
            gpsSum += box.Positions.First().xPos;
        }

        

        return gpsSum;
    }

    private class MapObject()
    {
        public List<Position> Positions = new List<Position>();
        public MapObjectType Type { get; set; }

        public void Move(char direction)
        {
            if(direction == '^')
            {
                foreach(Position pos in Positions)
                {
                    pos.yPos--;
                }
                return;
            }

            if (direction == '>')
            {
                foreach (Position pos in Positions)
                {
                    pos.xPos++;
                }
                return;
            }

            if (direction == 'v')
            {
                foreach (Position pos in Positions)
                {
                    pos.yPos++;
                }
                return;
            }

            if (direction == '<')
            {
                foreach (Position pos in Positions)
                {
                    pos.xPos--;
                }
                return;
            }

            throw new Exception("invalid move");
        }

        public List<MapObject> GetObjectsInWay(char direction, List<MapObject> objects)
        {
            List<MapObject> objectsInWay = new List<MapObject>();

            List<MapObject> otherObjects = objects.Where(o => o != this).ToList();

            if (direction == '^')
            {
                foreach(Position pos in Positions)
                {
                    objectsInWay.AddRange(otherObjects.Where(o => o.Positions.Any(p => p.xPos == pos.xPos && p.yPos == pos.yPos - 1)));
                }
            }

            if (direction == '>')
            {
                foreach (Position pos in Positions)
                {
                    objectsInWay.AddRange(otherObjects.Where(o => o.Positions.Any(p => p.xPos == pos.xPos + 1 && p.yPos == pos.yPos)));
                }
            }

            if (direction == 'v')
            {
                foreach (Position pos in Positions)
                {
                    objectsInWay.AddRange(otherObjects.Where(o => o.Positions.Any(p => p.xPos == pos.xPos && p.yPos == pos.yPos + 1)));
                }
            }

            if (direction == '<')
            {
                foreach (Position pos in Positions)
                {
                    objectsInWay.AddRange(otherObjects.Where(o => o.Positions.Any(p => p.xPos == pos.xPos - 1 && p.yPos == pos.yPos)));
                }
            }

            return objectsInWay;
        }

    }

    private class Position
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
    }
    private enum MapObjectType
    {
        Wall,
        Robot,
        Box
    }
}
