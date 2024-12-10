using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day9Part2
{

    public static long Solve(string input)
    {
        List<int> intInput = input.ToCharArray().Select(i => i - '0').ToList();
        List<int> expandedInput = new List<int>();

        for (int i = 0; i < intInput.Count; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < intInput[i]; j++)
                {
                    expandedInput.Add(i / 2);
                }
            }
            else
            {
                for (int j = 0; j < intInput[i]; j++)
                {
                    expandedInput.Add(-1);
                }
            }
        }

        List<Tuple<int, int>> expandedInputWithIdicies = new();
        List<IGrouping<int, Tuple<int, int>>> blocks = new();
        bool recalculateFreeBlocks = true;

        for (int i = expandedInput.Max(); i >= 0; i--)
        {

            int blockSize = expandedInput.Where(b => b == i).Count();

            int indexer = 0;

            if (recalculateFreeBlocks)
            {
                expandedInputWithIdicies = expandedInput.Select(i => new Tuple<int, int>(i, indexer++)).ToList();
                blocks = expandedInputWithIdicies.GroupAdjacent(i => i.Item1).ToList();
            }

            IGrouping<int, Tuple<int, int>>? firstFreeBlock = blocks.FirstOrDefault(b => b.Key == -1 && b.Count() >= blockSize);

            if (firstFreeBlock is null)
            {
                recalculateFreeBlocks = false;
                continue;
            }

            int oldBlockStart = expandedInput.IndexOf(i);
            int newBlockStart = firstFreeBlock.First().Item2;

            if (oldBlockStart <= newBlockStart)
            {
                recalculateFreeBlocks = false;
                continue;
            }

            for (int j = 0; j < blockSize; j++)
            {
                expandedInput[oldBlockStart + j] = -1;
                expandedInput[newBlockStart + j] = i;
            }

            recalculateFreeBlocks = true;

        }

        long checksum = 0;

        for (int i = 0; i < expandedInput.Count(); i++)
        {
            if (expandedInput[i] < 0)
            {
                continue;
            }

            checksum += expandedInput[i] * i;
        }

        return checksum;

    }

}
