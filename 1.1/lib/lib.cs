using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lib;

public class Lib
{
    public static long ListDistance(string value)
    {
        string[] lines = value.Split("\r\n");
        var numpairs = lines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => long.Parse(i)).ToList()).ToList();
        var sorted = Enumerable.Range(0, numpairs[0].Count)
            .Select(i => {
                var list = numpairs.Select(pair => pair[i]).ToList();
                list.Sort();
                return list;
            }).ToList();
        long dist = Enumerable.Range(0, sorted[0].Count)
            .Sum(i => Math.Abs(sorted[0][i] - sorted[1][i]));
        return dist;
    }
}
