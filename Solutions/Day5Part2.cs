using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Solutions;

public class Day5Part2
{

    public static int Solve(string input)
    {
        List<string> inputLines = input.Split(Environment.NewLine).ToList();

        List<string> orderingRuleLines = inputLines.Where(i => i.Contains("|")).ToList();

        List<string> updateLines = inputLines.Where(i => i.Contains(",")).ToList();

        List<OrderingRule> orderingRules = new List<OrderingRule>();

        foreach (string orderingRuleLine in orderingRuleLines)
        {
            List<string> splitRule = orderingRuleLine.Split("|").ToList();

            orderingRules.Add(new OrderingRule()
            {
                Predecessor = int.Parse(splitRule[0]),
                Successor = int.Parse(splitRule[1]),
            });

        }

        List<List<int>> manualUpdates = new List<List<int>>();

        foreach (string updateLine in updateLines)
        {
            List<string> splitUpdate = updateLine.Split(",").ToList();

            manualUpdates.Add(splitUpdate.Select(s => int.Parse(s)).ToList());
        }

        List<List<int>> invalidUpdates = manualUpdates.Where(u => !IsValid(orderingRules, u)).ToList();

        List<List<int>> fixedUpdates = new();

        foreach (List<int> update in invalidUpdates)
        {
            fixedUpdates.Add(GetOrderedUpdate(orderingRules, update));
        }

        int middlePageNumSum = 0;

        foreach (List<int> update in fixedUpdates)
        {
            middlePageNumSum += update[update.Count / 2];
        }

        return middlePageNumSum;

    }


    private static List<int> GetOrderedUpdate(List<OrderingRule> rules, List<int> update)
    {
        List<int> fixedUpdate = new List<int>();

        for (int i = 0; i < update.Count; i++)
        {
            foreach (int page in update.Where(u => !fixedUpdate.Contains(u)))
            {
                List<OrderingRule> relevantRules = rules.Where(r => r.Successor == page).ToList();

                bool matchFound = true;

                foreach (OrderingRule rule in relevantRules)
                {
                    if (update.Contains(rule.Predecessor) && !fixedUpdate.Contains(rule.Predecessor) )
                    {
                        matchFound = false;
                        break;
                    }
                }

                if(matchFound)
                {
                    fixedUpdate.Add(page);
                    break;
                }

            }

        }

        return fixedUpdate;

    }

    private static bool IsValid(List<OrderingRule> rules, List<int> update)
    {
        List<int> seenPages = new List<int>();

        foreach (int pageNum in update)
        {
            List<OrderingRule> relevantRules = rules.Where(r => r.Successor == pageNum).ToList();

            foreach (OrderingRule rule in relevantRules)
            {
                if (update.Contains(rule.Predecessor) && !seenPages.Contains(rule.Predecessor))
                {
                    return false;
                }

            }

            seenPages.Add(pageNum);
        }

        return true;
    }

    private class OrderingRule()
    {
        public int Predecessor { get; set; }
        public int Successor { get; set; }
    }
}
