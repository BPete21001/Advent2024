using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions
{
    public class Day2Part2
    {
        public static int Solve(string input)
        {
            List<string> reports = input.Split(Environment.NewLine).ToList();

            int safeReportCount = 0;

            foreach (string rawReport in reports)
            {
                List<int> report = rawReport.Split(" ").Select(s => int.Parse(s)).ToList();

                for(int i = 0; i < report.Count; i++)
                { 
                    List<int> tempReport = new List<int>(report);
                    tempReport.RemoveAt(i);

                    if (IsReportSafe(tempReport))
                    {
                        safeReportCount++;
                        break;
                    }
                }
            }

            return safeReportCount;
        }

        private static bool IsReportSafe(List<int> report)
        {
            if (report[0] == report[1])
            {
                return false;
            }

            bool isIncreasing = report[1] - report[0] > 0;

            for (int i = 0; i < report.Count - 1; i++)
            {
                int diff = report[i] - report[i + 1];

                if (isIncreasing)
                {
                    diff *= -1;
                }

                if (diff < 1 || diff > 3)
                {
                    return false;
                }

            }

            return true;

        }


    }
}
