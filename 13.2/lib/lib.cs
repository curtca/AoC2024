﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

public class Lib
{
    public static long Function(string value)
    {
        var claws = value.Split(Environment.NewLine + Environment.NewLine)
        .Select(strclaw => {
            var lines = strclaw.Split(Environment.NewLine);
            var A = Regex.Matches(lines[0], @"\b\d+\b");
            var B = Regex.Matches(lines[1], @"\b\d+\b");
            var P = Regex.Matches(lines[2], @"\b\d+\b");
            return (ax: int.Parse(A[0].Value), ay: int.Parse(A[1].Value), bx: int.Parse(B[0].Value), by: int.Parse(B[1].Value), 
                px: 10000000000000L + long.Parse(P[0].Value), py: 10000000000000L + long.Parse(P[1].Value));
        });

        long sum = claws.Sum(c => {
            long d = c.ax*c.by - c.ay*c.bx;
            double A = 1.0 * (c.px*c.by - c.py*c.bx) / d;
            double B = 1.0 * (c.py*c.ax - c.px*c.ay) / d;
            return (long) A == A && (long) B == B ? (long) (3 * A + B) : 0;
        });
        return sum;
    }
}
