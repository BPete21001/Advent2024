using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2024.Solutions
{
    public class Day3Part1
    {
        public static int Solve(string input)
        {
            Regex mulRegex = new Regex("mul[(][0-9]+[,][0-9]+[)]");

            List<string> matches = mulRegex.Matches(input).Select(m => m.ToString()).ToList();

            int sum = 0;

            foreach (string match in matches)
            { 
                string tempMatch = match.Remove(0, 4);
                tempMatch = tempMatch.Remove(tempMatch.Length - 1);

                int[] numbersToMul = tempMatch.Split(',').Select(x => int.Parse(x)).ToArray();
            
                sum += numbersToMul[0] * numbersToMul[1];
            }

            return sum;
        }


    }
}
