using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day7Part2
{
    public static long Solve(string input)
    {
        string[] inputLines = input.Split(Environment.NewLine).ToArray();

        long sumPossibleLines = 0;

        foreach (string line in inputLines)
        {
            string[] splitLine = line.Split(" ").ToArray();

            long solution = long.Parse(splitLine[0].Replace(":", ""));

            int[] operands = splitLine[1..].Select(int.Parse).ToArray();

            if (HasPossibleSolution(solution, operands))
            {
                sumPossibleLines += solution;
            }

        }

        return sumPossibleLines;

    }

    private static bool HasPossibleSolution(long solution, int[] operands)
    {
        int possibleCombinations = (int)Math.Pow(3, operands.Length - 1);

        for (int i = 0; i < possibleCombinations; i++)
        {
            char[] operators = GetOperators(i, operands.Length - 1);

            long currResult = operands[0];

            for (int j = 0; j < operators.Length; j++)
            {
                if (operators[j] == '+')
                {
                    currResult += operands[j + 1];
                }
                else if (operators[j] == '*')
                {
                    currResult *= operands[j + 1];
                }
                else if (operators[j] == '|')
                {
                    string concatResult = currResult.ToString() + operands[j + 1].ToString();
                    currResult = long.Parse(concatResult);
                }
                else
                {
                    throw new Exception("This shouldn't be possible");
                }
            }

            if (currResult == solution)
            {
                return true;
            }
        }

        return false;

    }

    private static char[] GetOperators(int combinationIndex, int numOperators)
    {
        char[] operators = new char[numOperators];

        string binaryRep = Int32ToString(combinationIndex, 3);
        binaryRep = binaryRep.PadLeft(numOperators, '0');
        char[] operatorParity = binaryRep.Reverse().ToArray();

        for (int i = 0; i < numOperators; i++)
        {
            operators[i] = operatorParity[i] == '0' ? '+' :
                operatorParity[i] == '1' ? '*' : '|';
        }

        return operators;

    }

    //borrowed from stack overflow because c# doesn't natively support converting to base 3
    public static string Int32ToString(int value, int toBase)
    {
        string result = string.Empty;
        do
        {
            result = "0123456789ABCDEF"[value % toBase] + result;
            value /= toBase;
        }
        while (value > 0);

        return result;
    }
}
