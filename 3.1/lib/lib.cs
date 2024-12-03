using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace lib;

public class Lib
{
    public static long Function(string input)
    {
        Regex re = new Regex("(?:mul\\((\\d+),(\\d+)\\))");
        long sum = re.Matches(input).Sum(match => {
            return int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        });
        return sum;
    }
}
