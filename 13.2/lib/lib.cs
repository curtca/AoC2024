using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

public class Lib
{
    public static long Function(string value)
    {
        var claws = value.Split(Environment.NewLine + Environment.NewLine)
        .Select(strclaw => {
            // var lines = strclaw.Split(Environment.NewLine);
            var m = Regex.Matches(strclaw, @"-?\d+").Select(m => long.Parse(m.Value)).ToArray();
            return (ax: m[0], ay: m[1], bx: m[2], by: m[3], px: 10000000000000L + m[4], py: 10000000000000L + m[5]);
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
