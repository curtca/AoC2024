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
        int dir = Math.Sign(list[1] - list[0]);
        for (int i = 1; i < list.Count; i++) {
            long diff = dir * (list[i] - list[i-1]);
            if (diff <= 0 || diff > 3) return false;
        }
        return true;
    }
}

    
    

    
