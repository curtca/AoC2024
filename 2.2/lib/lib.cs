using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace lib;

public class Lib
{
    public static long Function(string value)
    {
        var reports = value.Split("\r\n").Select(line => line.Split(" ").Select(long.Parse).ToList()).ToList();
        return reports.Count(IsReportSafe);
    }

    private static bool IsReportSafe(List<long> list)
    {
        return InnerIRS(list, true);
    }

    private static bool InnerIRS(List<long> list, bool allowRemoval)
    {
        if (allowRemoval && InnerIRS(list.ToList().Skip(1).ToList(), false))
            return true;
        int dir = Math.Sign(list[1] - list[0]);
        for (int i = 1; i < list.Count; i++) {
            long diff = dir * (list[i] - list[i - 1]);
            if (diff <= 0 || diff > 3) {
                if (allowRemoval) {
                    var newlist1 = list.ToList();
                    newlist1.RemoveAt(i-1);
                    var newlist2 = list.ToList();
                    newlist2.RemoveAt(i);
                    bool isSafe = InnerIRS(newlist1, false) || InnerIRS(newlist2, false);
                    return isSafe;
                }
                return false;
            }
        }
        return true;
    }
}