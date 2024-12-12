using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day11Part1
{
    public static int Solve(string input)
    {
        List<long> stonesList = input.Replace(Environment.NewLine, "").Split(" ").Select(long.Parse).ToList();

        LinkedList<long> stones = new LinkedList<long>();

        foreach (long stone in stonesList)
        {
            stones.AddLast(stone);
        }

        for(int i = 0; i < 25; i++)
        {

            LinkedListNode<long>? currNode = stones.First;
            while(currNode != null)
            {
                if(currNode.Value == 0)
                {
                    currNode.Value = 1;
                    currNode = currNode.Next;
                    continue;
                }

                string currStoneString = currNode.Value.ToString();

                if (currStoneString.Length % 2 == 0)
                {
                    stones.AddBefore(currNode, new LinkedListNode<long>(long.Parse(currStoneString.Substring(0, currStoneString.Length / 2))));
                    currNode.Value = long.Parse(currStoneString.Substring(currStoneString.Length / 2));
                    currNode = currNode.Next;
                    continue;
                }
                
                if(currStoneString.Length % 2 == 1)
                {
                    currNode.Value *= 2024;
                    currNode = currNode.Next;
                    continue;
                }

                currNode = currNode.Next;
            }

        }

        return stones.Count();

    }


}
