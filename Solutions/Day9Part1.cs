using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions
{
    public class Day9Part1
    {
        public static long Solve(string input)
        {
            List<int> intInput = input.ToCharArray().Select(i => i - '0').ToList();
            List<int> expandedInput = new List<int>();

            for (int i = 0; i < intInput.Count; i ++)
            {
                if(i % 2 == 0)
                {
                    for (int j = 0; j < intInput[i]; j++)
                    {
                        expandedInput.Add(i/2);
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

            for (int i = expandedInput.Count - 1; i >= 0; i--)
            {
                if (expandedInput[i] != -1)
                {
                    int freeIndex = expandedInput.IndexOf(-1);

                    if(freeIndex > i)
                    {
                        break;
                    }

                    if(freeIndex != -1)
                    {
                        expandedInput[freeIndex] = expandedInput[i];
                        expandedInput[i] = -1;
                    }
                }
            }

            long checksum = 0;

            for(int i = 0; i < expandedInput.Where(i => i >= 0).Count(); i++)
            {
                checksum += expandedInput[i] * i;
            }

            return checksum;
        }

    }
}
