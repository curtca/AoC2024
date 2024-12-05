using System.Collections.Generic;
using System.Linq;

public class Lib
{
    static List<int[]> rules;
    public static long Function(string value)
    {
        var parts = value.Split("\r\n\r\n");
        rules = parts[0].Split("\r\n").Select(line => line.Split('|').Select(n => int.Parse(n)).ToArray()).ToList();
        List<int[]> orders = parts[1].Split("\r\n").Select(line => line.Split(',').Select(n => int.Parse(n)).ToArray()).ToList();

        return orders.Sum(o => OrderValid(o));
    }

    private static long OrderValid(int[] o)
    {
        foreach (var rule in rules)
            if (!MatchesRule(rule, o))
                return 0;

        return o[o.Length / 2];
    }

    private static bool MatchesRule(int[] rule, int[] order)
    {
        int first = Array.IndexOf(order, rule[0]);
        int second = Array.IndexOf(order, rule[1]);
        return first < second || first < 0 || second < 0;
    }
}
