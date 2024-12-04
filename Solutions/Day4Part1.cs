using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions
{
    public class Day4Part1
    {

        private static int MatchLength = "XMAS".Length;

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
                    if(HasNorthMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasNorthEastMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasEastMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasSouthEastMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasSouthMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasSouthWestMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasWestMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }

                    if (HasNorthWestMatch(inputMatrix, i, j))
                    {
                        numMatches++;
                    }
                }
            }

            return numMatches;
        }

        private static bool HasNorthMatch(char[][] matrix, int yPos, int xPos)
        {
            if(yPos < (MatchLength - 1))
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos - 1][xPos] == 'M' && matrix[yPos - 2][xPos] == 'A' && matrix[yPos - 3][xPos] == 'S')
            {
                return true;
            }

            return false;
        }
        private static bool HasNorthEastMatch(char[][] matrix, int yPos, int xPos)
        {
            if (yPos < (MatchLength - 1))
            {
                return false;
            }

            if (xPos > matrix[yPos].Length - MatchLength)
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos - 1][xPos + 1] == 'M' && matrix[yPos - 2][xPos + 2] == 'A' && matrix[yPos - 3][xPos + 3] == 'S')
            {
                return true;
            }

            return false;
        }
        private static bool HasEastMatch(char[][] matrix, int yPos, int xPos)
        {
            if (xPos > matrix[yPos].Length - MatchLength)
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos][xPos + 1] == 'M' && matrix[yPos][xPos + 2] == 'A' && matrix[yPos][xPos + 3] == 'S')
            {
                return true;
            }

            return false;
        }
        private static bool HasSouthEastMatch(char[][] matrix, int yPos, int xPos)
        {
            if (xPos > matrix[yPos].Length - MatchLength)
            {
                return false;
            }

            if (yPos > matrix.Count() - MatchLength)
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos + 1][xPos + 1] == 'M' && matrix[yPos + 2][xPos + 2] == 'A' && matrix[yPos + 3][xPos + 3] == 'S')
            {
                return true;
            }

            return false;
        }
        private static bool HasSouthMatch(char[][] matrix, int yPos, int xPos)
        {
            if (yPos > matrix.Count() - MatchLength)
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos + 1][xPos] == 'M' && matrix[yPos + 2][xPos] == 'A' && matrix[yPos + 3][xPos] == 'S')
            {
                return true;
            }

            return false;
        }

        private static bool HasSouthWestMatch(char[][] matrix, int yPos, int xPos)
        {
            if (yPos > matrix.Count() - MatchLength)
            {
                return false;
            }

            if (xPos < MatchLength - 1)
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos + 1][xPos - 1] == 'M' && matrix[yPos + 2][xPos - 2] == 'A' && matrix[yPos + 3][xPos - 3] == 'S')
            {
                return true;
            }

            return false;
        }

        private static bool HasWestMatch(char[][] matrix, int yPos, int xPos)
        {
            if (xPos < MatchLength - 1)
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos][xPos - 1] == 'M' && matrix[yPos][xPos - 2] == 'A' && matrix[yPos][xPos - 3] == 'S')
            {
                return true;
            }

            return false;
        }

        private static bool HasNorthWestMatch(char[][] matrix, int yPos, int xPos)
        {
            if (xPos < MatchLength - 1)
            {
                return false;
            }

            if (yPos < (MatchLength - 1))
            {
                return false;
            }

            if (matrix[yPos][xPos] == 'X' && matrix[yPos - 1][xPos - 1] == 'M' && matrix[yPos - 2][xPos - 2] == 'A' && matrix[yPos - 3][xPos - 3] == 'S')
            {
                return true;
            }

            return false;
        }

    }
}
