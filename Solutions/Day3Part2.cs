using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2024.Solutions
{
    public class Day3Part2
    {
        public static int Solve(string input)
        {
            Regex mulRegex = new Regex("(mul[(][0-9]+[,][0-9]+[)])|(do[(][)])|(don't[(][)])");

            List<string> matches = mulRegex.Matches(input).Select(m => m.ToString()).ToList();

            int sum = 0;
            bool enabled = true;
            foreach (string match in matches)
            {
                if(match == "do()")
                {
                    enabled = true;
                    continue;
                }

                if(match == "don't()")
                {
                    enabled = false;
                    continue;
                }

                if (enabled)
                {
                    sum += GetMulResult(match);
                }
                
            }

            return sum;
        }

        private static int GetMulResult(string mulOp)
        {
            string tempMatch = mulOp.Remove(0, 4);
            tempMatch = tempMatch.Remove(tempMatch.Length - 1);

            int[] numbersToMul = tempMatch.Split(',').Select(x => int.Parse(x)).ToArray();

            return numbersToMul[0] * numbersToMul[1];
        }


    }
}
