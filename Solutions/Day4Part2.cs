using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day4Part2
{
    public static int Solve(string input)
    {
        List<string> lines = input.Split(Environment.NewLine).ToList();
        char[][] inputMatrix = new char[lines.Count][];

        for (int i = 0; i < lines.Count; i++)
        {
            inputMatrix[i] = lines[i].ToCharArray();
        }

        int numMatches = 0;

        for (int i = 0; i < inputMatrix.Count(); i++)
        {
            for (int j = 0; j < inputMatrix[i].Length; j++)
            {
                if (IsMatch(inputMatrix, i, j))
                {
                    numMatches++;
                }
            }
        }

        return numMatches;
    }

    private static bool IsMatch(char[][] matrix, int yPos, int xPos)
    {
        if(yPos < 1 || xPos < 1 || yPos >= (matrix.Length - 1) || xPos >= matrix[yPos].Length - 1)
        {
            return false;
        }

        if (matrix[yPos][xPos] != 'A')
        {
            return false;
        }

        if ( (matrix[yPos - 1][xPos - 1] == 'M' && matrix[yPos + 1][xPos + 1] == 'S') 
            || (matrix[yPos - 1][xPos - 1] == 'S' && matrix[yPos + 1][xPos + 1] == 'M') )
        {
            if( (matrix[yPos + 1][xPos - 1] == 'M' && matrix[yPos - 1][xPos + 1] == 'S')
            || (matrix[yPos + 1][xPos - 1] == 'S' && matrix[yPos - 1][xPos + 1] == 'M'))
            {
                return true;
            }
        }

        return false;
    }

}
